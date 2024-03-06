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
        Created On   : 2/16/2024 2:33:22 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GetPresetListResponse : BaseResponseModel
    {

        #region - Ctors -
        public GetPresetListResponse() : base(null, EnumCommand.RESPONSE_PRESET_LIST)
        {
        }

        public GetPresetListResponse(string deviceName = null,
                                    List<PTZPresetModel> presets = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_PRESET_LIST, isSuccess, message)
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
        [JsonProperty("body", Order = 6)]
        public List<PTZPresetModel> Presets { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
