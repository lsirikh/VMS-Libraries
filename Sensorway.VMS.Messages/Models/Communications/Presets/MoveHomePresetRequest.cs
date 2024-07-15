using Dotnet.OnvifSolution.Base.Models.Components;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 6/4/2024 6:58:10 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class MoveHomePresetRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public MoveHomePresetRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_MOVE_HOME_PRESET)
        {
        }

        public MoveHomePresetRequest(string deviceName = null
                                    , PTZSpeedModel presetSpeed = default
                                    , string token = default)
                                    : base(null, EnumType.REQUEST, EnumCommand.REQUEST_MOVE_HOME_PRESET)
        {
            DeviceName = deviceName;
            PresetSpeed = presetSpeed;
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
        [JsonProperty("device_name", Order = 3)]
        public string DeviceName { get; set; }
        [JsonProperty("preset_speed", Order = 4)]
        public PTZSpeedModel PresetSpeed { get; set; }
        [JsonProperty("token", Order = 5)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}