using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 6/4/2024 6:58:22 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class MoveHomePresetResponse : BaseGenericResponseModel<MoveHomePresetRequest>
    {

        #region - Ctors -
        public MoveHomePresetResponse() : base(null, EnumCommand.RESPONSE_MOVE_HOME_PRESET)
        {
        }

        public MoveHomePresetResponse(MoveHomePresetRequest requestMessage = default,
                                        bool isSuccess = true,
                                        string message = null)
                                        : base(null, EnumCommand.RESPONSE_MOVE_HOME_PRESET, requestMessage, isSuccess, message)
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