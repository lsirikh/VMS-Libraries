using Dotnet.OnvifSolution.Base.Models;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;
using System;

namespace Sensorway.VMS.Messages.Models.Communications
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/7/2024 3:05:39 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class UnregisterCameraDeviceRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public UnregisterCameraDeviceRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_UNREGISTER_CAMERA_DEVICE)
        {
        }
        public UnregisterCameraDeviceRequest(VMSCameraModel model = default) 
                                            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_UNREGISTER_CAMERA_DEVICE)
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
        [JsonProperty("body", Order = 3)]
        public VMSCameraModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
