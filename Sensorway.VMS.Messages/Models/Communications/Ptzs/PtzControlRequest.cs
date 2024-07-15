using Dotnet.OnvifSolution.Base.Models.Components;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.Base;
using System;

namespace Sensorway.VMS.Messages.Models.Communications.Ptzs
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/16/2024 2:57:16 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PtzControlRequest : BaseCommunicationModel
    {

        #region - Ctors -
        public PtzControlRequest() : base(null, EnumType.REQUEST, EnumCommand.NONE)
        {
        }

        public PtzControlRequest(string deviceName = null
                                , PTZSpeedModel model = default
                                , string token = default
                                , EnumCommand command = EnumCommand.NONE)
                                : base(null, EnumType.REQUEST, command)
        {
            DeviceName = deviceName;
            PTZSpeed = model;
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
        [JsonProperty("device_name", Order = 3)]
        public string DeviceName { get; set; }
        [JsonProperty("ptz_speed", Order = 4)]
        public PTZSpeedModel PTZSpeed { get; set; }
        [JsonProperty("token", Order = 5)]
        public string Token { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
