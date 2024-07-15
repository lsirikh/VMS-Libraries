using Newtonsoft.Json;
using Sensorway.Accounts.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 6/3/2024 1:52:26 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class DisconnectChannelRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public DisconnectChannelRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DISCONNECTION_CHANNEL)
        {
        }

        public DisconnectChannelRequest(ChannelModel model) : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DISCONNECTION_CHANNEL)
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
        public ChannelModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}