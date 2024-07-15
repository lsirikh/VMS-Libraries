namespace Sensorway.Accounts.Base.Models
{
    public interface ILoginUserModel : IUserBaseModel
    {
        string Username { get; set; }
        string Password { get; set; }
        int ClientId { get; set; }
    }
}