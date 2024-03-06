using Dotnet.Libraries.Base;
using Newtonsoft.Json;
using Sensorway.Apis.MediaMTX.Models;
using Sensorway.Apis.MediaMTX.Providers;
using Sensorway.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sensorway.Apis.MediaMTX.Services
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/8/2024 1:49:06 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    internal class MediaMTXService : IMediaMTXService
    {
        #region - Ctors -
        public MediaMTXService(ILogService log
                                , IApiService apiService
                                , PathConfigProvider pathConfigProvider
                                , PathProvider pathProvider
                                , GlobalConfigurationModel globalConfiguration)

        {
            _log = log;
            _apiService = apiService;
            _pathConfigProvider = pathConfigProvider;
            _pathProvider = pathProvider;
            _globalConfiguration = globalConfiguration;
        }
        #endregion
        #region - Implementation of Interface -
        public async Task ExecuteAsync(CancellationToken token = default)
        {
            await BuildLookupTabel();
            await processGetGlobalConfiguration();
        }

        

        public Task StopAsync(CancellationToken token = default)
        {
            return Task.CompletedTask;
        }
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private async Task getConfigProvider()
        {
            try
            {
                var tcs = new TaskCompletionSource<bool>();
                var json = await GetAllPathConfiguration(tcs);
                var result = await tcs.Task;
                _pathConfigProvider.Clear();
                if (!result) throw new Exception(message: $"Fail to execute {nameof(getConfigProvider)} in {nameof(MediaMTXService)}");

                if (json != null)
                {
                    var pathConfList = JsonConvert.DeserializeObject<PathConfigurationListModel>(json);

                    foreach (var item in pathConfList.Items)
                    {
                        _pathConfigProvider.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, true);
            }
        }

        private async Task getPathProvider()
        {
            try
            {
                var tcs = new TaskCompletionSource<bool>();
                var json = await GetAllPath(tcs);
                var result = await tcs.Task;
                _pathProvider.Clear();
                if (!result) throw new Exception(message: $"Fail to execute {nameof(getPathProvider)} in {nameof(MediaMTXService)}");

                if (json != null)
                {
                    var pathConfList = JsonConvert.DeserializeObject<PathListModel>(json);

                    foreach (var item in pathConfList.Items)
                    {
                        _pathProvider.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, true);
            }
        }

        private async Task processGetGlobalConfiguration()
        {
            try
            {
                var tcs = new TaskCompletionSource<bool>();
                var json = await GetGlobalConfiguration(tcs);
                var result = await tcs.Task;
                if (!result) throw new Exception(message:$"Fail to execute {nameof(GetGlobalConfiguration)} in {nameof(MediaMTXService)}");

                if (json != null)
                {
                    var globalConfig = JsonConvert.DeserializeObject<GlobalConfigurationModel>(json);
                    _globalConfiguration.update(globalConfig);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, true);
            }
            
        }

        public async Task BuildLookupTabel()
        {
            try
            {
              
                await Task.WhenAll(getConfigProvider(), getPathProvider());

                LookupTable = (from path in _pathProvider
                              join config in _pathConfigProvider
                              on path.Name equals config.Name into mediaGroup
                              from config in mediaGroup.DefaultIfEmpty()
                              select new LookupModel
                              {
                                  Path = (PathModel)path,
                                  PathConfiguration = (PathConfigurationModel)config,
                              }).Distinct().ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Global Configuration 설정 정보 API로 받아오기
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetGlobalConfiguration(TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                var url = "v3/config/global/get";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (System.Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        /// <summary>
        /// Global Configuration 정보 API로 설정하기
        /// </summary>
        /// <param name="content"></param>
        /// <param name="tcs"></param>
        /// <returns></returns>
        public async Task<bool> SetGlobalConfiguration(string content)
        {
            try
            {
                var url = "v3/config/global/patch";
                var response = await _apiService.PatchRequest(url, content);
                return await ResponseProcess(response); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Path Configuration 정보 API로 받아오기
        /// </summary>
        /// <param name="tcs"></param>
        /// <returns></returns>
        public async Task<string> GetPathConfiguration(TaskCompletionSource<bool> tcs = default)
        {
            try
            {
                var url = "v3/config/pathdefaults/get";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        /// <summary>
        /// Path Configuration 설정 정보 API로 설정하기 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="tcs"></param>
        /// <returns></returns>
        public async Task<bool> SetPathConfiguration(string content)
        {
            try
            {
                var url = "v3/config/pathdefaults/patch";
                var response = await _apiService.PatchRequest(url, content);
                return await ResponseProcess(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// name based Path Configuration 정보 요청
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tcs"></param>
        /// <returns></returns>
        public async Task<string> GetPathConfiguration(string name, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"v3/config/paths/get/{name}";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<string> GetAllPathConfiguration(TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"v3/config/paths/list";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<bool> AddPathConfigurateion(PathConfigurationModel model)
        {
            try
            {
                var url = $"v3/config/paths/add/{model.Name}";
                var json = JsonConvert.SerializeObject(model);
                var response = await _apiService.PostRequest(json, url);
                return await ResponseProcess(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePathConfigurateion(string name)
        {
            try
            {
                var url = $"v3/config/paths/delete/{name}";
                var response = await _apiService.DeleteRequest(url);
                return await ResponseProcess(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PatchPathConfiguration(string name, string json)
        {
            try
            {
                var url = $"v3/config/paths/patch/{name}";
                var response = await _apiService.PatchRequest(url, json);
                return await ResponseProcess(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ReplacePathConfiguration(PathConfigurationModel model)
        {
            try
            {
                var url = $"v3/config/paths/replace/{model.Name}";
                var json = JsonConvert.SerializeObject(model);
                var response = await _apiService.PostRequest(json, url);
                return await ResponseProcess(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetPath(string name, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"v3/paths/get/{name}";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<string> GetAllPath(TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"v3/paths/list";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        /// <summary>
        /// Reponse 기능 공통 처리 메소드 
        /// </summary>
        /// <param name="response"></param>
        /// <returns>결과의 참/거짓으로 나타남</returns>
        private Task<bool> ResponseProcess(HttpResponseMessage response)
        {
            try
            {
                if (response == null) throw new ArgumentNullException(nameof(response));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _log?.Info($"Api account was not authorized![{response?.ReasonPhrase}]");

                    return Task.FromResult(false);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _log?.Info($"Api Connection was failure![{response?.ReasonPhrase}]");

                    return Task.FromResult(false);
                }
                else
                {
                    return Task.FromResult(false);
                }

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Response 기능 공통 처리 메소드
        /// </summary>
        /// <param name="response"></param>
        /// <param name="tcs"></param>
        /// <returns>결과의 데이터를 string으로 구현함(Json형식)</returns>
        private async Task<string> ResponseProcess(HttpResponseMessage response, TaskCompletionSource<bool> tcs)
        {
            try
            {
                if(response == null) throw new ArgumentNullException(nameof(response));
                string body = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    body = await response.Content.ReadAsStringAsync();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _log?.Info($"Api account was not authorized![{response?.ReasonPhrase}]");
                    body = await response?.Content?.ReadAsStringAsync();

                    tcs?.SetResult(false);
                    return body;
                }
                else if(response.StatusCode == HttpStatusCode.BadRequest)
                {
                    _log?.Info($"Api Connection was failure![{response?.ReasonPhrase}]");
                    body = await response?.Content?.ReadAsStringAsync();

                    tcs?.SetResult(false);
                    return body;
                }
                else
                {
                    tcs?.SetResult(false);
                    return body;
                }

                tcs?.SetResult(true);
                return body;
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }


        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public IEnumerable<LookupModel> LookupTable { get; private set; }
        #endregion
        #region - Attributes -
        private IApiService _apiService;
        private PathConfigProvider _pathConfigProvider;
        private PathProvider _pathProvider;
        private GlobalConfigurationModel _globalConfiguration;
        private ILogService _log;
        #endregion
    }
}
