using System.Collections.Generic;

namespace Sensorway.Apis.TranscodingServer.Models.RequestModels
{
    public interface IRegisterRtspRequest
    {
        List<RtspModel> RtspUris { get; set; }
    }

    public interface IUnregisterRtspRequest
    {
        List<RtspIdModel> RtspIds { get; set; }
    }
}

