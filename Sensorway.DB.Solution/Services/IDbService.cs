using Dotnet.Libraries.Base;
using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Extends;
using Sensorway.DB.Solution.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.DB.Solution.Services
{
    public interface IDbService : IService
    {
        Task Connect(DbSetupModel setupModel);
        Task<ICameraDeviceModel> FetchCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null);
        Task<List<ICameraDeviceModel>> FetchCameraDevices(CancellationToken token = default, TaskCompletionSource<bool> tcs = null);
        Task<ICameraDeviceModel> SaveCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task SaveCameraDevices(CancellationToken token = default, TaskCompletionSource<bool> tcs = null);
        Task DeleteCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task UpdateCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<ICameraZoneModel> FetchCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task FetchCameraZones(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<ICameraZoneModel> SaveCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task SaveCameraZones(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
    }
}