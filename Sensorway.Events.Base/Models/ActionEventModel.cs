using Newtonsoft.Json;
using Sensorway.Events.Base.Enums;
using System;

namespace Sensorway.Events.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 2:15:34 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ActionEventModel : EventBaseModel, IActionEventModel
    {
        public ActionEventModel()
        {
        }

        public ActionEventModel(int id, int enventId, string message, EnumEventStatus status, DateTime created) : base(id)
        {
            EventId = enventId;
            Message = message;
            Status = status;
            Created = created;
        }

        public ActionEventModel(IActionEventModel model) : base(model)
        {
            EventId = model.EventId;
            Message = model.Message;
            Status = model.Status;
            Created = model.Created;
        }

        [JsonProperty("event_id", Order = 2)]
        public int EventId { get; set; }

        [JsonProperty("message", Order = 3)]
        public string Message { get; set; }

        [JsonProperty("status", Order = 4)]
        public EnumEventStatus Status { get; set; }

        [JsonProperty("created", Order = 5)]
        public DateTime Created { get; set; }

    }
}