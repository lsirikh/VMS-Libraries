using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Utils;
using System;

namespace Sensorway.VMS.Messages.Models.Base
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/5/2024 2:43:46 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class BaseCommunicationModel
    {

        #region - Ctors -
        public BaseCommunicationModel()
        {
        }

        public BaseCommunicationModel(string id = null, EnumType type = EnumType.NONE, EnumCommand command = EnumCommand.NONE, DateTime? dateTime = null)
        {
            Id = id ?? IdGenTool.GenIdCode();
            MessageType = type;
            Command = command;
            Time = dateTime ?? DateTime.Now;
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
        [JsonProperty("id", Order = 0)]
        public string Id { get; set; }
        [JsonProperty("message_type", Order = 1)]
        public EnumType MessageType { get; set; }
        [JsonProperty("command_type", Order = 2)]
        public EnumCommand Command { get; set; }
        [JsonProperty("time", Order = 99)]
        public DateTime? Time { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
