using Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels;

namespace Sensorway.Framework.ViewBase.ViewModels.Components
{
    public interface ISelectableBaseViewModel : IBasePanelViewModel
    {
        bool IsSelected { get; set; }
    }
}