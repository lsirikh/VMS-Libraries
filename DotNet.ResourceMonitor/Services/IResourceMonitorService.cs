using Dotnet.Libraries.Base;
using DotNet.ResourceMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.ResourceMonitor.Services
{
    public interface IResourceMonitorService : IService
    {
        Task Initialize();
        string GetCPUName();
        float GetCpuSpeed();
        float GetTotalMemoryInGigabytes();
        Task<float> GetCpuUsage(int iteration = 5, int delay = 100);
        Task<float> GetRamUsage(int iteration = 1, int delay = 100);
        Task<float> GetBoardGpuUsage();
        Task<List<GPUModel>> GetGpus();
        string GetNetworkName(int select = 0);
        float GetNetworkBandwidth(int select = 0);
        Task<float> GetNetworkReceive(int select = 0, int iteration = 1, int delay = 100);
        Task<float> GetNetworkSend(int select = 0, int iteration = 1, int delay = 100);
        Task<float> GetNetworkUtilization(int select = 0);
        BasePerformanceModel Performance { get; }
        List<ComputerModel> ComputerProvider { get; }
        List<ProcessorModel> ProcessProvider { get; }
        List<NetworkCardModel> NetworkoProvider { get;  }
        List<VideoCardModel> VideoProvider { get; }
    }
}