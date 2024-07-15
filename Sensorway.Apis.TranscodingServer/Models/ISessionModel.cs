namespace Sensorway.Apis.TranscodingServer.Models
{
    public interface ISessionModel : IRtspModel
    {
        string SessionId { get; set; }
    }
}