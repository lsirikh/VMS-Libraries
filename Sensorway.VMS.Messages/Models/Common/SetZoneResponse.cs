using Dotnet.OnvifSolution.Base.Models.Extends;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/23/2024 10:39:32 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SetZoneResponse : BaseGenericResponseModel<SetZoneRequest>
    {

        #region - Ctors -
        public SetZoneResponse() : base(null, EnumCommand.RESPONSE_SET_ZONE)
        {
        }

        public SetZoneResponse(List<CameraZoneModel> list = default
                                , SetZoneRequest requestMessage = default       
                                , bool isSuccess = true
                                , string message = null)
                                : base(null, EnumCommand.RESPONSE_SET_ZONE, requestMessage, isSuccess, message)
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
        public List<CameraZoneModel> Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
