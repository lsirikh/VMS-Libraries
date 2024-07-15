using Autofac;
using Sensorway.DB.Solution.Models;
using Sensorway.DB.Solution.Services;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System;
using Dotnet.OnvifSolution.Collection.Providers;
using Dotnet.Libraries.Base;
using Sensorway.Accounts.Collection.Providers;
using Sensorway.Events.Collection.Providers;

namespace Sensorway.DB.Solution.Modules
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/5/2024 1:36:43 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class DbModule : Module
    {
        #region - Ctors -
        public DbModule(ILogService log = default)
        {
            _log = log;
        }
        #endregion
        #region - Implementation of Interface -
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                var setupModel = new DbSetupModel();
                builder.RegisterInstance(setupModel).AsSelf().SingleInstance();
                builder.RegisterType<CameraDeviceProvider>().SingleInstance();
                builder.RegisterType<CameraZoneProvider>().SingleInstance();
                builder.RegisterType<ChannelClientProvider>().SingleInstance();
                builder.RegisterType<UserProvider>().SingleInstance();
                builder.RegisterType<LoginSessionProvider>().SingleInstance();
                builder.RegisterType<EventProvider>().SingleInstance();
                builder.RegisterType<ActionEventProvider>().SingleInstance();

                builder.RegisterType<DbService>().AsImplementedInterfaces()
                    .SingleInstance().WithMetadata("Order", 2);

                //builder.Register(ctx =>
                //{
                //    _log?.Info($"{nameof(DbModule)} is trying to create a single {nameof(DbService)} instance by connecting to the DB server.");
                //    return (new DbService()).Connect(setupModel);
                //}).As<IDbService>().As<IService>()
                //.SingleInstance()
                //.WithMetadata("Order", 2);
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region - Overrides -
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
