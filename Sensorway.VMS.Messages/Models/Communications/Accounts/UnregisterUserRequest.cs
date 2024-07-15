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
       Created On   : 5/27/2024 1:42:44 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class UnregisterUserRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public UnregisterUserRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_UNREGISTER_USER)
        {
        }
        public UnregisterUserRequest(LoginSessionModel model = default)
                                            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_UNREGISTER_USER)
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