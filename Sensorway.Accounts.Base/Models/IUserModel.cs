using Sensorway.Accounts.Base.Enums;
using System;

namespace Sensorway.Accounts.Base.Models
{
    public interface IUserModel : IUserBaseModel
    {
        string Username { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        EnumUserLevel Level { get; set; }
        bool Used { get; set; }
    }
}