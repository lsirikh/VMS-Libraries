using Dotnet.OnvifSolution.Base.Models.Components;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using System;

namespace Sensorway.VMS.Messages.Models.MediaServers
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/14/2024 9:48:50 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class MediaServerModel : IMediaServerModel
    {
        /// <summary>
        /// 미디어 서버의 인스턴스 이름
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }
        /// <summary>
        /// 미디어 서버의 Configuration 이름
        /// </summary>
        [JsonProperty("config_name", Order = 2)]
        public string ConfName { get; set; }
        /// <summary>
        /// Media Streaming Source의 타입
        /// </summary>
        [JsonProperty("media_source", Order = 3)]
        public EnumMediaServerSource Source { get; set; }
        /// <summary>
        /// Media 서버 Url
        /// </summary>
        [JsonProperty("media_server_url", Order = 4)]
        public string MediaServerUrl { get; set; }
        /// <summary>
        /// 해당 Streaming Resolution
        /// </summary>
        [JsonProperty("resolution", Order = 5)]
        public ResolutionModel Resolution { get; set; }
        /// <summary>
        /// 저장 여부
        /// </summary>
        [JsonProperty("recording", Order = 6)]
        public bool Recording { get; set; }
        /// <summary>
        /// 사용 및 동작 여부
        /// </summary>
        [JsonProperty("ready", Order = 7)]
        public bool Ready { get; set; }
        /// <summary>
        /// 시작된 시간
        /// </summary>
        [JsonProperty("ready_time", Order = 8)]
        public DateTime? ReadyTime { get; set; }
    }
}
