﻿using Dotnet.OnvifSolution.Base.Models.Extends;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/23/2024 10:39:22 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SetZoneRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public SetZoneRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_SET_ZONE)
        {

        }
        
        public SetZoneRequest(CameraZoneModel model = default
                            , string token = default)
                            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_SET_ZONE)
        {
            Body = model;
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
        [JsonProperty("body", Order = 3)]
        public CameraZoneModel Body { get; set; }
        [JsonProperty("token", Order = 4)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
