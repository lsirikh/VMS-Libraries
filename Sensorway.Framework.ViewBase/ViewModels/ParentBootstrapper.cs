using Caliburn.Micro;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System;
using Autofac;
using IContainer = Autofac.IContainer;
using Autofac.Features.Metadata;
using Sensorway.Framework.ViewBase.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Dotnet.Libraries.Base;

namespace Sensorway.Framework.ViewBase.ViewModels
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/2/2024 1:28:53 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public abstract class ParentBootstrapper<T> : BootstrapperBase
    {

        #region - Ctors -
        public ParentBootstrapper()
        {
            CancellationTokenSourceHandler = new CancellationTokenSource();
            _log = new LogService();
            string projectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

            _log.Info($"############### Program{projectName} was started. ###############");
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected abstract Task Start();
        protected abstract Task Stop();
        protected abstract void ConfigureContainer(ContainerBuilder builder);

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            await Start();
        }

        protected override async void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
            await Stop();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterBaseType(builder);
            builder.RegisterType<T>().SingleInstance();

            ConfigureContainer(builder);
            _container = builder.Build();
        }


        private void RegisterBaseType(ContainerBuilder builder)
        {
            builder.RegisterType<WindowManager>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<EventAggregator>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterInstance(_log).As<ILogService>().SingleInstance();
        }

        protected override object GetInstance(Type service, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (Container.IsRegistered(service))
                    return Container.Resolve(service);
            }
            else
            {
                if (Container.IsRegisteredWithKey(key, service))
                    return Container.ResolveKeyed(key, service);
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", key ?? service.Name));

        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Container.Resolve(typeof(IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            Container.InjectProperties(instance);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        static public IContainer Container => _container;
        protected CancellationTokenSource CancellationTokenSourceHandler { get; }
        #endregion
        #region - Attributes -
        static private IContainer _container;
        protected ILogService _log;
        #endregion
    }
}
