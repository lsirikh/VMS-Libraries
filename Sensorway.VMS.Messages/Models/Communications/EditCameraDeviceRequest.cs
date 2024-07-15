using Dotnet.OnvifSolution.Base.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;

namespace Sensorway.VMS.Messages.Models.Communications
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 3/5/2024 9:37:18 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class EditCameraDeviceRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public EditCameraDeviceRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_EDITE_CAMERA_DEVICE)
        {
        }

        public EditCameraDeviceRequest(VMSCameraModel model = default
                                        , string token = default)
                                        : base(null, EnumType.REQUEST, EnumCommand.REQUEST_EDITE_CAMERA_DEVICE)
        {
            Body = model;
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
        [JsonProperty("body", Order = 3)]
        public VMSCameraModel Body { get; set; }
        [JsonProperty("token", Order = 4)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
