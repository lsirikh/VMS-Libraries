using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/23/2024 9:52:53 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GetDummyListResponse : BaseGenericResponseModel<GetDummyListRequest>
    {

        #region - Ctors -
        public GetDummyListResponse() : base(null, EnumCommand.RESPONSE_DUMMY_LIST)
        {

        }
        public GetDummyListResponse(List<string> list = default,
                                    GetDummyListRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_DUMMY_LIST, requestMessage, isSuccess, message)
        {
            Body = list;
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
        [JsonProperty("body", Order = 6)]
        public List<string> Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
