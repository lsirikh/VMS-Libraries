using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:34:05 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SetPresetResponse : BaseResponseModel
    {

        #region - Ctors -
        public SetPresetResponse() : base(null, EnumCommand.RESPONSE_SET_PRESET)
        {
        }

        public SetPresetResponse(string deviceName = null,
                                    List<PTZPresetModel> presets = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_SET_PRESET, isSuccess, message)
        {
            DeviceName = deviceName;
            Presets = presets;
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
        [JsonProperty("body", Order = 5)]
        public List<PTZPresetModel> Presets { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
