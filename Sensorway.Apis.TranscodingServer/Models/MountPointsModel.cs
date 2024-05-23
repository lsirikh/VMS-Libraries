using Newtonsoft.Json;
using System;

namespace Sensorway.Apis.TranscodingServer.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 5:48:51 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class MountPointsModel : IMountPointsModel
    {
        [JsonProperty("uri_first", Order = 1)]
        public string UriFirst { get; set; }

        [JsonProperty("uri_second", Order = 2)]
        public string UriSecond { get; set; }

        [JsonProperty("uri_third", Order = 3)]
        public string UriThird { get; set; }

        [JsonProperty("uri_fourth", Order = 4)]
        public string UriFourth { get; set; }
    }
}