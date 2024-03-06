using Dotnet.OnvifSolution.Base.Models;
using Sensorway.VMS.Messages.Enums;
using Sensorway.VMS.Messages.Models.MediaServers;
using System.Collections.Generic;

namespace Sensorway.VMS.Messages.Models.Devices
{
    public interface IVMSCameraModel : ICameraDeviceModel
    {
        void Update(IVMSCameraModel model);
        List<MediaServerModel> MediaServers { get; set; }
        EnumMediaServerStatus MediaServerStatus { get; set; }
    }
}