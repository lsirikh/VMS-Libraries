using Newtonsoft.Json;
using Sensorway.Events.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Events
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 2:28:50 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class RegisterEventResponse : BaseGenericResponseModel<RegisterEventRequest>
    {
        #region - Ctors -
        public RegisterEventResponse() : base(null, EnumCommand.RESPONSE_REGISTER_EVENT)
        {
        }

        public RegisterEventResponse(EventModel model = default
                                , RegisterEventRequest requestMessage = default, bool isSuccess = true, string message = null)
                                : base(null, EnumCommand.RESPONSE_REGISTER_EVENT, requestMessage, isSuccess, message)
        {
            Body = model;
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
        public EventModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}