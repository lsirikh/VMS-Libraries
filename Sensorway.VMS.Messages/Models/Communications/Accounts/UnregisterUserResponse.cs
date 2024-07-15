using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Accounts
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 1:43:38 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class UnregisterUserResponse : BaseGenericResponseModel<UnregisterUserRequest>
    {
        #region - Ctors -
        public UnregisterUserResponse() : base(null, EnumCommand.RESPONSE_UNREGISTER_USER)
        {
        }

        public UnregisterUserResponse(UnregisterUserRequest requestMessage = default,
                                            bool isSuccess = true,
                                            string message = null)
                                            : base(null, EnumCommand.RESPONSE_UNREGISTER_USER, requestMessage, isSuccess, message)
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