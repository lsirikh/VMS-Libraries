using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Extends;
using Newtonsoft.Json;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.MediaServers;
using System;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Devices
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/14/2024 9:34:19 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class VMSCameraModel : CameraDeviceModel, IVMSCameraModel
    {
        public VMSCameraModel() : base()
        {
            MediaServers = new List<MediaServerModel>();
        }
        
        public VMSCameraModel(ICameraDeviceModel model) : base(model)
        {
            MediaServers = new List<MediaServerModel>();
        }
        
        public VMSCameraModel(ICameraDeviceModel model, EnumMediaServerStatus mediaStatus, List<MediaServerModel> medias) : base(model)
        {
            MediaServerStatus = mediaStatus;
            MediaServers = medias;
        }

        public VMSCameraModel(IVMSCameraModel model) : base(model)
        {
            MediaServerStatus = model.MediaServerStatus;
            MediaServers = model.MediaServers;
        }

        /// <summary>
        /// VMSCameraModel 업데이트 메소드
        /// </summary>
        /// <param name="model">IVMSCameraModel 타입</param>
        public void Update(IVMSCameraModel model)
        {
            base.Update(model);
            MediaServerStatus = model.MediaServerStatus;
            MediaServers = model.MediaServers;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// Media Server Status
        /// </summary>
        [JsonProperty("media_server_status", Order = 30)]
        public EnumMediaServerStatus MediaServerStatus { get; set; }
        /// <summary>
        /// Media Server Detail Information
        /// </summary>
        [JsonProperty("media_server", Order = 31)]
        public List<MediaServerModel> MediaServers { get; set; }
    }
}
