using Autofac;
using Dotnet.Libraries.Base;
using Sensorway.Apis.MediaMTX.Models;
using Sensorway.Apis.MediaMTX.Providers;
using Sensorway.Apis.MediaMTX.Services;
using Sensorway.Apis.Models;
using Sensorway.Apis.Modules;
using Sensorway.Apis.Services;

namespace Sensorway.Apis.MediaMTX.Modules
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/8/2024 1:42:42 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class MediaMTXModule : Module
    {
        #region - Ctors -
        public MediaMTXModule(ILogService log = default)
        {
            _log = log;
            _setup = new MediaMTXSetup();
        }

        public MediaMTXModule(ILogService log, MediaMTXSetup setup)
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

            builder.RegisterModule(new ApiModule(_log, new ApiSetupModel
            {
                IpAddress = _setup.IpAddress,
                Port = _setup.Port,
                Username = _setup.Username,
                Password = _setup.Password,
            }, "MediaMTX"));

            builder.RegisterType<GlobalConfigurationModel>().SingleInstance();
            builder.RegisterType<PathConfigProvider>().SingleInstance();
            builder.RegisterType<PathProvider>().SingleInstance();

            _log?.Info($"{nameof(MediaMTXModule)} is trying to create a single {nameof(MediaMTXService)} instance.");
            builder.Register(build => new MediaMTXService(
                _log,
                build.ResolveNamed<IApiService>("MediaMTX"),
                build.Resolve<PathConfigProvider>(),
                build.Resolve<PathProvider>(),
                build.Resolve<GlobalConfigurationModel>()
            )).AsImplementedInterfaces().SingleInstance().WithMetadata("Order", 3);
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
        private MediaMTXSetup _setup;
        #endregion
    }
}
