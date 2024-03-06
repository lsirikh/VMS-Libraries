namespace Dotnet.OnvifSolution.Base.Models.Components
{
    public interface IAbsoluteFocusModel
    {
        float Position { get; set; }
        float Speed { get; set; }
        bool SpeedSpecified { get; set; }
    }
}