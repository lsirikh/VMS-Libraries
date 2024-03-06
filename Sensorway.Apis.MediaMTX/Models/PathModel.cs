using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/13/2024 5:11:37 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PathModel : IPathModel
    {
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        [JsonProperty("confName", Order = 2)]
        public string ConfName { get; set; }

        [JsonProperty("source", Order = 3)]
        public SourceModel Source { get; set; }

        [JsonProperty("ready", Order = 4)]
        public bool Ready { get; set; }

        [JsonProperty("readyTime", Order = 5)]
        public DateTime? ReadyTime { get; set; }

        [JsonProperty("tracks", Order = 6)]
        public List<string> Tracks { get; set; }

        [JsonProperty("bytesReceived", Order = 7)]
        public long BytesReceived { get; set; }

        [JsonProperty("bytesSent", Order = 8)]
        public long BytesSent { get; set; }

        [JsonProperty("readers", Order = 9)]
        public List<SourceModel> Readers { get; set; }
    }
}
