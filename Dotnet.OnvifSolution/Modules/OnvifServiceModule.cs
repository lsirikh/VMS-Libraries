using Autofac;
using Dotnet.Libraries.Base;
using Dotnet.OnvifSolution.Services;

namespace Dotnet.OnvifSolution.Modules
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/7/2024 4:37:16 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class OnvifServiceModule : Module
    {
        #region - Ctors -
        public OnvifServiceModule(ILogService log = default)
        {
            _log = log;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                _log?.Info($"{nameof(OnvifServiceModule)} is trying to create a {nameof(DeviceService)} instance as InstancePerDependency.");
                builder.RegisterType<DeviceService>().As<IDeviceService>().InstancePerDependency();
            }
            catch
            {
                throw;
            }
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
        #endregion
    }
}
