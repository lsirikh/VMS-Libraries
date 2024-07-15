using Newtonsoft.Json;
using Sensorway.Accounts.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;
using System;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Communications.Accounts
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 2:03:15 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class GetUserListResponse : BaseGenericResponseModel<GetUserListRequest>
    {
        #region - Ctors -
        public GetUserListResponse() : base(null, EnumCommand.RESPONSE_LIST_USER)
        {
        }

        public GetUserListResponse(List<UserModel> users = default,
                                    List<LoginSessionModel> sessions = default,
                                    GetUserListRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_LIST_USER, requestMessage, isSuccess, message)
        {
            Users = users;
            Sessions = sessions;
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
        [JsonProperty("users", Order = 6)]
        public List<UserModel> Users { get; set; }
        [JsonProperty("sessions", Order = 7)]
        public List<LoginSessionModel> Sessions { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}