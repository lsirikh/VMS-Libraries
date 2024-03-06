using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/7/2024 3:06:08 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class UnregisterCameraDeviceResponse : BaseResponseModel
    {

        #region - Ctors -
        public UnregisterCameraDeviceResponse() : base(null, EnumCommand.RESPONSE_UNREGISTER_CAMERA_DEVICE)
        {
        }

        public UnregisterCameraDeviceResponse(bool isSuccess = true, string message = null)
                                            : base(null, EnumCommand.RESPONSE_UNREGISTER_CAMERA_DEVICE, isSuccess, message)
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
