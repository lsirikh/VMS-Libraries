using Newtonsoft.Json;
using Sensorway.Accounts.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Accounts
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 1:44:04 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class LoginUserResponse : BaseGenericResponseModel<LoginUserRequest>
    {
        #region - Ctors -
        public LoginUserResponse() : base(null, EnumCommand.RESPONSE_LOGIN_USER)
        {
            
        }

        public LoginUserResponse(LoginSessionModel model = default,
                                LoginUserRequest requestMessage = default,
                                bool isSuccess = true,
                                string message = null)
                                : base(null, EnumCommand.RESPONSE_LOGIN_USER, requestMessage, isSuccess, message)
        {
            Body = model;
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
        [JsonProperty("body", Order = 6)]
        public LoginSessionModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}