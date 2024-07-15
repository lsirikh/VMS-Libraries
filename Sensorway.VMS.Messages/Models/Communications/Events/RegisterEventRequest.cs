using Newtonsoft.Json;
using Sensorway.Accounts.Base.Models;
using Sensorway.Events.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;
using System.Reflection;

namespace Sensorway.VMS.Messages.Models.Communications.Events
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 2:26:56 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class RegisterEventRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public RegisterEventRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_REGISTER_EVENT)
        {
        }

        public RegisterEventRequest(EventModel model = default, string token = default) : base(null, EnumType.REQUEST, EnumCommand.REQUEST_REGISTER_EVENT)
        {
            Body = model;
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
        [JsonProperty("body", Order = 3)]
        public EventModel Body { get; set; }
        [JsonProperty("token", Order = 4)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}