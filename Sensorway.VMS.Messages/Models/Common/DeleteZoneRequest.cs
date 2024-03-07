using Dotnet.OnvifSolution.Base.Models.Extends;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;

namespace Sensorway.VMS.Messages.Models.Common
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/23/2024 10:39:44 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class DeleteZoneRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public DeleteZoneRequest() : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DELETE_ZONE)
        {
        }

        public DeleteZoneRequest(CameraZoneModel model = default)
                                : base(null, EnumType.REQUEST, EnumCommand.REQUEST_DELETE_ZONE)
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
        public CameraZoneModel Body { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
