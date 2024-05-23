using Newtonsoft.Json;
using System;

namespace Sensorway.Apis.TranscodingServer.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 2:31:16 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class RtspIdModel : IRtspIdModel
    {
        public RtspIdModel(string id)
        {
            Id = id;
        }

        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }
    }
}