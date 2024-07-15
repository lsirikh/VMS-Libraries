using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/23/2024 9:53:49 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GetZoneListRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public GetZoneListRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_ZONE_LIST)
        {
        }

        public GetZoneListRequest(string token = default) : base(null, EnumType.REQUEST, EnumCommand.REQUEST_ZONE_LIST)
        {
            Token = token;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        [JsonProperty("token", Order = 3)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
