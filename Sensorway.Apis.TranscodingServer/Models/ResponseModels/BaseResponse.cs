using Newtonsoft.Json;
using System;

namespace Sensorway.Apis.TranscodingServer.Models.ResponseModels
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 10:20:11 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public abstract class BaseResponse : IBaseResponse
    {
        public BaseResponse(string message, string result)
        {
            Message = message;
            Result = result;
        }


        [JsonProperty("message", Order = 1)]
        public string Message { get; set; }

        [JsonProperty("result", Order = 2)]
        public string Result { get; set; }

    }
}