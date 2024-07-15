using Autofac;
using Dotnet.Libraries.Base;
using Sensorway.Api.Server.Models;
using Sensorway.Api.Server.Services;
using System;
using System.Xml.Linq;

namespace Sensorway.Api.Server.Modules
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/31/2024 10:48:09 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ApiServerModule : Module
    {
        #region - Ctors -
        public ApiServerModule(ILogService log =  default)
        {
            _log = log;
            _setup = new ApiServerSetupModel();
        }
        public ApiServerModule(ILogService log = default, ApiServerSetupModel setup = default)
        {
            _log = log;
            _setup = setup;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_setup).AsSelf().SingleInstance();

            builder.Register( ctx =>
            {
                var server = new ApiServerService(_log, _setup);
                server.ServerActivate();
                return server;
            }).As<IApiServerService>().SingleInstance();
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private ILogService _log;
        private ApiServerSetupModel _setup;
        #endregion
    }
}