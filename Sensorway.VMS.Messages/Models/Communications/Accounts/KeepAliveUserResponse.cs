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
       Created On   : 5/27/2024 2:38:59 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class KeepAliveUserResponse : BaseGenericResponseModel<KeepAliveUserRequest>
    {
        #region - Ctors -
        public KeepAliveUserResponse() : base(null, EnumCommand.RESPONSE_KEEP_ALIVE_USER)
        {
        }

        public KeepAliveUserResponse(LoginSessionModel model = default,
                                        KeepAliveUserRequest requestMessage = default,
                                        bool isSuccess = true,
                                        string message = null)
                                        : base(null, EnumCommand.RESPONSE_KEEP_ALIVE_USER, requestMessage, isSuccess, message)
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