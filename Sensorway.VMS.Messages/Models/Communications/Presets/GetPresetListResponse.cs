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

    public class GetPresetListResponse : BaseGenericResponseModel<GetPresetListRequest>
    {

        #region - Ctors -
        public GetPresetListResponse() : base(null, EnumCommand.RESPONSE_PRESET_LIST)
        {
        }

        public GetPresetListResponse(List<PTZPresetModel> presets = default,
                                    GetPresetListRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_PRESET_LIST, requestMessage, isSuccess, message)
        {
            Body = presets;
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
      
        [JsonProperty("body", Order = 6)]
        public List<PTZPresetModel> Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
