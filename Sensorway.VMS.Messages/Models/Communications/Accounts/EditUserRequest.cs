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
       Created On   : 5/27/2024 2:01:55 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class EditUserRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public EditUserRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_EDIT_USER)
        {
        }

        public EditUserRequest(UserModel model = default, string token = default)
                                : base(null, EnumType.REQUEST, EnumCommand.REQUEST_EDIT_USER)
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
        public UserModel Body { get; set; }
        [JsonProperty("token", Order = 4)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}