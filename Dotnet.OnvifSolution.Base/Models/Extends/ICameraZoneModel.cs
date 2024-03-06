using Sensorway.Framework.Models.Defines;

namespace Dotnet.OnvifSolution.Base.Models.Extends
{
    public interface ICameraZoneModel : IBaseModel
    {
        string Description { get; set; }
        string Name { get; set; }
    }
}