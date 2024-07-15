using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Communications.Focus;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:34:53 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class DeletePresetResponse : BaseGenericResponseModel<DeletePresetRequest>
    {

        #region - Ctors -
        public DeletePresetResponse() : base(null, EnumCommand.RESPONSE_DELETE_PRESET)
        {
        }

        public DeletePresetResponse(List<PTZPresetModel> presets = default,
                                    DeletePresetRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_DELETE_PRESET, requestMessage, isSuccess, message)
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
