using Dotnet.OnvifSolution.Base.Models;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using Sensorway.VMS.Messages.Models.Devices;
using System;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Communications
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/7/2024 3:32:36 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GetCameraListResponse : BaseGenericResponseModel<GetCameraListRequest>
    {

        #region - Ctors -
        public GetCameraListResponse() : base(null, EnumCommand.RESPONSE_CAMERA_LIST)
        {
        }

        public GetCameraListResponse(List<VMSCameraModel> list = default,
                                    GetCameraListRequest requestMessage = default,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base(null, EnumCommand.RESPONSE_CAMERA_LIST, requestMessage, isSuccess, message)
        {
            Body = list;
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
        [JsonProperty("body", Order = 6)]
        public List<VMSCameraModel> Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
