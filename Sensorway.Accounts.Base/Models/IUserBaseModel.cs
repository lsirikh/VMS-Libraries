using Sensorway.Framework.Models.Defines;
using System;

namespace Sensorway.Accounts.Base.Models
{
    public interface IUserBaseModel : IBaseModel
    {
        DateTime Created { get; set; }
    }
}