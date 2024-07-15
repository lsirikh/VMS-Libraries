using Sensorway.Events.Base.Enums;

namespace Sensorway.Events.Base.Models
{
    public interface IEventModel : IEventBaseModel
    {
        string Name { get; set; }
        EnumEventType Type { get; set; }
        int CameraId { get; set; }
        string CameraName { get; set; }
        string TargetPreset { get; set; }
        string HomePreset { get; set; }
        int Duration { get; set; }
    }
}