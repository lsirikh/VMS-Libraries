using Newtonsoft.Json;

namespace Sensorway.Apis.MediaMTX.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/8/2024 1:40:31 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SourceModel
    {
        [JsonProperty("type", Order = 1)]
        public string Type { get; set; }

        [JsonProperty("id", Order = 2)]
        public string Id { get; set; }
    }
}
