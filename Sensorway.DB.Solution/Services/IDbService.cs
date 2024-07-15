using Dotnet.Libraries.Base;
using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Extends;
using Sensorway.Accounts.Base.Models;
using Sensorway.DB.Solution.Models;
using Sensorway.Events.Base.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.DB.Solution.Services
{
    public interface IDbService : IService
    {
        Task Connect(DbSetupModel setupModel);
        Task<ICameraDeviceModel> FetchCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = null);
        Task<List<ICameraDeviceModel>> FetchCameraDevices(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<ICameraDeviceModel> SaveCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task SaveCameraDevices(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task UpdateCameraDevice(ICameraDeviceModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<ICameraZoneModel> FetchCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task FetchCameraZones(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<ICameraZoneModel> SaveCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task SaveCameraZones(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteCameraZone(ICameraZoneModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);


        Task<IUserModel> FetchUser(ILoginUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<IUserModel> FetchUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<List<IUserModel>> FetchUsers(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<IUserModel> SaveUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task UpdateUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteUser(IUserModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);


        Task<ILoginSessionModel> FetchSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<List<ILoginSessionModel>> FetchSessions(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<ILoginSessionModel> SaveSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task UpdateSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteSession(ILoginSessionModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);

        Task<IEventModel> FetchEvent(IEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<IEventModel> FetchEvent(int id, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<List<IEventModel>> FetchEvents(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<IEventModel> SaveEvent(IEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task UpdateEvent(IEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteEvent(IEventModel model, bool isForced = false, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);

        Task<IActionEventModel> FetchActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<List<IActionEventModel>> FetchActionEvents(DateTime from, DateTime to, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<List<IActionEventModel>> FetchActionEvents(int eventId, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<IActionEventModel> SaveActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);

        Task<IChannelModel> FetchChannel(IChannelModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<List<IChannelModel>> FetchChannels(CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task<IChannelModel> SaveChannel(IChannelModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteChannel(IChannelModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);


        Task UpdateActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteActionEvent(IActionEventModel model, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
        Task DeleteActionEvents(int eventId, CancellationToken token = default, TaskCompletionSource<bool> tcs = default);
    }
}