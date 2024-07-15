using Dotnet.Libraries.Base;
using Sensorway.Apis.TranscodingServer.Models.RequestModels;
using System.Threading.Tasks;

namespace Sensorway.Apis.TranscodingServer.Services
{
    public interface ITranscodingService : IService
    {
        Task<string> GetMedia(TaskCompletionSource<bool> tcs = null);
        Task<string> GetSession(TaskCompletionSource<bool> tcs = null);
        Task<string> RegisterRtsp(RegisterRtspRequest model, TaskCompletionSource<bool> tcs = null);
        Task<string> UnregisterRtsp(UnregisterRtspRequest model, TaskCompletionSource<bool> tcs = null);
    }
}