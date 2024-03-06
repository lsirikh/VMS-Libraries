using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Ptzs
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:57:27 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PtzControlResponse : BaseResponseModel
    {

        #region - Ctors -
        public PtzControlResponse() : base(null, EnumCommand.NONE)
        {
        }

        public PtzControlResponse(string deviceName = null,
                                    EnumCommand command = EnumCommand.NONE,
                                    bool isSuccess = true,
                                    string message = null)
                                    : base (null, command, isSuccess, message)
        {
            DeviceName = deviceName;
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
        [JsonProperty("device_name", Order = 5)]
        public string DeviceName { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
