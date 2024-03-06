using Caliburn.Micro;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/2/2024 1:53:16 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public abstract class BaseShellViewModel : Conductor<IScreen>
    {
        #region - Ctors -
        
        public BaseShellViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
        }

        public BaseShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        ~BaseShellViewModel()
        {
            _eventAggregator.Unsubscribe(this);
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            _eventAggregator.SubscribeOnUIThread(this);
            return base.OnActivateAsync(cancellationToken);
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            _eventAggregator.Unsubscribe(this);
            return base.OnDeactivateAsync(close, cancellationToken);
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
        protected IEventAggregator _eventAggregator;
        protected bool isFullScreen = default;
        #endregion
    }
}
