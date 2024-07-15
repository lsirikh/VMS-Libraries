using Dotnet.Libraries.Base;
using Sensorway.Apis.Services;
using Sensorway.Apis.TranscodingServer.Providers;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Sensorway.Apis.TranscodingServer.Models.RequestModels;
using Sensorway.Apis.TranscodingServer.Models;
using Sensorway.Apis.TranscodingServer.Models.ResponseModels;

namespace Sensorway.Apis.TranscodingServer.Services
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 9:33:09 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    internal class TranscodingService : ITranscodingService
    {
        #region - Ctors -
        public TranscodingService(ILogService log
                                , IApiService apiService
                                , MediaProvider mediaProvider
                                , SessionProvider sessionProvider
                                , ServerConfigModel configModel)
        {
            _log = log;
            _apiService = apiService;
            _mediaProvider = mediaProvider;
            _sessionProvider = sessionProvider;
            _configModel = configModel;
        }
        #endregion
        #region - Implementation of Interface -
        public async Task ExecuteAsync(CancellationToken token = default)
        {
            await processGetConfig();
            await getSessionProvider();
            await getMediaProvider();
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
        public async Task<string> RegisterRtsp(RegisterRtspRequest model, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"add";
                var json = JsonConvert.SerializeObject(model);
                var response = await _apiService.PostRequest(json, url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<string> UnregisterRtsp(UnregisterRtspRequest model, TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"remove";
                var json = JsonConvert.SerializeObject(model);
                var response = await _apiService.PostRequest(json, url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<string> GetConfig(TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"get-config";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<string> GetSession(TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"get-sessions";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        public async Task<string> GetMedia(TaskCompletionSource<bool> tcs = null)
        {
            try
            {
                var url = $"get-medias";
                var response = await _apiService.GetRequest(url);
                return await ResponseProcess(response, tcs);
            }
            catch (Exception ex)
            {
                tcs?.SetException(ex);
                return null;
            }
        }

        private async Task processGetConfig()
        {
            try
            {
                var tcs = new TaskCompletionSource<bool>();
                var json = await GetConfig(tcs);
                var result = await tcs.Task;
                if (!result) throw new Exception(message: $"Fail to execute {nameof(processGetConfig)} in {nameof(TranscodingService)}");

                if (json != null)
                {
                    var globalConfig = JsonConvert.DeserializeObject<ServerConfigModel>(json);
                    _configModel.update(globalConfig);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, true);
            }

        }

        private async Task getSessionProvider()
        {
            try
            {
                var tcs = new TaskCompletionSource<bool>();
                var json = await GetSession(tcs);
                var result = await tcs.Task;
                _sessionProvider.Clear();
                if (!result) throw new Exception(message: $"Fail to execute {nameof(getSessionProvider)} in {nameof(TranscodingService)}");

                if (json != null)
                {
                    var response = JsonConvert.DeserializeObject<GetSessionResponse>(json);
                    if (response.Result != "SUCCESS") return;
                    
                    foreach (var item in response.List)
                    {
                        _sessionProvider.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, true);
            }
        }

        private async Task getMediaProvider()
        {
            try
            {
                var tcs = new TaskCompletionSource<bool>();
                var json = await GetMedia(tcs);
                var result = await tcs.Task;
                _mediaProvider.Clear();
                if (!result) throw new Exception(message: $"Fail to execute {nameof(getMediaProvider)} in {nameof(TranscodingService)}");

                if (json != null)
                {
                    var response = JsonConvert.DeserializeObject<GetMediaResponse>(json);
                    if (response.Result != "SUCCESS") return;

                    foreach (var item in response.List)
                    {
                        _mediaProvider.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, true);
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
            catch (Exception)
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
                if (response == null) throw new ArgumentNullException(nameof(response));
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
                else if (response.StatusCode == HttpStatusCode.BadRequest)
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
        #endregion
        #region - Attributes -
        private ILogService _log;
        private IApiService _apiService;
        private MediaProvider _mediaProvider;
        private SessionProvider _sessionProvider;
        private ServerConfigModel _configModel;
        #endregion
    }
}