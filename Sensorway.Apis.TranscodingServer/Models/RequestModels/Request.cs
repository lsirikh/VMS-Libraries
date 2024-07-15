using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sensorway.Apis.TranscodingServer.Models.RequestModels
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 10:13:33 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class RegisterRtspRequest : IRegisterRtspRequest
    {

        public RegisterRtspRequest(List<RtspModel> uris)
        {
            RtspUris = uris;
        }

        [JsonProperty("rtsp_uris", Order = 1)]
        public List<RtspModel> RtspUris { get; set; }

    }

    public class UnregisterRtspRequest : IUnregisterRtspRequest
    {
        public UnregisterRtspRequest(List<RtspIdModel> ids)
        {
            RtspIds = ids;
        }

        [JsonProperty("rtsp_ids", Order = 1)]
        public List<RtspIdModel> RtspIds { get; set; }
    }

    public class GetSessionRequest
    {

    }

    public class GetMediaRequest
    {

    }
}