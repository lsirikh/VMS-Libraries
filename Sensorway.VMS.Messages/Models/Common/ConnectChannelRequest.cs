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
       Created On   : 6/3/2024 1:51:00 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ConnectChannelRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public ConnectChannelRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_CONNECTION_CHANNEL)
        {
        }

        public ConnectChannelRequest(ChannelModel model, bool isForced = false) : base(null, EnumType.REQUEST, EnumCommand.REQUEST_CONNECTION_CHANNEL)
        {
            Body = model;
            IsForced = isForced;
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
        [JsonProperty("is_forced", Order = 4)]
        public bool IsForced { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}