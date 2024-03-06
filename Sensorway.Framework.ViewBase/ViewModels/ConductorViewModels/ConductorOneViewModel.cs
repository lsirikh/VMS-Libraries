﻿using Caliburn.Micro;
using Dotnet.Libraries.Enums;
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
    public abstract class ConductorOneViewModel
       : Conductor<Screen>.Collection.OneActive
        , IConductorViewModel
        , IHandle<CloseAllMessageModel>

    {
        #region - Ctors -
        public ConductorOneViewModel()
        {
            ClassName = this.GetType().Name.ToString();
        }

        public ConductorOneViewModel(IEventAggregator eventAggregator)
        {
            ClassName = this.GetType().Name.ToString();
            _eventAggregator = eventAggregator;
        }
        #endregion

        #region - Override Methods -
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            base.OnActivateAsync(cancellationToken);
            _eventAggregator?.SubscribeOnPublishedThread(this);
            Debug.WriteLine($"######### {ClassName} OnActivate!! #########");
            IsVisible = true;
            return Task.CompletedTask;
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            base.OnDeactivateAsync(close, cancellationToken);
            _eventAggregator?.Unsubscribe(this);
            Debug.WriteLine($"######### {ClassName} OnDeactivate!! #########");
            IsVisible = false;
            return Task.CompletedTask;
        }

        protected override Task ChangeActiveItemAsync(Screen newItem, bool closePrevious, CancellationToken cancellationToken)
        {
            if (newItem == null)
                IsVisible = false;

            return base.ChangeActiveItemAsync(newItem, closePrevious, cancellationToken);
        }

        public override Task ActivateItemAsync(Screen item, CancellationToken cancellationToken = default)
        {
            /// BaseViewModel을 상속받는  
            /// ViewModel만 ActivateItem이 가능
            if (!(item is IBasePanelViewModel))
                return null;

            base.ActivateItemAsync(item, cancellationToken);

            /// 해당 ShellViewModel을 Visible 하게 
            /// 관리하기 위해서 Dialog와 Popup Dialog의
            /// ShellViewModel의 ActiveItem이 Blank Item 인지
            /// 확인하는 과정이 필요하다.
            var viewModel = item as IBasePanelViewModel;

            IsVisible = true;

            #region Deprecated Code
            /*if (viewModel.Category == CategoryEnum.PANEL_SHELL_VM_BASE
                || viewModel.Category == CategoryEnum.DIALOG_SHELL_VM_BASE
                || viewModel.Category == CategoryEnum.POPUP_DIALOG_SHELL_VM_BASE)
                IsVisible = false;
            else
                IsVisible = true;*/
            #endregion

            return Task.CompletedTask;
        }
        
        #endregion

        #region - Handles - 

        public Task HandleAsync(CloseAllMessageModel message, CancellationToken cancellationToken)
        {
            if (IsActive)
            {
                //이전에 담긴 Item은 무시한다.
                Items.Clear();
                //현재 Conductor에 담긴 Item은 Deactivate 시킨다.
                DeactivateItemAsync(ActiveItem, true, cancellationToken);
                //결론적으로 Conductor를 Deactivate 시킨다.
                return TryCloseAsync();
            }
            else
                return Task.CompletedTask;
        }

        #endregion

        #region - Properties -
        public int ClassId
        {
            get { return _classId; }
            set
            {
                _classId = value;
                NotifyOfPropertyChange(() => ClassId);
            }
        }
        public string ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                NotifyOfPropertyChange(() => ClassName);
            }
        }
        public string ClassContent
        {
            get { return _classContent; }
            set
            {
                _classContent = value;
                NotifyOfPropertyChange(() => ClassContent);
            }
        }
        public CategoryEnum ClassCategory
        {
            get { return _classCategory; }
            set
            {
                _classCategory = value;
                NotifyOfPropertyChange(() => ClassCategory);
            }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }
        #endregion

        #region - Attributes - 
        private int _classId;
        private string _className;
        private string _classContent;
        private CategoryEnum _classCategory;
        private bool _isVisible;
        protected IEventAggregator _eventAggregator;
        //private bool _animationControl;
        #endregion
    }
}
