using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Communications.Focus
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/29/2024 2:31:26 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class FocusControlResponse : BaseGenericResponseModel<FocusControlRequest>
    {

        #region - Ctors -
        public FocusControlResponse() : base(null, EnumCommand.NONE)
        {
        }

        public FocusControlResponse(EnumCommand command = EnumCommand.NONE,
                                    FocusControlRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, command, requestMessage, isSuccess, message)
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
