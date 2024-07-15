using Sensorway.Events.Base.Enums;
using System;

namespace Sensorway.Events.Base.Models
{
    public interface IActionEventModel : IEventBaseModel
    {
        int EventId { get; set; }
        string Message { get; set; }
        EnumEventStatus Status { get; set; }
        DateTime Created { get; set; }
    }
}