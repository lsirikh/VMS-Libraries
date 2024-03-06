using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using System;

namespace Sensorway.VMS.Messages.Models.Base
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/15/2024 4:49:05 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class BaseResponseModel : BaseCommunicationModel
    {
        #region - Ctors -
        public BaseResponseModel() : base(null, EnumType.RESPONSE, EnumCommand.NONE)
        {
        }

        public BaseResponseModel(string id = null,
                                EnumCommand command = EnumCommand.NONE, //DEPEND ON COMMAND
                                bool isSuccess = true,
                                string message = null,
                                DateTime? time = null)
                                : base(id, EnumType.RESPONSE, command, time)
        {
            Success = isSuccess;
            Message = message;
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
        [JsonProperty("success", Order = 3)]
        public bool Success { get; set; }
        [JsonProperty("message", Order = 4)]
        public string Message { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
