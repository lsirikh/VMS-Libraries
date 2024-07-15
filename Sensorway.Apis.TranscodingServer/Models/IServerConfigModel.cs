using Newtonsoft.Json;

namespace Sensorway.Apis.TranscodingServer.Models
{
    public interface IServerConfigModel
    {
        string IpAddress { get; set; }
        string Name { get; set; }
        string PortAPI { get; set; }
        string PortRTSP { get; set; }
        string Status { get; set; }
        string Version { get; set; }

        void update(ServerConfigModel model);
    }
}