using Dotnet.OnvifSolution.Base.Models;
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
       Created On   : 5/27/2024 1:44:34 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class LogoutUserRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public LogoutUserRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LOGOUT_USER)
        {
        }

        public LogoutUserRequest(LoginSessionModel model = default)
                                            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LOGOUT_USER)
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
        [JsonProperty("body", Order = 3)]
        public LoginSessionModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}