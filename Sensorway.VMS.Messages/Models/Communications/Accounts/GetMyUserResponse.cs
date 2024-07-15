using Newtonsoft.Json;
using Sensorway.Accounts.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Accounts
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 7/3/2024 8:59:17 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class GetMyUserResponse : BaseGenericResponseModel<GetMyUserRequest>
    {
        #region - Ctors -
        public GetMyUserResponse() : base(null, EnumCommand.RESPONSE_MY_USER)
        {
        }

        public GetMyUserResponse(UserModel body = default,
                                GetMyUserRequest requestMessage = default,
                                bool isSuccess = true,
                                string message = null)
                                : base(null, EnumCommand.RESPONSE_MY_USER, requestMessage, isSuccess, message)
        {
            Body = body;
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
        public UserModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}