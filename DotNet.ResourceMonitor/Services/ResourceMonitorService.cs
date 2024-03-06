using Dotnet.Libraries.Base;
using DotNet.ResourceMonitor.Models;
using DotNet.ResourceMonitor.Utils;
using NvAPIWrapper.GPU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace DotNet.ResourceMonitor.Services
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/17/2024 8:17:35 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    internal class ResourceMonitorService : IResourceMonitorService
    {


        #region - Ctors -
        public ResourceMonitorService(ILogService log = default)
        {
            _log = log;
            ComputerProvider = new List<ComputerModel>();
            ProcessProvider = new List<ProcessorModel>();
            NetworkoProvider = new List<NetworkCardModel>();
            VideoProvider = new List<VideoCardModel>();
            DisplayAdapterProvider = new List<DisplayAdapterModel>();

            //var searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_DisplayConfiguration");
            //foreach (var item in searcher.Get())
            //{
            //    foreach (var property in item.Properties)
            //    {
            //        Debug.WriteLine($"Property Name : {property.Name}, Property Type : {property.Type}, Property Value : {property.Value}");
            //    }
            //    Debug.WriteLine("===========================================================");
            //}
        }
        #endregion
        #region - Implementation of Interface -
        public async Task ExecuteAsync(CancellationToken token = default)
        {
            await Initialize();
        }

        public Task StopAsync(CancellationToken token = default)
        {
            return Task.CompletedTask;
        }

        public Task Initialize()
        {
            return Task.Run(async () =>
            {
                try
                {
                    await PropertyInitialize();
                    //await BriefingProperty();
                    await CounterInialize();
                    _log.Info($"{nameof(ResourceMonitorService)} was successfully initialized.", true);
                }
                catch (Exception)
                {

                    throw;
                }
            });
        }

        private Task BriefingProperty()
        {
            foreach (ComputerModel item in ComputerProvider)
            {
                PrintModelProperties<ComputerModel>(item);
            }

            foreach (ProcessorModel item in ProcessProvider)
            {
                PrintModelProperties<ProcessorModel>(item);
            }

            foreach (NetworkCardModel item in NetworkoProvider)
            {
                PrintModelProperties<NetworkCardModel>(item);
            }

            foreach (VideoCardModel item in VideoProvider)
            {
                PrintModelProperties<VideoCardModel>(item);
            }

            foreach (DisplayAdapterModel item in DisplayAdapterProvider)
            {
                PrintModelProperties<DisplayAdapterModel>(item);
            }
            return Task.CompletedTask;
        }

        public void PrintModelProperties<T>(T model)
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                object value = property.GetValue(model, null);
                _log.Info($"{property.Name}: {value}", true);
            }
        }

        private Task PropertyInitialize()
        {
            try
            {
                UpdateInstance<ComputerModel>("Win32_ComputerSystem");
                UpdateInstance<ProcessorModel>("Win32_Processor");
                UpdateInstance<NetworkCardModel>("Win32_NetworkAdapterConfiguration");
                UpdateInstance<VideoCardModel>("Win32_VideoController");
                UpdateInstance<DisplayAdapterModel>("Win32_DisplayConfiguration");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.CompletedTask;
        }

        private void UpdateInstance<T>(string domain) where T : class, new()
        {
            try
            {
                var searcher = new ManagementObjectSearcher($"SELECT * FROM {domain}");
                
                foreach (ManagementObject item in searcher.Get())
                {
                    T model = Factory.Build<T>();

                    foreach (PropertyData property in item.Properties)
                    {
                        // Reflection을 사용하여 해당하는 PropertyData 속성을 찾고 값을 설정합니다.
                        var propertyInfo = typeof(T).GetProperty(property.Name);
                        if (propertyInfo != null && propertyInfo.CanWrite)
                        {
                            if(property.Type.ToString() == "DateTime")
                                propertyInfo.SetValue(model, Converter.ConvertToDateTime(property.Value?.ToString()), null);
                            else
                                propertyInfo.SetValue(model, property.Value, null);
                        }
                    }

                    // T가 ComputerModel이면 ComputerProvider에 추가합니다.

                    switch (model.GetType().Name)
                    {
                        case nameof(ComputerModel):
                            ComputerProvider.Add(model as ComputerModel);
                            break;
                        case nameof(ProcessorModel):
                            ProcessProvider.Add(model as ProcessorModel);
                            break;
                        case nameof(NetworkCardModel):
                            NetworkoProvider.Add(model as NetworkCardModel);
                            break;
                        case nameof(VideoCardModel):
                            VideoProvider.Add(model as VideoCardModel);
                            break;
                        case nameof(DisplayAdapterModel):
                            DisplayAdapterProvider.Add(model as DisplayAdapterModel);
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(UpdateInstance)} of {nameof(ResourceMonitorService)} : {ex.Message}");
            }
        }

        private Task CounterInialize()
        {

            try
            {
                Performance = new BasePerformanceModel();

                var netCategories = new PerformanceCounterCategory("Network Interface");
                var netInstances = netCategories.GetInstanceNames();
                foreach (var name in netInstances)
                {
                    var networkPerformance = new NetworkPerformanceModel();
                    foreach (PerformanceCounter item in netCategories.GetCounters(name))
                    {
                        networkPerformance.Description = name.ToString();
                        if (item.CounterName == "Current Bandwidth")
                            networkPerformance.NetworkBandwidth = item;
                        else if(item.CounterName == "Bytes Sent/sec")
                            networkPerformance.NetworkSendCounter = item;
                        else if (item.CounterName == "Bytes Received/sec")
                            networkPerformance.NetworkReceiveCounter = item;
                    }
                    Performance.NetworkCatergories.Add(networkPerformance);
                }

                // CPU 사용량 측정을 위한 카운터 초기화
                Performance.CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
              
                // 사용 가능한 메모리를 측정하기 위한 카운터 초기화
                Performance.RamCounter = new PerformanceCounter("Memory", "Available MBytes");

                Performance.GpuCounter = GetGPUCounters();
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(CounterInialize)} of {nameof(ResourceMonitorService)} : {ex.Message}");
            }
            return Task.CompletedTask;
        }

        public List<PerformanceCounter> GetGPUCounters()
        {
            var category = new PerformanceCounterCategory("GPU Engine");
            var counterNames = category.GetInstanceNames();
            _log.Info($"PerformanceCounterCategory for GPU Engine was initialized!");

            var isVideoDecode = counterNames.Any(counterName => counterName.EndsWith("engtype_VideoDecode"));
            var isVideoEncode = counterNames.Any(counterName => counterName.EndsWith("engtype_VideoEncode"));
            var isCompute = counterNames.Any(counterName => counterName.EndsWith("engtype_Compute"));
            var isCopy = counterNames.Any(counterName => counterName.EndsWith("engtype_Copy"));
            var is3D = counterNames.Any(counterName => counterName.EndsWith("engtype_3D"));
            _log.Info($"engtype_VideoDecode : {isVideoDecode}, engtype_VideoEncode : {isVideoEncode}, engtype_Compute : {isCompute}, engtype_Copy : {isCopy}, engtype_3D : {is3D}");

            var gpuCounters = counterNames
                                .Where(counterName =>
                                    (isVideoDecode && counterName.EndsWith("engtype_VideoDecode")) ||
                                    (isVideoEncode && counterName.EndsWith("engtype_VideoEncode")) ||
                                    (isCompute && counterName.EndsWith("engtype_Compute")) ||
                                    (isCopy && counterName.EndsWith("engtype_Copy")) ||
                                    (is3D && counterName.EndsWith("engtype_3D"))
                                )
                                .SelectMany(counterName => category.GetCounters(counterName))
                                .Where(counter => counter.CounterName.Equals("Utilization Percentage"))
                                .ToList();
            return gpuCounters;
        }
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public async Task<float> GetCpuUsage(int iteration = default, int delay = default)
        {
            float sum = 0f;
            try
            {
                if (Performance.CpuCounter == null) return sum;
                float tempSum = 0f;
                for (int index = 0; index < iteration; index++)
                {
                    tempSum += Performance.CpuCounter.NextValue();
                    if (iteration > 1)
                        await Task.Delay(delay); // 지정된 시간만큼 대기
                }
                sum = tempSum / (float)iteration;

                return sum;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(GetCpuUsage)} of {nameof(ResourceMonitorService)} : {ex.Message}");
                return sum;
            }
        }

        public async Task<float> GetRamUsage(int iteration = 1, int delay = 100)
        {
            //GB 단위로 변환
            float sum = 0f;
            try
            {
                if (Performance.RamCounter == null) return sum;
                float tempSum = 0f;
                for (int index = 0; index < iteration; index++)
                {
                    tempSum += Performance.RamCounter.NextValue();
                    if (iteration > 1)
                        await Task.Delay(delay); // 지정된 시간만큼 대기
                }
                var avgSum = tempSum / (float)iteration;
                var avbGigaByteSum = avgSum / (float)(1024);
                sum = GetTotalMemoryInGigabytes() - avbGigaByteSum;

                return sum;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(GetRamUsage)} of {nameof(ResourceMonitorService)} : {ex.Message}");
                return sum;
            }
        }

        public Task<float> GetBoardGpuUsage()
        {
            float sum = 0f;
            try
            {
                if (Performance.GpuCounter == null || !(Performance.GpuCounter.Count() > 0)) return Task.FromResult(sum);
                sum = Performance.GpuCounter.Sum(x => x.NextValue());

                return Task.FromResult(sum);
            }
            catch (Exception ex)
            {
                Performance.GpuCounter = GetGPUCounters();
                _log.Error($"Raised Exception in {nameof(GetBoardGpuUsage)} of {nameof(ResourceMonitorService)} : {ex.Message}");
                return Task.FromResult(sum);
            }
        }

        public async Task<List<GPUModel>> GetGpus()
        {
            try
            {
                List<PhysicalGPU> list = null;

                try
                {
                    list = PhysicalGPU.GetPhysicalGPUs().ToList();
                }
                catch 
                {
                }

                var boardGpuUsage = (int)(Math.Round(await GetBoardGpuUsage(), 1));

                if (list == null || list.Count == 0)
                {
                    var gpus = new List<GPUModel>();
                    var video = VideoProvider.FirstOrDefault();
                    var gpu = new GPUModel();
                    gpu.Name = video.Caption;
                    gpu.Usage = boardGpuUsage;
                    gpu.CurrentTemp = 0;
                    gpus.Add(gpu);

                    return gpus;
                }
                else
                {
                    var gpus = new List<GPUModel>();
                    
                    foreach (var item in list)
                    {
                        var gpu = new GPUModel();
                        gpu.Name = item.FullName;
                        gpu.Usage = item.UsageInformation.GPU.Percentage;
                        gpu.CurrentTemp = item.ThermalInformation.ThermalSensors.FirstOrDefault().CurrentTemperature;
                        gpus.Add(gpu);
                    }
                    return gpus;
                }
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(GetGpus)} of {nameof(ResourceMonitorService)} : {ex.Message}");
                return null;
            }
        }

        public float GetCpuSpeed()
        {
            var searcher = new ManagementObjectSearcher("select CurrentClockSpeed from Win32_Processor");
            float clockSpeed = 0f;
            foreach (var item in searcher.Get())
            {
                clockSpeed = (uint)item["CurrentClockSpeed"] / (float)1000;
            }
            //GB 단위로 변환
            return clockSpeed;
        }

        public async Task<float> GetNetworkSend(int select = 0, int iteration = 1, int delay = 100) 
        {
            try
            {
                if (!(Performance.NetworkCatergories.Count() > 0)
                    || Performance.NetworkCatergories[select].NetworkSendCounter == null) return 0f;

                float sum = 0f;
                for (int index = 0; index < iteration; index++)
                {
                    //sum += Performance.NetworkCatergories[select].NetworkSendCounter.NextValue();
                    float innerSum = 0f;
                    Performance.NetworkCatergories.ForEach(entity => 
                    {
                        innerSum += entity.NetworkSendCounter.NextValue();
                    });
                    sum += innerSum;

                    if (iteration > 1)
                        await Task.Delay(delay); // 지정된 시간만큼 대기
                }
                var avgSum = sum / (float)iteration;
                _avgSendMegaByteSum = avgSum / (float)(1024 * 1024) * 10;
                return _avgSendMegaByteSum;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(GetNetworkSend)} of {nameof(ResourceMonitorService)} : {ex.Message}");
                return 0f;
            }
            
        }

        public async Task<float> GetNetworkReceive(int select = 0, int iteration = 1, int delay = 0)
        {
            try
            {
                if (!(Performance.NetworkCatergories.Count() > 0)) return 0f;

                float sum = 0f;
                for (int index = 0; index < iteration; index++)
                {
                    //sum += Performance.NetworkCatergories[select].NetworkReceiveCounter.NextValue();
                    float innerSum = 0f;
                    Performance.NetworkCatergories.ForEach(entity =>
                    {
                        innerSum += entity.NetworkReceiveCounter.NextValue();
                    });
                    sum += innerSum;
                    if (iteration > 1)
                        await Task.Delay(delay); // 지정된 시간만큼 대기
                }
                var avgSum = sum / (float)iteration;
                _avgReceiveMegaByteSum = avgSum / (float)(1024 * 1024) * 10;
                return _avgReceiveMegaByteSum;
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(GetNetworkReceive)} of {nameof(ResourceMonitorService)} : {ex.Message}");
                return 0f;
            }

        }

        public float GetNetworkBandwidth(int select = 0)
        {
            if (!(Performance.NetworkCatergories.Count() > 0)) return 0f;

            float sum = 0f;
            Performance.NetworkCatergories.ForEach(entity =>
            {
                sum += entity.NetworkBandwidth.NextValue() / 1024 / 1024;
            });

            //var bandWidth = Performance.NetworkCatergories[select].NetworkBandwidth.NextValue() / 1024 / 1024;
            return sum;
        }

        public Task<float> GetNetworkUtilization(int select = 0)
        {
            try
            {
                if (!(Performance.NetworkCatergories.Count() > 0)) return Task.FromResult(0f);

                float bandwidth = GetNetworkBandwidth();

                float utilization = 0f;
                if (bandwidth > 0)
                {
                    utilization = (8 * (_avgSendMegaByteSum + _avgReceiveMegaByteSum)) / (bandwidth) * 100;
                }
                return Task.FromResult(utilization);
            }
            catch (Exception ex)
            {
                _log.Error($"Raised Exception in {nameof(GetNetworkUtilization)} of {nameof(ResourceMonitorService)} : {ex.Message}");
                return Task.FromResult(0f);
            }
            
        }

        public float GetTotalMemoryInGigabytes()
        {
            ulong totalMemoryInBytes = ComputerProvider.FirstOrDefault().TotalPhysicalMemory;

            var totalMemoryInMegaBytes = totalMemoryInBytes / 1024 / 1024;

            // 바이트를 기가바이트로 변환
            return totalMemoryInMegaBytes / (float)1024;
        }

        public string GetCPUName()
        {
            return ProcessProvider?.FirstOrDefault()?.Name;
        }

        public string GetNetworkName(int select = 0)
        {
            if (!(Performance.NetworkCatergories.Count() > 0)
                    || Performance.NetworkCatergories[select]?.Description == null) return null;
            return Performance.NetworkCatergories[select]?.Description;
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public BasePerformanceModel Performance { get; private set; }
        public List<ComputerModel> ComputerProvider { get; set; }
        public List<ProcessorModel> ProcessProvider { get; set; }
        public List<NetworkCardModel> NetworkoProvider { get; set; }
        public List<DisplayAdapterModel> DisplayAdapterProvider { get; set; }
        public List<VideoCardModel> VideoProvider { get; set; }
        #endregion
        #region - Attributes -
        private ILogService _log;
        private float _avgSendMegaByteSum;
        private float _avgReceiveMegaByteSum;
        //private NetworkPerformanceModel _enableNetworkPerformance;
        //private List<PerformanceCounter> _cpuCounters;
        #endregion
    }
}
