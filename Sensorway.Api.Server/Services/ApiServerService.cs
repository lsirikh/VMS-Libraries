using Dotnet.Libraries.Base;
using Sensorway.Api.Server.Enums;
using Sensorway.Api.Server.Helpers;
using Sensorway.Api.Server.Models;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Api.Server.Services
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/30/2024 6:00:06 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ApiServerService : IApiServerService
    {
        #region - Ctors -
        public ApiServerService(ILogService log
                                , ApiServerSetupModel setupModel)
        {
            _log = log;
            _setupModel = setupModel;
        }
        #endregion
        #region - Implementation of Interface -
        public void ServerActivate()
        {
            try
            {

                if (_httpListener != null)
                    _httpListener.Close();

                Status = EnumApiServerStatus.PREPARING;

                _cts = new CancellationTokenSource();

                _httpListener = new HttpListener();
                _httpListener.Prefixes.Add(string.Format($"http://{_setupModel.IpAddress}:{_setupModel.Port}/"));


            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(ServerActivate)} of {nameof(ApiServerService)} : {ex.Message}");
            }
        }

        public void ServerDeactivate()
        {
            try
            {
                if (_httpListener.IsListening)
                {
                    Status = EnumApiServerStatus.CLOSING;
                    ///HttpListener(Api Server) Stop
                    _httpListener.Stop();

                }


                Status = EnumApiServerStatus.DEACTIVATED;
                ///HttpListener(Api Server) Close
                _httpListener.Close();

            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(ServerDeactivate)} of {nameof(ApiServerService)} : {ex.Message}");
            }
        }

        public Task ServerStart(CancellationToken token = default)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (!_httpListener.IsListening)
                    {
                        ///HttpListener(Api Server) Starts
                        _httpListener.Start();
                        Status = EnumApiServerStatus.ACTIVATED;


                        while (_httpListener != null && !_cts.IsCancellationRequested)
                        {
                            ///Context 데이터 가져오기
                            HttpListenerContext context = await _httpListener.GetContextAsync();
                            
                            ReceiveEvent?.Invoke(this, new ReceiveEventArgs(context));

                            //context.Response.Close();
                            //await Task.Delay(100);
                        }
                        throw new ObjectDisposedException("ExceptionWithEndRequest");
                    }
                }
                catch (HttpListenerException)
                {
                    Status = EnumApiServerStatus.DEACTIVATED;
                }
                catch (ObjectDisposedException)
                {
                    Status = EnumApiServerStatus.DEACTIVATED;
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception in {nameof(ServerStart)} of {nameof(ApiServerService)} : {ex.Message}");
                }

            }, token);
        }
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public Task SendResponse(HttpListenerResponse response, string json = default, bool isSuccess = true)
        {
            return Task.Run(async () =>
            {
                try
                {
                    response.ContentType = "Application/json";
                    byte[] buffer = new byte[] { };
                    if (isSuccess)
                    {
                        response.StatusCode = 200;
                        response.StatusDescription = "OK";
                        buffer = Encoding.UTF8.GetBytes(json);
                    }
                    else
                    {
                        response.StatusCode = 404;
                        response.StatusDescription = "Fail";
                    }

                    using (Stream output = response.OutputStream)
                    {
                        await output.WriteAsync(buffer, 0, buffer.Length);
                        output.Close();
                    }
                }
                catch (Exception ex)
                {
                    _log.Error($"Raised Exception in {nameof(SendResponse)} of {nameof(ApiServerService)} : {ex.Message}");
                }
            });
        }

        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public EnumApiServerStatus Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        public HttpListener HttpListener
        {
            get { return _httpListener; }
            private set { _httpListener = value; }
        }
        #endregion
        #region - Attributes -
        public event Action StatusChanged;
        public event EventHandler ReceiveEvent;

        private ILogService _log;
        private ApiServerSetupModel _setupModel;
        private CancellationTokenSource _cts;
        private HttpListener _httpListener;
        private EnumApiServerStatus _status;

        #endregion
    }
}