using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 6/3/2024 1:52:46 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class DisconnectChannelResponse : BaseGenericResponseModel<DisconnectChannelRequest>
    {

        #region - Ctors -
        public DisconnectChannelResponse() : base(null, EnumCommand.RESPONSE_DISCONNECTION_CHANNEL)
        {
        }

        public DisconnectChannelResponse(DisconnectChannelRequest requestMessage = default
                                    , bool isSuccess = true
                                    , string message = null)
                                    : base(null, EnumCommand.RESPONSE_DISCONNECTION_CHANNEL, requestMessage, isSuccess, message)
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