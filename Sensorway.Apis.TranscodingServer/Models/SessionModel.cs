using Newtonsoft.Json;
using System;

namespace Sensorway.Apis.TranscodingServer.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 10:07:04 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class SessionModel : RtspModel, ISessionModel
    {

        [JsonProperty("session_id", Order = 2)]
        public string SessionId { get; set; }
    }

    public class RtspModel : IRtspModel
    {
        [JsonProperty("uri", Order = 1)]
        public string Uri { get; set; }
    }
}