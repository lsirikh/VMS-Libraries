using Dotnet.Libraries.Base;
using Sensorway.Apis.MediaMTX.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Apis.MediaMTX.Services
{
    public interface IMediaMTXService : IService
    {
        Task BuildLookupTabel();
        IEnumerable<LookupModel> LookupTable { get; }
        Task<string> GetGlobalConfiguration(TaskCompletionSource<bool> tcs = default);
        Task<bool> SetGlobalConfiguration(string content);
        Task<string> GetPathConfiguration(TaskCompletionSource<bool> tcs = default);
        Task<bool> SetPathConfiguration(string content);

        Task<string> GetPathConfiguration(string name, TaskCompletionSource<bool> tcs = default);
        Task<string> GetAllPathConfiguration(TaskCompletionSource<bool> tcs = default);
        Task<bool> AddPathConfigurateion(PathConfigurationModel model);
        Task<bool> DeletePathConfigurateion(string name);
        Task<bool> PatchPathConfiguration(string name, string json);
        Task<bool> ReplacePathConfiguration(PathConfigurationModel model);

        Task<string> GetPath(string name, TaskCompletionSource<bool> tcs = default);
        Task<string> GetAllPath(TaskCompletionSource<bool> tcs = default);
    }
}