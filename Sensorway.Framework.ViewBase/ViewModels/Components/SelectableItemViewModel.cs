using Caliburn.Micro;
using Sensorway.Framework.Models.Defines;

namespace Sensorway.Framework.ViewBase.ViewModels.Components
{
    public class SelectableItemViewModel : PropertyChangedBase
    {
        #region - Ctors -
        public SelectableItemViewModel(int id, string name, bool isChecked = false)
        {
            _selectableItemModel = new SelectableItemModel
            {
                Id = id,
                Name = name,
                IsSelected = isChecked
            };
        }
        public SelectableItemViewModel(string name, bool isChecked = false)
        {
            _selectableItemModel = new SelectableItemModel
            {
                Name = name,
                IsSelected = isChecked
            };
        }
        public SelectableItemViewModel(
            SelectableItemModel selectableItemModel)
        {
            _selectableItemModel = selectableItemModel;
        }
        #endregion

        #region - Properties -
        public int Id
        {
            get { return _selectableItemModel.Id; }
            set 
            { 
                _selectableItemModel.Id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public string Name
        {
            get => _selectableItemModel.Name;
            set
            {
                _selectableItemModel.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public bool IsSelected
        {
            get => _selectableItemModel.IsSelected;
            set
            {
                _selectableItemModel.IsSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        public override int GetHashCode()
        {
            return _selectableItemModel.GetHashCode();
        }
        #endregion

        #region - Attriibtes -
        private SelectableItemModel _selectableItemModel;
        #endregion
    }
}
