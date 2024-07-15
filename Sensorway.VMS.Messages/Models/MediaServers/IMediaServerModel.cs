using Dotnet.OnvifSolution.Base.Models.Components;
using Sensorway.VMS.Messages.Enums;
using System;

namespace Sensorway.VMS.Messages.Models.MediaServers
{
    public interface IMediaServerModel
    {
        string ConfName { get; set; }
        string MediaServerUrl { get; set; }
        string Name { get; set; }
        bool Ready { get; set; }
        ResolutionModel Resolution { get; set; }
        DateTime? ReadyTime { get; set; }
        bool Recording { get; set; }
        EnumMediaServerSource Source { get; set; }
    }
}