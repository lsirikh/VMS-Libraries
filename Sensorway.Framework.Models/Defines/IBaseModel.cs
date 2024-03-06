namespace Sensorway.Framework.Models.Defines
{
    public interface IBaseModel
    {
        void Update(IBaseModel model);
        int Id { get; set; }
    }
}