﻿using Dotnet.OnvifSolution.Base.Models.Extends;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/23/2024 10:39:54 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class DeleteZoneResponse : BaseResponseModel
    {

        #region - Ctors -
        public DeleteZoneResponse() : base(null, EnumCommand.RESPONSE_DELETE_ZONE)
        {
        }

        public DeleteZoneResponse(List<CameraZoneModel> list = default
                                ,bool isSuccess = true
                                , string message = null)
                                : base(null, EnumCommand.RESPONSE_DELETE_ZONE, isSuccess, message)
        {
            List = list;
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
        [JsonProperty("body", Order = 5)]
        public List<CameraZoneModel> List { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
