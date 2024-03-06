using Autofac.Features.Metadata;
using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Extends;
using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Dotnet.OnvifSolution.OnvifDeviceIo;
using Dotnet.OnvifSolution.OnvifDeviceMgmt;
using Dotnet.OnvifSolution.OnvifImaging;
using Dotnet.OnvifSolution.OnvifMedia;
using Dotnet.OnvifSolution.OnvifPtz;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using DeviceClient = Dotnet.OnvifSolution.OnvifDeviceIo.DeviceClient;

namespace Dotnet.OnvifSolution.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 12/15/2023 5:31:34 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class CameraOnvifModel : CameraDeviceModel, ICameraOnvifModel
    {
        #region - Ctors -
        public CameraOnvifModel()
        {
        }

        public CameraOnvifModel(IConnectionModel model) : base(model)
        {
        }

        public CameraOnvifModel(ICameraDeviceModel model) : base(model)
        {
        }

        public CameraOnvifModel(ICameraDeviceModel model, DeviceClient device, MediaClient media, PTZClient ptz, ImagingPortClient imaging, List<Profile> profiles) : base(model)
        {
            DeviceClient = device;
            MediaClient = media;
            PtzClient = ptz;
            ImagingClient = imaging;
            Profiles = profiles;
        }

        public CameraOnvifModel(CameraOnvifModel model) : base(model)
        {
            IsDevicePossible = model.IsDevicePossible;
            IsMediaPossible = model.IsMediaPossible;
            IsEventPossible = model.IsEventPossible;
            ImagingClient = model.ImagingClient;
            IsPtzPossible = model.IsPtzPossible;

            DeviceClient = model.DeviceClient;
            MediaClient = model.MediaClient;
            PtzClient = model.PtzClient;
            ImagingClient = model.ImagingClient;
            Profiles = model.Profiles;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        [JsonIgnore]
        public bool IsDevicePossible { get ; set ; }
        [JsonIgnore]
        public bool IsMediaPossible { get ; set ; }
        [JsonIgnore]
        public bool IsEventPossible { get ; set ; }
        [JsonIgnore]
        public bool IsImagingPossible { get ; set ; }
        [JsonIgnore]
        public bool IsPtzPossible { get ; set ; }

        /// <summary>
        /// Onvif Class deviceClient
        /// From Dotnet.OnvifSolution.OnvifDeviceIo.Device
        /// </summary>
        [JsonIgnore]
        public DeviceClient DeviceClient { get ; set; }

        /// <summary>
        /// Onvif Class mediaClient
        /// From Dotnet.OnvifSolution.OnvifMedia.Media
        /// </summary>
        [JsonIgnore]
        public MediaClient MediaClient { get ; set; }

        /// <summary>
        /// Onvif Class ptzClient
        /// From Dotnet.OnvifSolution.OnvifPtz.PTZ
        /// </summary>
        [JsonIgnore]
        public PTZClient PtzClient { get ;  set; }

        /// <summary>
        /// Onvif Class imagingClient
        /// From Dotnet.OnvifSolution.OnvifImaging.ImagingPort
        /// </summary>
        [JsonIgnore]
        public ImagingPortClient ImagingClient { get ;  set; }

        /// <summary>
        /// Onvif Class profiles
        /// From http://www.onvif.org/ver10/schema
        /// </summary>
        [JsonIgnore]
        public List<Profile> Profiles { get ;  set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
