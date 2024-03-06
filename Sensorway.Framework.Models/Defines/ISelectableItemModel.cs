namespace Sensorway.Framework.Models.Defines
{
    public interface ISelectableItemModel : IBaseModel
    {
        bool IsSelected { get; set; }
        string Name { get; set; }
    }
}