using Dotnet.OnvifSolution.Base.Models.Components;
using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System.Reflection;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:35:16 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class MovePresetRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public MovePresetRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_MOVE_PRESET)
        {
        }

        public MovePresetRequest(string deviceName = null
                                , string presetToken = default
                                , PTZSpeedModel presetSpeed = default)
                                    : base(null, EnumType.REQUEST, EnumCommand.REQUEST_MOVE_PRESET)
        {
            DeviceName = deviceName;
            PresetToken = presetToken;
            PresetSpeed = presetSpeed;
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
        [JsonProperty("device_name", Order = 5)]
        public string DeviceName { get; set; }
        [JsonProperty("preset_token", Order = 6)]
        public string PresetToken { get; set; }
        [JsonProperty("preset_speed", Order = 7)]
        public PTZSpeedModel PresetSpeed { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
