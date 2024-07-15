using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sensorway.Apis.TranscodingServer.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/23/2024 2:57:47 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ServerConfigModel : IServerConfigModel
    {
        public void update(ServerConfigModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Name = model.Name;
            IpAddress = model.IpAddress;
            PortAPI = model.PortAPI;
            PortRTSP = model.PortRTSP;
            Status = model.Status;
            Version = model.Version;
        }

        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        [JsonProperty("ip_address", Order = 2)]
        public string IpAddress { get; set; }

        [JsonProperty("api_port", Order = 3)]
        public string PortAPI { get; set; }
        [JsonProperty("rtsp_port", Order = 4)]
        public string PortRTSP { get; set; }

        [JsonProperty("status", Order = 5)]
        public string Status { get; set; }

        [JsonProperty("version", Order = 6)]
        public string Version { get; set; }

    }
}