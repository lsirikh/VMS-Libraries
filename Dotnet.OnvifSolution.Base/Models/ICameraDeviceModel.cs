using Dotnet.OnvifSolution.Base.Enums;
using Sensorway.Framework.Models.Defines;

namespace Dotnet.OnvifSolution.Base.Models
{
    public interface ICameraDeviceModel : IConnectionModel, IDeviceInfoModel
    {
        void Update(ICameraDeviceModel model);
        EnumCameraType Type { get; set; }
        CameraMediaModel CameraMedia { get; set; }
        EnumCameraStatus CameraStatus { get; set; }
    }
}