using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 6/4/2024 6:49:14 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class SetHomePresetResponse : BaseGenericResponseModel<SetHomePresetRequest>
    {
        #region - Ctors -
        public SetHomePresetResponse() : base(null, EnumCommand.RESPONSE_SET_HOME_PRESET)
        {
        }

        public SetHomePresetResponse(SetHomePresetRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_SET_HOME_PRESET, requestMessage, isSuccess, message)
        {
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
        #endregion
        #region - Attributes -
        #endregion
    }
}