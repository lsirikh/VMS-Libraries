﻿using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Focuses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Communications.Focus
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/29/2024 2:31:15 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class FocusControlRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public FocusControlRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_CAMERA_LIST)
        {
        }

        public FocusControlRequest(string deviceName = default
                                    , FocusMoveModel model = default
                                    , string token = default
                                    , EnumCommand command = EnumCommand.NONE)
                                    : base(null, EnumType.REQUEST, command)
        {
            DeviceName = deviceName;
            FocusMove = model;
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
        [JsonProperty("focus_move", Order = 4)]
        public FocusMoveModel FocusMove { get; set; }
        [JsonProperty("token", Order = 5)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
