using Dotnet.OnvifSolution.Base.Models.Profiles;
using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.OnvifSolution.Base.Models
{
    public interface ICameraMediaModel
    {
        string Token { get; set; }
        List<CameraProfile> Profiles { get; set; }
        List<PTZPresetModel> PTZPresets { get; set; }
    }
}
