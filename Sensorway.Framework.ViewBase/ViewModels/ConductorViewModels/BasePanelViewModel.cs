using Caliburn.Micro;
using Sensorway.Framework.Models.Messages;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/28/2024 11:06:48 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class BasePanelViewModel : Conductor<IScreen>, IHandle<CloseAllMessageModel>, IBasePanelViewModel
    {
        #region - Ctors -

        public BasePanelViewModel()
        {
            _className = this.GetType().Name.ToString();
            _eventAggregator = IoC.Get<IEventAggregator>();
        }
        public BasePanelViewModel(IEventAggregator eventAggregator)
        {
            _className = this.GetType().Name.ToString();
            _eventAggregator = eventAggregator;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            try
            {
                base.OnActivateAsync(cancellationToken);
                Debug.WriteLine($"######### {_className} OnActivate!! #########");
                _eventAggregator?.SubscribeOnUIThread(this);
                _cancellationTokenSource = new CancellationTokenSource();
            }
            catch (Exception)
            {
            }

            return Task.CompletedTask;
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            try
            {
                base.OnDeactivateAsync(close, cancellationToken);
                Debug.WriteLine($"######### {_className} OnDeactivate!! #########");
                _eventAggregator?.Unsubscribe(this);
                if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
                    _cancellationTokenSource?.Cancel();
                _cancellationTokenSource?.Dispose();
                GC.Collect();
            }
            catch (Exception)
            {
            }

            return Task.CompletedTask;
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        public Task HandleAsync(CloseAllMessageModel message, CancellationToken cancellationToken)
        {
            return TryCloseAsync();
        }
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        protected string _className;
        protected IEventAggregator _eventAggregator;
        protected CancellationTokenSource _cancellationTokenSource;
        public const int ACTION_TOKEN_TIMEOUT = 5000;
        #endregion

    }
}
