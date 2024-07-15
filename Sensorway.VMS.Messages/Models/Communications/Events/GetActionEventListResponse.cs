using Newtonsoft.Json;
using Sensorway.Events.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Communications.Events
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 3:11:23 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class GetActionEventListResponse : BaseGenericResponseModel<GetActionEventListRequest>
    {
        #region - Ctors -
        public GetActionEventListResponse() : base(null, EnumCommand.RESPONSE_LIST_ACTION_EVENT)
        {
        }

        public GetActionEventListResponse(List<ActionEventModel> list = default
                                , GetActionEventListRequest requestMessage = default, bool isSuccess = true, string message = null)
                                : base(null, EnumCommand.RESPONSE_LIST_ACTION_EVENT, requestMessage, isSuccess, message)
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
        public List<ActionEventModel> Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}