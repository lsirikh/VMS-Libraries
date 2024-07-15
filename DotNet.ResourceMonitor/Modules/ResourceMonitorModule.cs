using Autofac;
using Dotnet.Libraries.Base;
using DotNet.ResourceMonitor.Models;
using DotNet.ResourceMonitor.Services;

namespace DotNet.ResourceMonitor.Modules
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/17/2024 8:35:55 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class ResourceMonitorModule : Module
    {
        #region - Ctors -
        public ResourceMonitorModule(ILogService log = default)
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
                builder.RegisterType<ResourceMonitorService>().AsImplementedInterfaces().SingleInstance().WithMetadata("Order", 5);
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
