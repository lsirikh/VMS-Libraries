using Newtonsoft.Json;
using Sensorway.Accounts.Base.Models;
using Sensorway.Events.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Communications.Accounts;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Events
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/29/2024 3:08:52 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ActEventResponse : BaseGenericResponseModel<ActEventRequest>
    {
        #region - Ctors -
        public ActEventResponse() : base(null, EnumCommand.RESPONSE_ACT_EVENT)
        {
        }

        public ActEventResponse(ActEventRequest requestMessage = default, bool isSuccess = true, string message = null)
                                : base(null, EnumCommand.RESPONSE_ACT_EVENT, requestMessage, isSuccess, message)
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
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}