using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:33:39 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SetPresetRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public SetPresetRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_SET_PRESET)
        {
        }

        public SetPresetRequest(string deviceName = null
                                , string presetName = null
                                , string presetToken = null
                                , string token = default)
                                : base(null, EnumType.REQUEST, EnumCommand.REQUEST_SET_PRESET)
        {
            DeviceName = deviceName;
            PresetName = presetName;
            PresetToken = presetToken;

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
        [JsonProperty("preset_name", Order = 4)]
        public string PresetName { get; set; }
        [JsonProperty("preset_token", Order = 5)]
        public string PresetToken { get; set; }
        [JsonProperty("token", Order = 6)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
