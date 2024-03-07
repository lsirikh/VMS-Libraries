using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using System;

namespace Sensorway.VMS.Messages.Models.Base
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 3/7/2024 1:18:30 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class BaseGenericResponseModel<T> : BaseCommunicationModel where T : BaseCommunicationModel
    {
        #region - Ctors -
        public BaseGenericResponseModel() : base(null, EnumType.RESPONSE, EnumCommand.NONE)
        {
        }

        public BaseGenericResponseModel(string id = null,
                                EnumCommand command = EnumCommand.NONE, //DEPEND ON COMMAND
                                T requestMessage = null, 
                                bool isSuccess = true,
                                string message = null,
                                DateTime? time = null)
                                : base(id, EnumType.RESPONSE, command, time)
        {
            RequestMessage = requestMessage;
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
        [JsonProperty("request_message", Order = 3)]
        public T RequestMessage { get; set; }
        [JsonProperty("success", Order = 4)]
        public bool Success { get; set; }
        [JsonProperty("message", Order = 5)]
        public string Message { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
