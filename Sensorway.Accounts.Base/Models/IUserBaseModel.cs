using System;

namespace Sensorway.Accounts.Base.Models
{
    public interface IUserBaseModel
    {
        int Id { get; set; }
        DateTime Created { get; set; }
    }
}