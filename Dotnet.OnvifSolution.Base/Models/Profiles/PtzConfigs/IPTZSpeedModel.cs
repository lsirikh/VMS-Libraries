﻿using Dotnet.OnvifSolution.Base.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.OnvifSolution.Base.Models.Profiles.PtzConfigs
{
    public interface IPTZSpeedModel
    {
        Vector2DModel PanTilt { get; set; }
        Vector1DModel Zoom { get; set; }
    }
}
