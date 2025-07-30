using Dotnet.Libraries.Base;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sensorway.Apis.Services
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 4/14/2025 2:40:11 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    internal partial class ApiService : IApiService
    {
        #region - Ctors -
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        /// <summary>
        /// GET 요청을 보내면서, 필요한 헤더들을 Dictionary 형태로 추가할 수 있는 오버로드
        /// </summary>
        /// <param name="url">호출할 API의 상대 경로</param>
        /// <param name="customHeaders">추가로 전송할 헤더 목록</param>
        /// <param name="isAuthentication">기본 인증 사용 여부</param>
        /// <returns>서버 응답(HttpResponseMessage)</returns>
        public Task<HttpResponseMessage> GetRequest(
            string url,
            Dictionary<string, string> customHeaders,
            bool isAuthentication = false
        )
        {
            return Task.Run(async () =>
            {
                try
                {
                    HttpClientHandler handler = new HttpClientHandler();

                    if (isAuthentication && _setupModel != null)
                        handler.Credentials = new NetworkCredential(_setupModel.Username, _setupModel.Password);

                    using (HttpClient client = new HttpClient(handler))
                    {
                        // 타임아웃 설정
                        client.Timeout = TimeSpan.FromSeconds(TIMEOUT);

                        // 추가 헤더 설정
                        if (customHeaders != null)
                        {
                            foreach (var header in customHeaders)
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }

                        // GET 요청 URL 구성
                        var requestUri = new Uri($"http://{_setupModel.IpAddress}:{_setupModel.Port}/{url}");

                        // GET 요청 전송
                        return await client.GetAsync(requestUri);
                    }
                }
                catch (Exception ex)
                {
                    _log?.Error($"Raised {nameof(Exception)} in {nameof(GetRequest)}(customHeaders) of {nameof(ApiService)} : {ex}", true);
                    return null;
                }
            });
        }

        /// <summary>
        /// POST 요청을 보내면서, 필요한 헤더(Dictionary 형태)와 JSON 바디를 전송할 수 있는 오버로드
        /// </summary>
        /// <param name="url">호출할 API의 상대 경로</param>
        /// <param name="body">POST 요청에 포함될 JSON 문자열</param>
        /// <param name="customHeaders">추가로 전송할 헤더 목록</param>
        /// <param name="isAuthentication">기본 인증 사용 여부</param>
        /// <returns>서버 응답(HttpResponseMessage)</returns>
        public Task<HttpResponseMessage> PostRequest(
            string body,
            string url,
            Dictionary<string, string> customHeaders,
            bool isAuthentication = false
        )
        {
            return Task.Run(async () =>
            {
                try
                {
                    HttpClientHandler handler = new HttpClientHandler();

                    if (isAuthentication && _setupModel != null)
                        handler.Credentials = new NetworkCredential(_setupModel.Username, _setupModel.Password);

                    using (HttpClient client = new HttpClient(handler))
                    {
                        // 타임아웃 설정
                        client.Timeout = TimeSpan.FromSeconds(TIMEOUT);

                        // 추가 헤더 설정
                        if (customHeaders != null)
                        {
                            foreach (var header in customHeaders)
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }

                        // POST 요청 URL 구성
                        var requestUri = new Uri($"http://{_setupModel.IpAddress}:{_setupModel.Port}/{url}");

                        // JSON 바디 구성
                        var content = new StringContent(body, Encoding.UTF8, "application/json");

                        // POST 요청 전송
                        return await client.PostAsync(requestUri, content);
                    }
                }
                catch (Exception ex)
                {
                    _log?.Error($"Raised {nameof(Exception)} in {nameof(PostRequest)}(customHeaders) of {nameof(ApiService)} : {ex}", true);
                    return null;
                }
            });
        }

        /// <summary>
        /// DELETE 요청을 보내면서, 필요한 헤더(Dictionary 형태)를 추가할 수 있는 오버로드
        /// </summary>
        /// <param name="url">호출할 API의 상대 경로</param>
        /// <param name="customHeaders">추가로 전송할 헤더 목록</param>
        /// <param name="isAuthentication">기본 인증 사용 여부</param>
        /// <returns>서버 응답(HttpResponseMessage)</returns>
        public Task<HttpResponseMessage> DeleteRequest(
            string url,
            Dictionary<string, string> customHeaders,
            bool isAuthentication = false
        )
        {
            return Task.Run(async () =>
            {
                try
                {
                    HttpClientHandler handler = new HttpClientHandler();

                    if (isAuthentication && _setupModel != null)
                        handler.Credentials = new NetworkCredential(_setupModel.Username, _setupModel.Password);

                    using (HttpClient client = new HttpClient(handler))
                    {
                        // 타임아웃 설정
                        client.Timeout = TimeSpan.FromSeconds(TIMEOUT);

                        // 추가 헤더 설정
                        if (customHeaders != null)
                        {
                            foreach (var header in customHeaders)
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }

                        // DELETE 요청 URL 구성
                        var requestUri = new Uri($"http://{_setupModel.IpAddress}:{_setupModel.Port}/{url}");

                        // DELETE 요청 전송
                        return await client.DeleteAsync(requestUri);
                    }
                }
                catch (Exception ex)
                {
                    _log?.Error($"Raised {nameof(Exception)} in {nameof(DeleteRequest)}(customHeaders) of {nameof(ApiService)} : {ex}", true);
                    return null;
                }
            });
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}