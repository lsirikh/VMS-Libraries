using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/8/2024 1:37:45 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class RtspItemListModel
    {

        [JsonProperty("itemCount", Order = 1)]
        public int ItemCount { get; set; }

        [JsonProperty("pageCount", Order = 2)]
        public int PageCount { get; set; }

        [JsonProperty("items", Order = 3)]
        public List<RtspItemModel> Items { get; set; }
    }
}
