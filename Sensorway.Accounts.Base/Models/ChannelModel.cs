using Newtonsoft.Json;
using System;

namespace Sensorway.Accounts.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 6/3/2024 1:40:18 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ChannelModel : UserBaseModel, IChannelModel
    {
        #region - Ctors -
        public ChannelModel()
        {
            
        }
        public ChannelModel(IChannelModel model) : base(model)
        {
            ClientId = model.ClientId;
            Channel = model.Channel;
            IpAddress = model.IpAddress;
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
        [JsonProperty("client_id", Order = 2)]
        public int ClientId { get; set; }
        [JsonProperty("channel", Order = 3)]
        public string Channel { get; set; }
        [JsonProperty("ip_address", Order = 4)]
        public string IpAddress { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}