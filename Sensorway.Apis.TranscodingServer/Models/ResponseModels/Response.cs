using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sensorway.Apis.TranscodingServer.Models.ResponseModels
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 2:35:40 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class RegisterRtspResponse : BaseResponse, IRegisterRtspResponse
    {
        public RegisterRtspResponse(string message, string result) : base(message, result)
        {
        }
    }

    public class UnregisterRtspResponse : BaseResponse, IUnregisterRtspResponse
    {
        public UnregisterRtspResponse(string message, string result) : base(message, result)
        {
        }
    }

    public class GetSessionResponse : BaseResponse, IGetSessionResponse
    {
        public GetSessionResponse(string message, string result, int count, List<SessionModel> lists) : base(message, result)
        {
            List = lists;
            Count = count;
        }

        [JsonProperty("list", Order = 3)]
        public List<SessionModel> List { get; set; }

        [JsonProperty("count", Order = 4)]
        public int Count { get; set; }
    }

    public class GetMediaResponse : BaseResponse, IGetMediaResponse
    {
        public GetMediaResponse(string message, string result, int count, List<MediaModel> lists) : base(message, result)
        {
            List = lists;
            Count = count;
        }

        [JsonProperty("list", Order = 3)]
        public List<MediaModel> List { get; set; }

        [JsonProperty("count", Order = 4)]
        public int Count { get; set; }
    }
}