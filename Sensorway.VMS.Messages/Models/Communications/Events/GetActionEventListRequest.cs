using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Events
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 3:11:08 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class GetActionEventListRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public GetActionEventListRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LIST_ACTION_EVENT)
        {
        }

        public GetActionEventListRequest(string token = default, DateTime from = default, DateTime to = default)
            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LIST_ACTION_EVENT)
        {
            Token = token;
            From = from;
            To = to;
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
        [JsonProperty("token", Order = 3)]
        public string Token { get; set; }
        [JsonProperty("from", Order = 4)]
        public DateTime From { get; set; }
        [JsonProperty("to", Order = 5)]
        public DateTime To { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}