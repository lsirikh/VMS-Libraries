using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensorway.Apis.TranscodingServer.Models.ResponseModels
{
    public interface IRegisterRtspResponse : IBaseResponse
    {
    }

    public interface IUnregisterRtspResponse : IBaseResponse
    {
    }
    
    public interface IGetSessionResponse : IBaseResponse
    {
        List<SessionModel> List { get; set; }

        int Count { get; set; }
    }

    public interface IGetMediaResponse : IBaseResponse
    {
        List<MediaModel> List { get; set; }

        int Count { get; set; }
    }
}
