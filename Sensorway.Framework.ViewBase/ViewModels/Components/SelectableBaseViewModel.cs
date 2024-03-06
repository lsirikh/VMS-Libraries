﻿using Caliburn.Micro;
using Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels;

namespace Sensorway.Framework.ViewBase.ViewModels.Components
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 7/7/2023 9:45:01 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public abstract class SelectableBaseViewModel : BasePanelViewModel, ISelectableBaseViewModel
    {

        #region - Ctors -
        public SelectableBaseViewModel()
        {

        }

        public SelectableBaseViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {

        }
        #endregion
        #region - Implementation of Interface -
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
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }
        #endregion
        #region - Attributes -
        private bool _isSelected;
        #endregion
    }
}
