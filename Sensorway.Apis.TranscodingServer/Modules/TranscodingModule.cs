using Autofac;
using Dotnet.Libraries.Base;
using Sensorway.Apis.Models;
using Sensorway.Apis.Modules;
using Sensorway.Apis.TranscodingServer.Models;
using Sensorway.Apis.TranscodingServer.Providers;
using Sensorway.Apis.TranscodingServer.Services;
using System;

namespace Sensorway.Apis.TranscodingServer.Modules
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 9:28:48 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class TranscodingModule : Module
    {
        #region - Ctors -
        public TranscodingModule(ILogService log = default)
        {
            _log = log;
            _setup = new TranscodingSetupModel();
        }

        public TranscodingModule(ILogService log, TranscodingSetupModel setup)
        {
            _setup = setup;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApiModule(_log
                , new ApiSetupModel()
                {
                    IpAddress = _setup.IpAddress,
                    Port = _setup.Port,
                    Username = _setup.Username,
                    Password = _setup.Password,
                }));
            builder.RegisterType<MediaProvider>().SingleInstance();
            builder.RegisterType<SessionProvider>().SingleInstance();

            _log?.Info($"{nameof(TranscodingModule)} is trying to create a single {nameof(TranscodingService)} instance.");
            builder.RegisterType<TranscodingService>().AsImplementedInterfaces()
                .SingleInstance().WithMetadata("Order", 3);
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
        private TranscodingSetupModel _setup;
        #endregion
    }
}