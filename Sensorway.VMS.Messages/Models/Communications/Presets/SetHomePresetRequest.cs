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
       Created On   : 6/4/2024 6:48:54 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class SetHomePresetRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public SetHomePresetRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_SET_HOME_PRESET)
        {
        }

        public SetHomePresetRequest(string deviceName = null
                                , string token = default)
                                : base(null, EnumType.REQUEST, EnumCommand.REQUEST_SET_HOME_PRESET)
        {
            DeviceName = deviceName;
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
        [JsonProperty("token", Order = 4)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}