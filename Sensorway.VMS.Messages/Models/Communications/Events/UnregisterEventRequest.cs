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
       Created On   : 5/29/2024 3:06:04 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class UnregisterEventRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public UnregisterEventRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_UNREGISTER_EVENT)
        {
        }

        public UnregisterEventRequest(int eventId, string token = default, bool isForced = false) : base(null, EnumType.REQUEST, EnumCommand.REQUEST_UNREGISTER_EVENT)
        {
            EventId = eventId;
            Token = token;
            IsForced = isForced;
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
        [JsonProperty("event_id", Order = 3)]
        public int EventId { get; set; }
        [JsonProperty("token", Order = 4)]
        public string Token { get; set; }
        [JsonProperty("is_forced", Order = 5)]
        public bool IsForced { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}