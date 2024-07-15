using Newtonsoft.Json;
using System;

namespace Sensorway.Events.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 1:47:57 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public abstract class EventBaseModel : IEventBaseModel
    {
        public EventBaseModel()
        {
        }

        protected EventBaseModel(int id)
        {
            Id = id;
        }

        protected EventBaseModel(IEventBaseModel model)
        {
            Id = model.Id;
        }

        [JsonProperty("id", Order = 1)]
        public int Id { get; set; }
    }
}