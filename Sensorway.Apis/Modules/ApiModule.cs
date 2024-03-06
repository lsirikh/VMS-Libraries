using Autofac;
using Dotnet.Libraries.Base;
using Sensorway.Apis.Models;
using Sensorway.Apis.Services;

namespace Sensorway.Apis.Modules
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/8/2024 11:11:47 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class ApiModule : Module
    {

        #region - Ctors -
        public ApiModule(ILogService log = default)
        {
            _log = log;
            _setup = new ApiSetupModel();
        }

        public ApiModule(ILogService log, ApiSetupModel setup)
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

            //builder.Register(ctx =>
            //{
            //    _log?.Info($"{nameof(ApiModule)} is trying to create a single {nameof(ApiService)} instance.");
            //    return new ApiService(_log, _setup);
            //}).As<IApiService>().As<IService>()
            //.SingleInstance()
            //.WithMetadata("Order", 1);
            _log?.Info($"{nameof(ApiModule)} is trying to create a single {nameof(ApiService)} instance.");
            builder.RegisterType<ApiService>().AsImplementedInterfaces().SingleInstance().WithMetadata("Order", 2);
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
        private ApiSetupModel _setup;
        #endregion
    }
}
