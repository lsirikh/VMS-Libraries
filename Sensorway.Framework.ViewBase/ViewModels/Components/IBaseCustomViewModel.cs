using Sensorway.Framework.Models.Defines;
using System.Windows;

namespace Sensorway.Framework.ViewBase.ViewModels.Components
{
    public interface IBaseCustomViewModel<T> :ISelectableBaseViewModel where T : IBaseModel
    {
        
        void Dispose();
        void OnLoaded(object sender, SizeChangedEventArgs e);
        void UpdateModel(T model);
        T Model { get;}
    }
}