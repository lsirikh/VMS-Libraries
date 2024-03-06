using Dotnet.OnvifSolution.Base.Models;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/5/2024 1:44:27 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class RegisterCameraDeviceRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public RegisterCameraDeviceRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_REGISTER_CAMERA_DEVICE)
        {
        }

        public RegisterCameraDeviceRequest(ConnectionModel model = default) 
                                            : base(null, EnumType.REQUEST, EnumCommand.REQUEST_REGISTER_CAMERA_DEVICE)
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
        public ConnectionModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
