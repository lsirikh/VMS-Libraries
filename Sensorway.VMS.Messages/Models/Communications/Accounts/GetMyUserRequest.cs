using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.Accounts.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Accounts
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 7/3/2024 8:59:06 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class GetMyUserRequest : BaseCommunicationModel 
    {
        #region - Ctors -
        public GetMyUserRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_MY_USER)
        {
        }

        public GetMyUserRequest(string token = default)
                                : base(null, EnumType.REQUEST, EnumCommand.REQUEST_MY_USER)
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
        [JsonProperty("token", Order = 4)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}