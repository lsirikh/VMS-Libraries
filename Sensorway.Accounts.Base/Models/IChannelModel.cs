using Newtonsoft.Json;

namespace Sensorway.Accounts.Base.Models
{
    public interface IChannelModel : IUserBaseModel
    {
        int ClientId { get; set; }
        string Channel { get; set; }
        string IpAddress { get; set; }
    }
}