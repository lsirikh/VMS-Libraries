using Newtonsoft.Json;
using Sensorway.Events.Base.Enums;
using System;

namespace Sensorway.Events.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 1:51:25 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class EventModel : EventBaseModel, IEventModel
    {

        public EventModel()
        {
        }

        public EventModel(int id, string name, EnumEventType type, int cameraId, string cameraName,  string targetPreset, string homePreset, int duration) : base(id)
        {
            Name = name;
            Type = type;
            CameraId = cameraId;
            CameraName = cameraName;
            TargetPreset = targetPreset;
            TargetPreset = homePreset;
            Duration = duration;
        }

        public EventModel(IEventModel model) : base(model)
        {
            Name = model.Name;
            Type = model.Type;
            CameraId = model.CameraId;
            CameraName = model.CameraName;
            TargetPreset = model.TargetPreset;
            HomePreset = model.HomePreset;
            Duration = model.Duration;
        }


        [JsonProperty("name", Order = 2)]
        public string Name { get; set; }

        [JsonProperty("type", Order = 3)]
        public EnumEventType Type { get; set; }

        [JsonProperty("camera_id", Order = 4)]
        public int CameraId { get; set; }
        [JsonProperty("camera_name", Order = 5)]
        public string CameraName { get; set; }

        [JsonProperty("target_preset", Order = 6)]
        public string TargetPreset { get; set; }

        [JsonProperty("home_preset", Order = 7)]
        public string HomePreset { get; set; } = "HOME_PRESET";

        [JsonProperty("duration", Order = 8)]
        public int Duration { get; set; }


    }
}