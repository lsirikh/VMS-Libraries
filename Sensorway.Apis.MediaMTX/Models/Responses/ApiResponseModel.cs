using Newtonsoft.Json;

namespace Sensorway.Apis.MediaMTX.Models.Responses
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/13/2024 9:51:43 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class ApiResponseModel
    {
        [JsonProperty("is_success", Order = 0)]
        public bool IsSuccess { get; set; }
        [JsonProperty("error", Order = 1)]
        public ApiErrorResponseModel error { get; set; }
    }
}
