﻿using Dotnet.OnvifSolution.Base.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensorway.VMS.Messages.Models.Communications
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/7/2024 3:32:36 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GetCameraListRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public GetCameraListRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_CAMERA_LIST)
        {
        }
        public GetCameraListRequest(string token = default) : base(null, EnumType.REQUEST, EnumCommand.REQUEST_CAMERA_LIST)
        {
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
        [JsonProperty("token", Order = 3)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
