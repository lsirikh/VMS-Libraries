using System;
using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    public interface IRtspItemModel
    {
        long BytesReceived { get; set; }
        long BytesSent { get; set; }
        string ConfName { get; set; }
        string Name { get; set; }
        List<object> Readers { get; set; }
        bool Ready { get; set; }
        DateTime? ReadyTime { get; set; }
        SourceModel Source { get; set; }
        List<string> Tracks { get; set; }
    }
}