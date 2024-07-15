using Dotnet.OnvifSolution.Base.Models.Extends;
using Newtonsoft.Json;
using Sensorway.Accounts.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 6/3/2024 1:51:15 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ConnectChannelResponse : BaseGenericResponseModel<ConnectChannelRequest>
    {

        #region - Ctors -
        public ConnectChannelResponse() : base(null, EnumCommand.RESPONSE_CONNECTION_CHANNEL)
        {
        }

        public ConnectChannelResponse(ConnectChannelRequest requestMessage = default
                                    , bool isSuccess = true
                                    , string message = null)
                                    : base(null, EnumCommand.RESPONSE_CONNECTION_CHANNEL, requestMessage, isSuccess, message)
        {
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
        //[JsonProperty("body", Order = 6)]
        //public ChannelModel Body { get; set; }
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}