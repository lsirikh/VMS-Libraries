using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/23/2024 9:50:15 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GetDummyListRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public GetDummyListRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DUMMY_LIST)
        {
        }

        public GetDummyListRequest(string token = default) : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DUMMY_LIST)
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
