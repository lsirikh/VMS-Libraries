using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Ptzs
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:57:27 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PtzControlResponse : BaseGenericResponseModel<PtzControlRequest>
    {

        #region - Ctors -
        public PtzControlResponse() : base(null, EnumCommand.NONE)
        {
        }

        public PtzControlResponse(EnumCommand command = EnumCommand.NONE,
                                    PtzControlRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base (null, command, requestMessage, isSuccess, message)
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
