namespace Sensorway.Apis.TranscodingServer.Models.ResponseModels
{
    public interface IBaseResponse
    {
        string Message { get; set; }
        string Result { get; set; }
    }
}