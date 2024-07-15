using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:34:41 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class DeletePresetRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public DeletePresetRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DELETE_PRESET)
        {
        }

        public DeletePresetRequest(string deviceName = null
                                    , string presetToken = default
                                    , string token = default)
                                    : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DELETE_PRESET)
        {
            DeviceName = deviceName;
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
        [JsonProperty("preset_token", Order = 4)]
        public string PresetToken { get; set; }
        [JsonProperty("token", Order = 5)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
