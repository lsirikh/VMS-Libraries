namespace Sensorway.Apis.TranscodingServer.Models
{
    public interface IRtspModel : IRtspIdModel
    {
        string Uri { get; set; }
    }
}