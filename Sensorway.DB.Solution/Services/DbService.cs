using Dapper;
using Dotnet.Libraries.Base;
using Dotnet.OnvifSolution.Base.Enums;
using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Dappers;
using Dotnet.OnvifSolution.Base.Models.Extends;
using Dotnet.OnvifSolution.Collection.Providers;
using Sensorway.DB.Solution.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SQLite;
using System.Diagnostics;
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
                        , CameraZoneProvider zoneProvider)
        {
            _log = log;
            _setupModel = setupModel;
            _cameraDeviceProvider = cameraPovider;
            _cameraZoneProvider = zoneProvider;
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
        //public IDbService Connect(DbSetupModel setupModel)
        //{
        //    try
        //    {
        //        var dataSource = ((Func<string, string, int, string>)(
        //            (pathDatabase, nameDatabase, version) =>
        //            {
        //                if (!Directory.CreateDirectory(pathDatabase).Exists)
        //                    throw new DirectoryNotFoundException();
        //                return $@"Data Source={Path.Combine(pathDatabase, nameDatabase)}; Version={version};";

        //            }))(Path.Combine(Environment.CurrentDirectory, setupModel.PathDatabase), setupModel.NameDatabase, setupModel.Version);

        //        _conn = new SQLiteConnection(dataSource);
        //        return this;
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Error($"Raised {nameof(Exception)} in {nameof(Connect)} of {nameof(DbService)} : {ex}");
        //        return null;
        //    }
        //}

        //public Task<IDbService> Connect(DbSetupModel setupModel)
        //{
        //    try
        //    {
        //        var dataSource = ((Func<string, string, int, string>)(
        //            (pathDatabase, nameDatabase, version) =>
        //            {
        //                if (!Directory.CreateDirectory(pathDatabase).Exists)
        //                    throw new DirectoryNotFoundException();
        //                return $@"Data Source={Path.Combine(pathDatabase, nameDatabase)}; Version={version};";

        //            }))(Path.Combine(Environment.CurrentDirectory, setupModel.PathDatabase), setupModel.NameDatabase, setupModel.Version);

        //        _conn = new SQLiteConnection(dataSource);
        //        return Task.FromResult(this as IDbService);
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Error($"Raised {nameof(Exception)} in {nameof(Connect)} of {nameof(DbService)} : {ex}");
        //        return Task.FromResult(null as IDbService);
        //    }
        //}

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
            
            await FetchCameraDevices(token);
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

        

        public async Task FetchCameraDevices(CancellationToken token = default, TaskCompletionSource<bool> tcs = default)
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

                foreach (var model in (await _conn.QueryAsync<CameraDeviceDapper>(sql)))    //1
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException($"{nameof(FetchCameraDevices)}의 테스크가 강제 종료 되었습니다.");
                    
                    var zone = _cameraZoneProvider.Where(entity => entity.Id == model.Zone).FirstOrDefault();
                    var camera = new CameraDeviceModel(model);
                    camera.Zone = zone as CameraZoneModel;

                    _cameraDeviceProvider.Add(camera);
                    commitResult ++;
                };
                _log.Info($"({commitResult}) rows was fetched in DB[{CAMERA_DEVICE_TABLE}].", true);
                tcs?.SetResult(true);
            }
            catch (TaskCanceledException ex)
            {
                _log.Error($"Raised {nameof(TaskCanceledException)} in {nameof(FetchCameraDevices)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
            }
            catch (Exception ex)
            {
                _log.Error($"Raised {nameof(Exception)} in {nameof(FetchCameraDevices)} of {nameof(DbService)} : {ex}");
                tcs?.SetException(ex);
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

                    if(model.Zone == null) throw new Exception($"CameraDevice does not have 'zone' property.");

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
        private const string CAMERA_DEVICE_TABLE = "CameraDevice";
        private const string CAMERA_ZONE_TABLE = "CameraZone";
        #endregion
    }
}
