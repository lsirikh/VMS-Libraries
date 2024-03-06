using Dotnet.OnvifSolution.OnvifDeviceIo;
using Dotnet.OnvifSolution.OnvifImaging;
using Dotnet.OnvifSolution.OnvifMedia;
using Dotnet.OnvifSolution.OnvifPtz;
using System.Collections.Generic;

namespace Dotnet.OnvifSolution.Models
{
    public interface IOnvifClientModel
    {
        /// <summary>
        /// Onvif Class deviceClient
        /// From Dotnet.OnvifSolution.OnvifDeviceIo.Device
        /// </summary>
        DeviceClient DeviceClient { get; }
        /// <summary>
        /// Onvif Class mediaClient
        /// From Dotnet.OnvifSolution.OnvifMedia.Media
        /// </summary>
        MediaClient MediaClient { get; }
        /// <summary>
        /// Onvif Class ptzClient
        /// From Dotnet.OnvifSolution.OnvifPtz.PTZ
        /// </summary>
        PTZClient PtzClient { get;  }
        /// <summary>
        /// Onvif Class imagingClient
        /// From Dotnet.OnvifSolution.OnvifImaging.ImagingPort
        /// </summary>
        ImagingPortClient ImagingClient { get;  }
        /// <summary>
        /// Onvif Class profiles
        /// From http://www.onvif.org/ver10/schema
        /// </summary>
        List<Profile> Profiles { get;}


        bool IsDevicePossible { get; set; }
        bool IsMediaPossible { get; set; }
        bool IsEventPossible { get; set; }
        bool IsImagingPossible { get; set; }
        bool IsPtzPossible { get; set; }
    }
}
