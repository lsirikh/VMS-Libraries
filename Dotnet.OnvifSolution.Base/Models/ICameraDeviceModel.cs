using Dotnet.OnvifSolution.Base.Enums;
using Sensorway.Framework.Models.Defines;
using System;

namespace Dotnet.OnvifSolution.Base.Models
{
    public interface ICameraDeviceModel : IConnectionModel, IDeviceInfoModel
    {
        void Update(ICameraDeviceModel model);
        EnumCameraType Type { get; set; }
        CameraMediaModel CameraMedia { get; set; }
        EnumCameraStatus CameraStatus { get; set; }
        DateTime UpdateTime { get; set; }
    }
}