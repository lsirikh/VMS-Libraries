﻿using Caliburn.Micro;
using Dotnet.Libraries.Base;
using Sensorway.Framework.Models.Defines;
using Sensorway.Framework.Models.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels
{
    public abstract class BaseViewModel<T> : Conductor<IScreen>
                                            , IHandle<CloseAllMessageModel>
                                            , IBaseViewModel<T> where T: IBaseModel
    {
        #region - Ctors -
        public BaseViewModel(IEventAggregator eventAggregator
                            , ILogService log)
        {
            _eventAggregator = eventAggregator;
            _log = log;
        }
        public BaseViewModel(T model)
        {
            _log = IoC.Get<ILogService>();
            _className = this.GetType().Name.ToString();
            _model = model;
        }

        public BaseViewModel(IEventAggregator eventAggregator, ILogService log, T model)
        {
            _model = model;
            _className = this.GetType().Name.ToString();
            _eventAggregator = eventAggregator;
            _log = log;
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
                _log.Info($"######### {_className} OnActivate!! #########");
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
                _log.Info($"######### {_className} OnDeactivate!! #########");
                _eventAggregator?.Unsubscribe(this);
                if(_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
                    _cancellationTokenSource?.Cancel();
                _cancellationTokenSource?.Dispose();
                GC.Collect();
            }
            catch (Exception )
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

        public T Model
        {
            get => _model;
            set { _model = value; NotifyOfPropertyChange(() => Model); }
        }

        #endregion
        #region - Attributes -
        protected string _className;
        protected T _model;
        protected IEventAggregator _eventAggregator;
        private ILogService _log;
        protected CancellationTokenSource _cancellationTokenSource;
        public const int ACTION_TOKEN_TIMEOUT = 5000;
        #endregion

    }
}
