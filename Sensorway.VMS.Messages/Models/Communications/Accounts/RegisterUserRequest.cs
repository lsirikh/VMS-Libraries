﻿using Dotnet.OnvifSolution.Base.Models;
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
       Created On   : 5/27/2024 1:42:18 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class RegisterUserRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public RegisterUserRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_REGISTER_USER)
        {
            
        }
        public RegisterUserRequest(UserModel model = default, ChannelModel channel = default)
                                    : base(null, EnumType.REQUEST, EnumCommand.REQUEST_REGISTER_USER)
        {
            Body = model;
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
        public UserModel Body { get; set; }
        [JsonProperty("channel", Order = 4)]
        public ChannelModel Channel { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}