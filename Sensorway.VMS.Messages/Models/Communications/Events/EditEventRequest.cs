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
       Created On   : 5/29/2024 3:06:58 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class EditEventRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public EditEventRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_EDIT_EVENT)
        {
        }

        public EditEventRequest(int eventId, EventModel model = default, string token = default) 
            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_EDIT_EVENT)
        {
            EventId = eventId;
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
        [JsonProperty("event_id", Order = 3)]
        public int EventId { get; set; }
        [JsonProperty("body", Order = 4)]
        public EventModel Body { get; set; }
        [JsonProperty("token", Order = 5)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}