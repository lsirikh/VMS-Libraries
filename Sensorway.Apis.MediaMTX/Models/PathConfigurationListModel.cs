using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/13/2024 1:57:23 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PathConfigurationListModel
    {
        [JsonProperty("itemCount", Order = 1)]
        public int ItemCount { get; set; }

        [JsonProperty("pageCount", Order = 2)]
        public int PageCount { get; set; }

        [JsonProperty("items", Order = 3)]
        public List<PathConfigurationModel> Items { get; set; }
    }
}
