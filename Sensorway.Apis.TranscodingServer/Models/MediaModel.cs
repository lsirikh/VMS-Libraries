using Newtonsoft.Json;
using System;

namespace Sensorway.Apis.TranscodingServer.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/22/2024 9:54:54 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class MediaModel : IMediaModel
    {
        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }

        [JsonProperty("user", Order = 2)]
        public string Username { get; set; }
        [JsonProperty("pass", Order = 2)]
        public string Password { get; set; }

        [JsonProperty("ip", Order = 2)]
        public string Ip { get; set; }
        [JsonProperty("port", Order = 2)]
        public string Port { get; set; }
        [JsonProperty("path", Order = 3)]
        public string Path { get; set; }
        [JsonProperty("full_path", Order = 3)]
        public string FullPath { get; set; }

        [JsonProperty("mount_points", Order = 4)]
        public MountPointsModel MountPoints { get; set; }
    }
}