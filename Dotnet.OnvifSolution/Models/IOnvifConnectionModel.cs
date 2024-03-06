namespace Dotnet.OnvifSolution.Models
{
    public interface IOnvifConnectionModel
    {
        string Host { get; set; }
        string Password { get; set; }
        string Username { get; set; }
    }
}