using System;

namespace Sensorway.Accounts.Base.Models
{
    public interface ILoginSessionModel : ILoginUserModel
    {
        string Token { get; set; }
        int Mode { get; set; }
        DateTime Expired { get; set; }
    }
}