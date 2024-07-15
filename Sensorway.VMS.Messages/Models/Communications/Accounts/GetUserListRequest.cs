using Dotnet.OnvifSolution.Base.Models;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Accounts
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 2:03:00 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class GetUserListRequest : BaseCommunicationModel
    {
        #region - Ctors -
        public GetUserListRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LIST_USER)
        {
        }

        public GetUserListRequest(string token)
                                    : base(null, EnumType.REQUEST, EnumCommand.REQUEST_LIST_USER)
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
        #endregion
        [JsonProperty("token", Order = 3)]
        public string Token { get; set; }
        #region - Attributes -
        #endregion
    }
}