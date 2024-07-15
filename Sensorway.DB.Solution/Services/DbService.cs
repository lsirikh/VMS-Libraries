using Dapper;
using Dotnet.Libraries.Base;
using Dotnet.OnvifSolution.Base.Enums;
using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Dappers;
using Dotnet.OnvifSolution.Base.Models.Extends;
using Dotnet.OnvifSolution.Collection.Providers;
using Sensorway.Accounts.Base.Models;
using Sensorway.Accounts.Collection.Providers;
using Sensorway.DB.Solution.Models;
using Sensorway.Events.Base.Models;
using Sensorway.Events.Collection.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SQLite;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.DB.Solution.Services
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/5/2024 1:36:29 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    internal class DbService : TaskService, IDbService
    {
        #region - Ctors -
        public DbService(ILogService log
                        , DbSetupModel setupModel
                        , CameraDeviceProvider cameraPovider
                        , CameraZoneProvider zoneProvider
                        , UserProvider userProvider
                        , ChannelClientProvider channelProvider
                        , LoginSessionProvider sessionProvider
                        , Events.Collection.Providers.EventProvider eventProvider
                        , ActionEventProvider actionEventProvider)
        {
            _log = log;
            _setupModel = setupModel;
            _cameraDeviceProvider = cameraPovider;
            _cameraZoneProvider = zoneProvider;
            _channelProvider = channelProvider;
            _userProvider = userProvider;
            _sessionProvider = sessionProvider;
            _eventProvider = eventProvider;
            _actionEventProvider = actionEventProvider;
        }
        #endregion
        #region - Implementation of Interface -
        protected override async Task RunTask(CancellationToken token = default)
        {
            await Connect(_setupModel);

            await BuildSchemeAsync(token);

            await FetchFullInstanceAsync(token);
        }

        protected override Task ExitTask(CancellationToken token = default)
        {
            return Task.CompletedTask;
        }
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public Task Connect(DbSetupModel setupModel)
        {
            try
            {
                var dataSource = ((Func<string, string, int, string>)(
                    (pathDatabase, nameDatabase, version) =>
                    {
                        if (!Directory.CreateDirectory(pathDatabase).Exists)
                            throw new DirectoryNotFoundException();
                        return $@"Data Source={Path.Combine(pathDatabase, nameDatabase)}; Version={version};";

                    }))(Path.Combine(Environment.CurrentDirectory, setupModel.PathDatabase), setupModel.NameDatabase, setupModel.Version);

                _conn = new SQLiteConnection(dataSource);
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(Connect)} of {nameof(DbService)} : {ex}");
            }
            return Task.CompletedTask;
        }

        private Task BuildSchemeAsync(CancellationToken token = default)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    using (var cmd = _conn.CreateCommand())
                    {
                        cmd.CommandText = @$"CREATE TABLE IF NOT EXISTS {REDIS_CHANNEL_TABLE} (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                    clientid INTEGER,
                                    channel TEXT,
                                    ipaddress TEXT,
                                    created DATETIME NOT NULL DEFAULT (DATETIME('NOW', 'LOCALTIME')))";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @$"CREATE TABLE IF NOT EXISTS {CAMERA_DEVICE_TABLE} (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                    devicename TEXT,
                                    zone INTEGER,
                                    username TEXT,
                                    password TEXT,
                                    ipaddress TEXT,
                                    port INTEGER,
                                    portonvif INTEGER,
                                    portrtsp INTEGER,
                                    rtspauthrequired BOOLEAN,
                                    isdummy BOOLEAN,
                                    dummyoption TEXT,
                                    manufacturer TEXT,
                                    devicemodel TEXT,
                                    firmwareversion TEXT,
                                    serialnumber TEXT,
                                    hardwareid TEXT)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @$"CREATE TABLE IF NOT EXISTS {CAMERA_ZONE_TABLE} (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                    name TEXT,
                                    description TEXT)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = $@"CREATE TABLE IF NOT EXISTS {USER_TABLE} (
                                        id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                        username TEXT NOT NULL UNIQUE,
                                        password TEXT NOT NULL,
                                        level INTEGER DEFAULT 2,
                                        name TEXT NOT NULL,
                                        used INTEGER DEFAULT 1,
                                        created DATETIME NOT NULL DEFAULT (DATETIME('NOW', 'LOCALTIME'))
                                        )";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = $@"CREATE TABLE IF NOT EXISTS {USER_SESSION_TABLE} (
                                            id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                            username TEXT NOT NULL,
                                            password TEXT NOT NULL,
                                            clientid INTEGER,
                                            token TEXT NOT NULL,
                                            mode INTEGER DEFAULT 1,
                                            expired DATETIME NOT NULL DEFAULT (DATETIME('NOW', 'LOCALTIME')),
                                            created DATETIME NOT NULL DEFAULT (DATETIME('NOW', 'LOCALTIME'))
                                           )";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = $@"CREATE TABLE IF NOT EXISTS {EVENT_TABLE} (
                                            id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                            name TEXT NOT NULL UNIQUE,
                                            type INTEGER,
                                            cameraid INTEGER,
                                            cameraname TEXT,
                                            targetpreset TEXT,
                                            homepreset TEXT,
                                            duration INTEGER
                                            )";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = $@"CREATE TABLE IF NOT EXISTS {ACTION_EVENT_TABLE} (
                                            id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                            eventid INTEGER,
                                            message TEXT,
                                            status INTEGER,
                                            created DATETIME NOT NULL DEFAULT (DATETIME('NOW', 'LOCALTIME'))
                                           )";
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    _log.Error($"Raised {nameof(Exception)} in {nameof(BuildSchemeAsync)} of {nameof(DbService)} : {ex}");
                }
            });
        }

        private async Task FetchFullInstanceAsync(CancellationToken token)
        {
            await FetchCameraZones(token);
            await CheckDefaultZoneTask(token);
            
            foreach (var item in await FetchCameraDevices(token))
            {
                _cameraDeviceProvider.Add(item);
            }

            foreach (var item in await FetchChannels(token))
            {
                _channelProvider.Add(item);
            }
            
            foreach (var item in await FetchUsers(token))
            {
                _userProvider.Add(item);
            }

            foreach (var item in await FetchSessions(token))
            {
                _sessionProvider.Add(item);
            }

            foreach (var item in await FetchEvents(token))
            {
                _eventProvider.Add(item);
            }

        }

        private async Task CheckDefaultZoneTask(CancellationToken token, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                if (!(_cameraZoneProvider.Count() > 0))
                {
                    var defaultGroup = await SaveCameraZone(new CameraZoneModel("--------", "default"));
                    _cameraZoneProvider.Add(defaultGroup);
                    _log.Info($"Create a default CameraZone to save into {CAMERA_ZONE_TABLE} table.");
                }
                tcs?.SetResult(true);
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(CheckDefaultZoneTask)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(CheckDefaultZoneTask)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
            }
        }

        public async Task<ICameraDeviceModel> FetchCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       CAMERA_DEVICE_TABLE
                ///////////////////////////////////////////////////////////////////
                //var sql = @$"SELECT * FROM {CAMERA_DEVICE_TABLE} WHERE used = '1'";
                string sql = @$"SELECT * FROM {CAMERA_DEVICE_TABLE} WHERE devicename = '{model.DeviceName}'";

                if (!model.IsDummy)
                {
                    sql += @$" AND ipaddress = '{model.IpAddress}'";
                }

                var fetchedModel = (await _conn.QueryAsync<CameraDeviceDapper>(sql)).FirstOrDefault();
                var zone = _cameraZoneProvider.Where(entity => entity.Id == fetchedModel.Zone).FirstOrDefault();
                var camera = new CameraDeviceModel(fetchedModel);
                camera.Zone = zone as CameraZoneModel;

                tcs?.SetResult(true);
                return camera;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchCameraDevice)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchCameraDevice)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }

        

        public async Task<List<ICameraDeviceModel>> FetchCameraDevices(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                    await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       CAMERA_DEVICE_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {CAMERA_DEVICE_TABLE}";
                
                var commitResult = 0;
                List<ICameraDeviceModel> cameras = new List<ICameraDeviceModel>();
                foreach (var model in (await _conn.QueryAsync<CameraDeviceDapper>(sql)))    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchCameraDevices)}의 테스크가 강제 종료 되었습니다.");
                    
                    var zone = _cameraZoneProvider.Where(entity => entity.Id == model.Zone).FirstOrDefault();
                    var camera = new CameraDeviceModel(model);
                    camera.Zone = zone as CameraZoneModel;

                    cameras.Add(camera);
                    //_cameraDeviceProvider.Add(createdModel);
                    commitResult ++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{CAMERA_DEVICE_TABLE}].", true);

                tcs?.SetResult(true);
                return cameras;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchCameraDevices)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchCameraDevices)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }

        

        public Task<ICameraDeviceModel> SaveCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    var table = CAMERA_DEVICE_TABLE;

                    var isExistZone = _cameraZoneProvider.Any(entity => entity.Id == model.Zone?.Id);
                    if(!isExistZone) throw new Exception($"CameraDevice does not have 'zone' property.");

                    // DB에서 devicename 혹은 ipaddress가 이미 있는지 확인
                    var existResult = await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT COUNT(1) FROM {table}
                                                                                WHERE devicename = @DeviceName OR ipaddress = @IpAddress"
                                                                                , new { DeviceName = model.DeviceName, IpAddress = model.IpAddress });

                    if (existResult > 0)
                    {
                        throw new Exception($"[{model.DeviceName}({model.IpAddress})]DeviceName or IpAddress already exists in the database.");
                    }

                    var dapper = new CameraDeviceDapper(model);
                    commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                        (devicename, zone, username, password, ipaddress, port, portonvif, portrtsp, rtspauthrequired, isdummy, dummyoption, manufacturer, devicemodel, firmwareversion, serialnumber, hardwareid) 
                        VALUES
                        (@DeviceName, @Zone, @UserName, @Password, @IpAddress, @Port, @PortOnvif, @PortRtsp, @RtspAuthRequired, @IsDummy, @DummyOption, @Manufacturer, @DeviceModel, @FirmwareVersion, @SerialNumber, @HardwareId)", dapper);

                    _log.Info($"({commitResult}) rows was inserted in DB[{table}] : {model}", true);

                    var fetchedModel = await FetchCameraDevice(model);
                    if (fetchedModel == null) throw new Exception($"Fail to fetch {model.DeviceName} from {table}");

                    if (fetchedModel.IsDummy)
                    {
                        //Dummy 카메라인 경우 NOT_AVAILABLE 설정
                        fetchedModel.CameraStatus = EnumCameraStatus.NOT_AVAILABLE;
                        //Dummy CameraMedia 정보 null로 설정
                        fetchedModel.CameraMedia = null;
                    }

                    //_cameraDeviceProvider.Add((CameraDeviceModel)fetchedModel);

                    tcs?.SetResult(true);
                    return fetchedModel;
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveCameraDevice)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveCameraDevice)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
            });
        }

        public Task SaveCameraDevices(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = CAMERA_DEVICE_TABLE;

                    var count = Convert.ToInt32(await _conn.ExecuteScalarAsync($@"SELECT COUNT(*) FROM {table}"));

                    if (count > 0)
                    {
                        commitResult = await _conn.ExecuteAsync($@"DELETE FROM {table}");

                        _log.Info($"DELETE {table} for saving new Data in DB", true);
                        if (!(commitResult > 0))
                            throw new Exception($"Raised exception during deleting Table({table}).");
                    }

                    int insertedRecord = 0;
                    using (var transaction = _conn.BeginTransaction())
                    {
                        foreach (var model in _cameraDeviceProvider)
                        {
                            if (token.IsCancellationRequested) throw new TaskCanceledException();

                            // DB에서 devicename 혹은 ipaddress가 이미 있는지 확인
                            var existResult = await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT COUNT(1) FROM {table}
                                                                                WHERE devicename = @DeviceName OR ipaddress = @IpAddress"
                                                                                        , new { DeviceName = model.DeviceName, IpAddress = model.IpAddress });

                            if (existResult > 0)
                            {
                                _log.Info($"[{model.DeviceName}({model.IpAddress})]DeviceName or IpAddress already exists in the database.");
                            }

                            var dapper = new CameraDeviceDapper(model);
                            commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                        (devicename, zone, username, password, ipaddress, port, portonvif, portrtsp, rtspauthrequired, isdummy, dummyoption, manufacturer, devicemodel, firmwareversion, serialnumber, hardwareid) 
                        VALUES
                        (@DeviceName, @Zone, @UserName, @Password, @IpAddress, @Port, @PortOnvif, @PortRtsp, @RtspAuthRequired, @IsDummy, @DummyOption, @Manufacturer, @DeviceModel, @FirmwareVersion, @SerialNumber, @HardwareId)", dapper);

                            insertedRecord++;
                        }
                        transaction.Commit();
                    }
                    _log.Info($"({commitResult}) rows was inserted in DB[{table}])", true);
                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveCameraDevices)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveCameraDevices)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task UpdateCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    var table = CAMERA_DEVICE_TABLE;

                    if (model.Zone == null) throw new Exception($"CameraDevice does not have 'zone' property.");

                    var dapper = new CameraDeviceDapper(model);
                    commitResult = await _conn.ExecuteAsync($@"UPDATE {table}  
                                                              SET DeviceName = @DeviceName, 
                                                                  Zone = @Zone, 
                                                                  UserName = @UserName, 
                                                                  Password = @Password, 
                                                                  IpAddress = @IpAddress, 
                                                                  Port = @Port, 
                                                                  PortOnvif = @PortOnvif, 
                                                                  PortRtsp = @PortRtsp, 
                                                                  RtspAuthRequired = @RtspAuthRequired, 
                                                                  IsDummy = @IsDummy, 
                                                                  DummyOption = @DummyOption, 
                                                                  Manufacturer = @Manufacturer, 
                                                                  DeviceModel = @DeviceModel, 
                                                                  FirmwareVersion = @FirmwareVersion, 
                                                                  SerialNumber = @SerialNumber, 
                                                                  HardwareId = @HardwareId 
                                                              WHERE Id = @Id", dapper);

                    _log.Info($"({commitResult}) rows was updated in DB[{table}] : {model}", true);
                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveCameraDevice)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveCameraDevice)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task DeleteCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = CAMERA_DEVICE_TABLE;

                    await DeleteRecordOrTable(table, model.DeviceName, "devicename");

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteCameraDevice)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteCameraDevice)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public async Task<ICameraZoneModel> FetchCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       CAMERA_ZONE_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {CAMERA_ZONE_TABLE} WHERE name = '{model.Name}'";

                var fetchedModel = (await _conn.QueryAsync<CameraZoneModel>(sql)).FirstOrDefault();

                tcs?.SetResult(true);
                return fetchedModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchCameraZone)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchCameraZone)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task FetchCameraZones(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                    await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       CAMERA_ZONE_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {CAMERA_ZONE_TABLE}";
                var commitResult = 0;

                foreach (var model in (await _conn.QueryAsync<CameraZoneModel>(sql)))    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchCameraZones)}의 테스크가 강제 종료 되었습니다.");

                    _cameraZoneProvider.Add(model);
                    commitResult++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{CAMERA_ZONE_TABLE}].", true);
                tcs?.SetResult(true);
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchCameraZones)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchCameraZones)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
            }
        }

        

        public Task<ICameraZoneModel> SaveCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            int commitResult = 0;
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    var table = CAMERA_ZONE_TABLE;

                    commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                                    (name, description) VALUES (@Name, @Description)", model);

                    _log.Info($"({commitResult}) rows was inserted in DB[{table}] : {model.Name}({model.Description})");

                    var fetchedModel = await FetchCameraZone(model, token);
                    if (fetchedModel == null) throw new Exception($"Fail to fetch {model.Name} from {table}");

                    tcs?.SetResult(true);
                    return fetchedModel;
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveCameraZone)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveCameraZone)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
            });
        }

        public Task SaveCameraZones(CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = CAMERA_ZONE_TABLE;

                    var count = Convert.ToInt32(await _conn.ExecuteScalarAsync($@"SELECT COUNT(*) FROM {table}"));

                    if (count > 0)
                    {
                        commitResult = await _conn.ExecuteAsync($@"DELETE FROM {table}");

                        _log.Info($"DELETE {table} for saving new Data in DB", true);
                        if (!(commitResult > 0))
                            throw new Exception($"Raised exception during deleting Table({table}).");
                    }

                    int insertedRecord = 0;
                    using (var transaction = _conn.BeginTransaction())
                    {
                        foreach (var model in _cameraZoneProvider)
                        {
                            if (token.IsCancellationRequested) throw new TaskCanceledException();

                            commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                                            (name, description) VALUES (@Name, @Description)", model);

                            insertedRecord++;
                        }
                        transaction.Commit();
                    }
                    _log.Info($"({commitResult}) rows was inserted in DB[{table}])", true);

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveCameraZones)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveCameraZones)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task DeleteCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = CAMERA_ZONE_TABLE;

                    await DeleteRecordOrTable(table, model.Id.ToString());

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteCameraZone)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteCameraZone)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }


        public async Task<IUserModel> FetchUser(ILoginUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       USER_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {USER_TABLE} WHERE username = '{model.Username}' AND password = '{model.Password}'";
                
                var fetchedModel = (await _conn.QueryAsync<UserModel>(sql)).FirstOrDefault();
                if (fetchedModel == null) throw new Exception(message: $"{model.Username} is not exist.");

                var createdModel = new UserModel(fetchedModel);

                tcs?.SetResult(true);
                return createdModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchUser)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchUser)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<IUserModel> FetchUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       USER_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {USER_TABLE} WHERE username = '{model.Username}' AND password = '{model.Password}'";

                var fetchedModel = (await _conn.QueryAsync<UserModel>(sql)).FirstOrDefault();
                if (fetchedModel == null) throw new Exception(message: $"{model.Username} is not exist.");

                var createdModel = new UserModel(fetchedModel);

                tcs?.SetResult(true);
                return createdModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchUser)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchUser)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }


        public async Task<List<IUserModel>> FetchUsers(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                    await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       USER_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {USER_TABLE}";

                var commitResult = 0;
                List<IUserModel> models = new List<IUserModel>();

                foreach (var model in (await _conn.QueryAsync<UserModel>(sql)))    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchUsers)}의 테스크가 강제 종료 되었습니다.");

                    var createdModel = new UserModel(model);

                    models.Add(createdModel);
                    commitResult++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{USER_TABLE}].", true);

                tcs?.SetResult(true);
                return models;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchUsers)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchUsers)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }



        public Task<IUserModel> SaveUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    ///////////////////////////////////////////////////////////////////
                    //                       USER_TABLE
                    ///////////////////////////////////////////////////////////////////
                    var table = USER_TABLE;

                    // DB에서 devicename 혹은 ipaddress가 이미 있는지 확인
                    var existResult = await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT COUNT(1) FROM {table}
                                                                                WHERE username = @Username"
                                                                                , new { Username = model.Username});

                    if (existResult > 0)
                    {
                        throw new Exception($"Username({model.Username}) already exists in the database.");
                    }

                    commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                        (username, password, level, name, used) VALUES (@Username, @Password, @Level, @Name, @Used)", model);

                    _log.Info($"({commitResult}) rows was inserted in DB[{table}] : {model}", true);

                    var fetchedModel = await FetchUser(model);
                    if (fetchedModel == null) throw new Exception($"Fail to fetch {model.Username} from {table}");


                    tcs?.SetResult(true);
                    return fetchedModel;
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveUser)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveUser)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
            });
        }
        

        public Task UpdateUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    var table = USER_TABLE;

                    commitResult = await _conn.ExecuteAsync($@"UPDATE {table}  
                                                              SET password = @Password, 
                                                                  level = @Level, 
                                                                  name = @Name, 
                                                                  used = @Used 
                                                              WHERE username = @Username", model);

                    _log.Info($"({commitResult}) rows was updated in DB[{table}] : {model}", true);
                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(UpdateUser)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(UpdateUser)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task DeleteUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = USER_TABLE;

                    await DeleteRecordOrTable(table, model.Username, "username");

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteUser)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteUser)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }


        public async Task<ILoginSessionModel> FetchSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       USER_SESSION_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {USER_SESSION_TABLE} WHERE username = '{model.Username}' AND token = '{model.Token}'";

                var fetchedModel = (await _conn.QueryAsync<LoginSessionModel>(sql)).FirstOrDefault();
                if (fetchedModel == null) throw new Exception(message: $"{model.Username} is not exist.");

                var createdModel = new LoginSessionModel(fetchedModel);

                tcs?.SetResult(true);
                return createdModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchSession)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchSession)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }


        public async Task<List<ILoginSessionModel>> FetchSessions(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                    await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       USER_SESSION_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {USER_SESSION_TABLE}";

                var commitResult = 0;
                List<ILoginSessionModel> models = new List<ILoginSessionModel>();

                foreach (var model in (await _conn.QueryAsync<LoginSessionModel>(sql)))    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchSessions)}의 테스크가 강제 종료 되었습니다.");

                    var createdModel = new LoginSessionModel(model);

                    models.Add(createdModel);
                    commitResult++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{USER_SESSION_TABLE}].", true);

                tcs?.SetResult(true);
                return models;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchSessions)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchSessions)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }



        public Task<ILoginSessionModel> SaveSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    ///////////////////////////////////////////////////////////////////
                    //                       USER_SESSION_TABLE
                    ///////////////////////////////////////////////////////////////////
                    var table = USER_SESSION_TABLE;

                    // DB에서 devicename 혹은 ipaddress가 이미 있는지 확인
                    var existResult = await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT COUNT(1) FROM {table}
                                                                                WHERE token = @Token"
                                                                                , new { Token = model.Token });

                    if (existResult > 0)
                    {
                        throw new Exception($"Username({model.Username}), Token({model.Token}) already exists in the database.");
                    }

                    commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                        (username, password, clientid, token, mode, expired, created) VALUES (@Username, @Password, @ClientId, @Token, @Mode, @Expired, @Created)", model);

                    _log.Info($"({commitResult}) rows was inserted in DB[{table}] : {model}", true);

                    var fetchedModel = await FetchSession(model);
                    if (fetchedModel == null) throw new Exception($"Fail to fetch {model.Token} from {table}");


                    tcs?.SetResult(true);
                    return fetchedModel;
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveSession)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveSession)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
            });
        }


        public Task UpdateSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    var table = USER_SESSION_TABLE;

                    commitResult = await _conn.ExecuteAsync($@"UPDATE {table}  
                                                              SET expired = @Expired, 
                                                                  created = @Created 
                                                              WHERE token = @Token", model);

                    _log.Info($"({commitResult}) rows was updated in DB[{table}] : {model}", true);
                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(UpdateSession)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(UpdateSession)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task DeleteSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = USER_SESSION_TABLE;

                    await DeleteRecordOrTable(table, model.Token, "token");

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteSession)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteSession)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }




        public async Task<IEventModel> FetchEvent(IEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       EVENT_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {EVENT_TABLE} WHERE name = '{model.Name}'";

                var fetchedModel = (await _conn.QueryAsync<EventModel>(sql)).FirstOrDefault();
                if (fetchedModel == null) throw new Exception(message: $"{model.Name} is not exist.");

                var createdModel = new EventModel(fetchedModel);

                tcs?.SetResult(true);
                return createdModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchEvent)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchEvent)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<IEventModel> FetchEvent(int id, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       EVENT_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {EVENT_TABLE} WHERE id = '{id}'";

                var fetchedModel = (await _conn.QueryAsync<EventModel>(sql)).FirstOrDefault();
                if (fetchedModel == null) throw new Exception(message: $"Fetched event({id}) is not exist.");

                var createdModel = new EventModel(fetchedModel);

                tcs?.SetResult(true);
                return createdModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchEvent)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchEvent)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }


        public async Task<List<IEventModel>> FetchEvents(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                    await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       EVENT_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {EVENT_TABLE}";

                var commitResult = 0;
                List<IEventModel> models = new List<IEventModel>();

                foreach (var model in (await _conn.QueryAsync<EventModel>(sql)))    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchEvents)}의 테스크가 강제 종료 되었습니다.");

                    var createdModel = new EventModel(model);

                    models.Add(createdModel);
                    commitResult++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{USER_SESSION_TABLE}].", true);

                tcs?.SetResult(true);
                return models;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchEvents)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchEvents)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }



        public Task<IEventModel> SaveEvent(IEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    ///////////////////////////////////////////////////////////////////
                    //                       EVENT_TABLE
                    ///////////////////////////////////////////////////////////////////
                    var table = EVENT_TABLE;

                    // DB에서 devicename 혹은 ipaddress가 이미 있는지 확인
                    var existResult = await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT COUNT(1) FROM {table}
                                                                                WHERE name = @Name", new { Name = model.Name });

                    if (existResult > 0)
                    {
                        throw new Exception($"Event({model.Name}) already exists in the database.");
                    }

                    commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                        (name, type, cameraid,cameraname,  targetpreset, homepreset, duration) VALUES (@Name, @Type, @CameraId, @CameraName, @TargetPreset, @HomePreset, @Duration)", model);

                    _log.Info($"({commitResult}) rows was inserted in DB[{table}] : {model}", true);

                    var fetchedModel = await FetchEvent(model);
                    if (fetchedModel == null) throw new Exception($"Fail to fetch {model.Name} from {table}");


                    tcs?.SetResult(true);
                    return fetchedModel;
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
            });
        }


        public Task UpdateEvent(IEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    var table = EVENT_TABLE;

                    commitResult = await _conn.ExecuteAsync($@"UPDATE {table}  
                                                              SET type = @Type, 
                                                                  cameraid = @CameraId, 
                                                                  cameraname = @CameraName, 
                                                                  targetpreset = @TargetPreset,
                                                                  homepreset = @HomePreset,
                                                                  duration = @Duration
                                                              WHERE id = @Id", model);

                    _log.Info($"({commitResult}) rows was updated in DB[{table}] : {model}", true);
                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(UpdateEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(UpdateEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task DeleteEvent(IEventModel model, bool isForced = false, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            return Task.Run(async () =>
            {
                //bool tcsCompleted = false; // TaskCompletionSource 완료 여부 추적

                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = EVENT_TABLE;
                    var innerTcs = new TaskCompletionSource<bool>();
                    if (!isForced)
                    {
                        var list = await FetchActionEvents(model.Id, token);

                        if (list.Count() > 0) throw new Exception($"Event({model.Name}) has related action list({list.Count()}ea)");
                    }
                    else
                    {
                        await DeleteActionEvents(model.Id, token);
                    }

                    await DeleteRecordOrTable(table, model.Id.ToString(), "id");

                    tcs.SetResult(true);
                    //if (tcs != null && !tcs.Task.IsCompleted) // TaskCompletionSource의 상태 확인
                    //{
                    //    tcs.SetResult(true);
                    //    tcsCompleted = true;
                    //}
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteEvent)}: " + ex.Message, true);
                    tcs.SetException(ex);
                    //if (tcs != null && !tcs.Task.IsCompleted) // TaskCompletionSource의 상태 확인
                    //{
                    //    tcs.SetException(ex);
                    //    tcsCompleted = true;
                    //}
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteEvent)}: " + ex.Message, true);
                    tcs.SetException(ex);
                    //if (tcs != null && !tcs.Task.IsCompleted) // TaskCompletionSource의 상태 확인
                    //{
                    //    tcs.SetException(ex);
                    //    tcsCompleted = true;
                    //}
                }
            });
        }


        public async Task<IActionEventModel> FetchActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       EVENT_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {ACTION_EVENT_TABLE} 
                        WHERE eventid = @EventId 
                        AND created BETWEEN @CreatedStart AND @CreatedEnd";

                // Create a small time range to account for any precision issues
                var createdStart = model.Created.AddMilliseconds(-500);
                var createdEnd = model.Created.AddMilliseconds(500);

                var parameters = new { EventId = model.EventId, CreatedStart = createdStart, CreatedEnd = createdEnd };

                var fetchedModel = (await _conn.QueryAsync<ActionEventModel>(sql, parameters)).FirstOrDefault();
                if (fetchedModel == null) throw new Exception(message: $"Fetched action event({model.Id}) is not exist.");

                var createdModel = new ActionEventModel(fetchedModel);

                tcs?.SetResult(true);
                return createdModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchActionEvent)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchActionEvent)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }



        public async Task<List<IActionEventModel>> FetchActionEvents(DateTime from, DateTime to, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       EVENT_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {ACTION_EVENT_TABLE} WHERE created >= @From AND created < @To";

                var commitResult = 0;
                List<IActionEventModel> models = new List<IActionEventModel>();
                
                var parameters = new { From = from, To = to };
                foreach (var model in (await _conn.QueryAsync<ActionEventModel>(sql, parameters))) //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchActionEvents)}의 테스크가 강제 종료 되었습니다.");

                    var createdModel = new ActionEventModel(model);

                    models.Add(createdModel);
                    commitResult++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{USER_SESSION_TABLE}].", true);

                tcs?.SetResult(true);
                return models;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchActionEvents)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchActionEvents)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<List<IActionEventModel>> FetchActionEvents(int eventid, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                    await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       EVENT_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {ACTION_EVENT_TABLE} WHERE eventid = '{eventid}'";

                var commitResult = 0;
                List<IActionEventModel> models = new List<IActionEventModel>();

                foreach (var model in (await _conn.QueryAsync<ActionEventModel>(sql))?.ToList())    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchActionEvents)}의 테스크가 강제 종료 되었습니다.");

                    var createdModel = new ActionEventModel(model);

                    models.Add(createdModel);
                    commitResult++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{USER_SESSION_TABLE}].", true);

                tcs?.SetResult(true);
                return models;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchActionEvents)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchActionEvents)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }


        public Task<IActionEventModel> SaveActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    ///////////////////////////////////////////////////////////////////
                    //                       EVENT_TABLE
                    ///////////////////////////////////////////////////////////////////
                    var table = ACTION_EVENT_TABLE;

                    // 요청한 Action Event가 Event Table에 존재하는지 확인
                    var existResult = await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT COUNT(1) FROM {EVENT_TABLE}
                                                                                WHERE id = @Id", new { Id = model.EventId });

                    if (!(existResult > 0))
                    {
                        throw new Exception($"Event(ID: {model.EventId}) for action event doesn't exists in {EVENT_TABLE}.");
                    }

                    commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                        (eventid, message, status, created) VALUES (@EventId, @Message, @Status, @Created)", model);

                    _log.Info($"({commitResult}) rows was inserted in DB[{table}] : {model}", true);

                    var fetchedModel = await FetchActionEvent(model);
                    if (fetchedModel == null) throw new Exception($"Fail to fetch {model.Id} from {table}");


                    tcs?.SetResult(true);
                    return fetchedModel;
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveActionEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveActionEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
            });
        }


        public Task UpdateActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    var table = ACTION_EVENT_TABLE;

                    commitResult = await _conn.ExecuteAsync($@"UPDATE {table}  
                                                              SET message = @Message, 
                                                                  status = @Status
                                                              WHERE id = @Id", model);

                    _log.Info($"({commitResult}) rows was updated in DB[{table}] : {model}", true);
                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(UpdateActionEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(UpdateActionEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task DeleteActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = ACTION_EVENT_TABLE;


                    await DeleteRecordOrTable(table, model.Id.ToString(), "id");

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteActionEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteActionEvent)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }

        public Task DeleteActionEvents(int eventId, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = ACTION_EVENT_TABLE;


                    await DeleteRecordOrTable(table, eventId.ToString(), "eventid");

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteActionEvents)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteActionEvents)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }


        public async Task<IChannelModel> FetchChannel(IChannelModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       EVENT_TABLE
                ///////////////////////////////////////////////////////////////////
                string sql = @$"SELECT * FROM {REDIS_CHANNEL_TABLE} WHERE channel = '{model.Channel}'";

                var fetchedModel = (await _conn.QueryAsync<ChannelModel>(sql)).FirstOrDefault();
                if (fetchedModel == null) throw new Exception(message: $"Fetched channel({model.Channel}) is not exist.");

                var createdModel = new ChannelModel(fetchedModel);

                tcs?.SetResult(true);
                return createdModel;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchChannel)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchChannel)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<List<IChannelModel>> FetchChannels(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                    await _conn.OpenAsync();

                ///////////////////////////////////////////////////////////////////
                //                       USER_TABLE
                ///////////////////////////////////////////////////////////////////
                var sql = @$"SELECT * FROM {REDIS_CHANNEL_TABLE}";

                var commitResult = 0;
                List<IChannelModel> models = new List<IChannelModel>();

                foreach (var model in (await _conn.QueryAsync<ChannelModel>(sql)))    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchUsers)}의 테스크가 강제 종료 되었습니다.");

                    var createdModel = new ChannelModel(model);

                    models.Add(createdModel);
                    commitResult++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{USER_TABLE}].", true);

                tcs?.SetResult(true);
                return models;
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchChannels)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchChannels)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
                return null;
            }
        }



        public Task<IChannelModel> SaveChannel(IChannelModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            int commitResult = 0;

            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open)
                        await _conn.OpenAsync();

                    ///////////////////////////////////////////////////////////////////
                    //                       USER_TABLE
                    ///////////////////////////////////////////////////////////////////
                    var table = REDIS_CHANNEL_TABLE;

                    // DB에서 devicename 혹은 ipaddress가 이미 있는지 확인
                    var existResult = await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT COUNT(1) FROM {table}
                                                                                WHERE channel = @Channel"
                                                                                , new { Channel = model.Channel });

                    if (existResult > 0)
                    {
                        throw new Exception($"Channel({model.Channel}) already exists in the database.");
                    }

                    commitResult = await _conn.ExecuteAsync($@"INSERT INTO {table} 
                        (clientid, channel, ipaddress, created) VALUES (@ClientId, @Channel, @IpAddress, @Created)", model);

                    _log.Info($"({commitResult}) rows was inserted in DB[{table}] : {model}", true);

                    var fetchedModel = await FetchChannel(model);
                    if (fetchedModel == null) throw new Exception($"Fail to fetch {model.Channel} from {table}");


                    tcs?.SetResult(true);
                    return fetchedModel;
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(SaveChannel)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to insert DB data in {nameof(SaveChannel)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                    return null;
                }
            });
        }


        public Task DeleteChannel(IChannelModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (_conn.State != ConnectionState.Open) await _conn.OpenAsync();

                    var table = REDIS_CHANNEL_TABLE;

                    await DeleteRecordOrTable(table, model.Channel, "channel");

                    tcs?.SetResult(true);
                }
                catch (TaskCanceledException ex)
                {
                    _log.Error($"Task was cancelled in {nameof(DeleteChannel)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception for Task to delete DB data in {nameof(DeleteChannel)}: " + ex.Message, true);
                    tcs?.SetException(ex);
                }
            });
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////    COMMON PROCESS FOR DB MANAGING     ///////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////







        private Task DeleteRecordOrTable(string table, string id = default, string refer = "id")
        {
            try
            {
                if (id != null)
                {
                    DeleteRecordFromId(table, id, refer);
                }
                else
                {
                    DeleteTable(table);
                }
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception for Task to insert DB data in {nameof(DeleteRecordOrTable)}: " + ex.Message);
            }

            return Task.CompletedTask;
        }

        private async void DeleteTable(string table)
        {
            var commitResult = 0;
            var count = Convert.ToInt32(await _conn.ExecuteScalarAsync($@"SELECT COUNT(*) FROM {table}"));

            if (count > 0)
            {
                commitResult = await _conn.ExecuteAsync($@"DELETE FROM {table}");

                if (!(commitResult > 0)) throw new Exception($"Raised exception during deleting Table({table}).");
            }
            else
            {
                _log.Info($"No data from {table}");
            }
        }

        private async void DeleteRecordFromId(string table, string id, string refer)
        {
            var commitResult = 0;
            var count = Convert.ToInt32(await _conn.ExecuteScalarAsync($@"SELECT COUNT(*) 
                                                                        FROM {table}
                                                                        WHERE {refer} = '{id}'"));

            if (count > 0)
            {
                commitResult = await _conn.ExecuteAsync($@"DELETE FROM {table} 
                                                          WHERE {refer} = '{id}'");

                if (!(commitResult > 0)) throw new Exception($"Raised exception during deleting Table({table}).");
            }
            else
            {
                _log.Info($"Not Exist for Matched ID({id})");
            }
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private SQLiteConnection _conn;
        private ILogService _log;
        private DbSetupModel _setupModel;
        private CameraDeviceProvider _cameraDeviceProvider;
        private CameraZoneProvider _cameraZoneProvider;
        private ChannelClientProvider _channelProvider;
        private UserProvider _userProvider;
        private LoginSessionProvider _sessionProvider;
        private Events.Collection.Providers.EventProvider _eventProvider;
        private ActionEventProvider _actionEventProvider;
        private const string REDIS_CHANNEL_TABLE = "RedisChannel";

        private const string CAMERA_DEVICE_TABLE = "CameraDevice";
        private const string CAMERA_ZONE_TABLE = "CameraZone";

        private const string USER_TABLE = "User";
        private const string USER_SESSION_TABLE = "UserSession";

        private const string EVENT_TABLE = "Events";
        private const string ACTION_EVENT_TABLE = "ActionEvents";
        #endregion
    }
}
