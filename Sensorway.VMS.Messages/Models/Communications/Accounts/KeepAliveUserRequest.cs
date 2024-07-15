using Dotnet.OnvifSolution.Base.Models;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Accounts
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 2:38:31 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class KeepAliveUserRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public KeepAliveUserRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_KEEP_ALIVE_USER)
        {
        }
        public KeepAliveUserRequest(string token)
                                    : base(null, EnumType.REQUEST, EnumCommand.REQUEST_KEEP_ALIVE_USER)
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