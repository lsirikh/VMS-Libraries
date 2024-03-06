using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;

namespace Sensorway.VMS.Messages.Models.Communications
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 3/5/2024 9:37:34 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class EditCameraDeviceResponse : BaseResponseModel
    {

        #region - Ctors -
        public EditCameraDeviceResponse() : base(null, EnumCommand.RESPONSE_EDITE_CAMERA_DEVICE)
        {
        }

        public EditCameraDeviceResponse(VMSCameraModel model = default,
                                            bool isSuccess = true,
                                            string message = null)
                                            : base(null, EnumCommand.RESPONSE_EDITE_CAMERA_DEVICE, isSuccess, message)
        {
            Body = model;
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
        [JsonProperty("body", Order = 5)]
        public VMSCameraModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
