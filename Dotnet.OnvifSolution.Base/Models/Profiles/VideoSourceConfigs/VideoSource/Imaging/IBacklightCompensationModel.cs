﻿using Dotnet.OnvifSolution.Base.Enums;
using Dotnet.OnvifSolution.Base.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.OnvifSolution.Base.Models.Profiles.VideoSourceConfigs.VideoSource.Imaging
{
    public interface IBacklightCompensationModel
    {
        EnumBacklightCompensationMode Mode { get; set; }
        float Level { get; set; }
        LevelModel LevelRange { get; set; }
        bool LevelSpecified { get; set; }
    }
}
