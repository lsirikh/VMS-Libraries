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
       Created On   : 5/27/2024 1:43:52 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class LoginUserRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public LoginUserRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LOGIN_USER)
        {
        }

        public LoginUserRequest(LoginUserModel model = default
                                , bool isForced = false
                                , ChannelModel channel = null)
                                : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LOGIN_USER)
        {
            Body = model;
            IsForced = isForced;
            Channel = channel;
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
        public LoginUserModel Body { get; set; }
        [JsonProperty("is_forced", Order = 4)]
        public bool IsForced { get; set; }
        [JsonProperty("channel", Order = 4)]
        public ChannelModel Channel { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}