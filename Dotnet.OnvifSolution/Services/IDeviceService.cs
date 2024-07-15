using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Components;
using Dotnet.OnvifSolution.Base.Models.Focuses;
using Dotnet.OnvifSolution.Models;
using Dotnet.OnvifSolution.OnvifImaging;
using Dotnet.OnvifSolution.OnvifPtz;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet.OnvifSolution.Services
{
    public interface IDeviceService
    {
        Task<CameraOnvifModel> InitializePreparing(IConnectionModel connectionModel);
        Task<CameraOnvifModel> InitializePreparing(ICameraDeviceModel cameraModel);
        Task<ICameraOnvifModel> InitializeOnvif(IConnectionModel connectionModel);
        Task<ICameraOnvifModel> InitializeOnvif(ICameraDeviceModel cameraModel);
        Task<bool> GetPTZPreset(CameraMediaModel model, PTZClient ptzClient, string token);
        Task<bool> SetPTZPreset(PTZClient ptzClient, string profileToken, string presetName, string presetToken);
        Task<bool> DeletePTZPreset(PTZClient ptzClient, string profileToken, string presetToken);
        Task<bool> GoPTZPreset(PTZClient ptzClient, PTZSpeedModel pTZSpeed, string profileToken, string presetToken);
        Task<bool> SetHomePreset(PTZClient ptzClient, string profileToken);
        Task<bool> GoHomePreset(PTZClient ptzClient, PTZSpeedModel pTZSpeed, string profileToken);
        Task<bool> MovePTZ(PTZClient ptzClient, PTZSpeedModel pTZ_Velocity, string profileToken, CancellationToken token = default, string timeout = null);
        Task<bool> MovePTZ(PTZClient ptzClient, PTZSpeedModel pTZ_Velocity, string profileToken, string timeout = null);
        Task<bool> MoveImaging(ImagingPortClient imagingPortClient, string vsourceToken, FocusMoveModel focusMove, CancellationToken token = default);
        Task<bool> MoveImaging(ImagingPortClient imagingPortClient, string vsourceToken, FocusMoveModel focusMove);
        Task<bool> StopImaging(ImagingPortClient imagingPortClient, string vsourceToken);
        Task<bool> StopPTZ(PTZClient ptzClient, string profileToken, bool panTilt, bool zoom);
    }
}