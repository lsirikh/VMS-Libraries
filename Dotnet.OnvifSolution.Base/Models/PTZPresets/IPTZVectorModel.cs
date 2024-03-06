﻿using Dotnet.OnvifSolution.Base.Models.Components;

namespace Dotnet.OnvifSolution.Base.Models.PTZPresets
{
    public interface IPTZVectorModel
    {
        Vector2DModel PanTilt { get; set; }
        Vector1DModel Zoom { get; set; }
    }
}