using Dotnet.OnvifSolution.Base.Models.Components;

namespace Dotnet.OnvifSolution.Base.Models.Focuses
{
    public interface IFocusMoveModel
    {
        AbsoluteFocusModel AbsoluteFocus { get; set; }
        ContinuousFocusModel ContinuousFocus { get; set; }
        RelativeFocusModel RelativeFocus { get; set; }
    }
}