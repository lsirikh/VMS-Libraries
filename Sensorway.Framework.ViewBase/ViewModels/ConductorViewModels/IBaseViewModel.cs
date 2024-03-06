using Sensorway.Framework.Models.Defines;

namespace Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels
{
    public interface IBaseViewModel<T> where T : IBaseModel
    {
        T Model { get; set; }
    }
}