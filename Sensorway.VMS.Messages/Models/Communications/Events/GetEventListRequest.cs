using Newtonsoft.Json;
using Sensorway.Events.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Events
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 3:10:33 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class GetEventListRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public GetEventListRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LIST_EVENT)
        {
        }

        public GetEventListRequest(string token = default)
            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LIST_EVENT)
        {
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
        [JsonProperty("token", Order = 3)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}