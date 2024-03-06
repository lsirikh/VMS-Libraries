﻿using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Communications.Presets
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:33:05 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GetPresetListRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public GetPresetListRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_PRESET_LIST)
        {
        }

        public GetPresetListRequest(string deviceName = null)
                                    : base(null, EnumType.REQUEST, EnumCommand.REQUEST_PRESET_LIST)
        {
            DeviceName = deviceName;
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
        #endregion
        #region - Attributes -
        #endregion
    }
}
