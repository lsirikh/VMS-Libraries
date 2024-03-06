using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/8/2024 2:09:29 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PathConfigurationModel : IPathConfigurationModel
    {
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        [JsonProperty("source", Order = 2)]
        public string Source { get; set; }

        [JsonProperty("sourceFingerprint", Order = 3)]
        public string SourceFingerprint { get; set; }

        [JsonProperty("sourceOnDemand", Order = 4)]
        public bool SourceOnDemand { get; set; } = false;

        [JsonProperty("sourceOnDemandStartTimeout", Order = 5)]
        public string SourceOnDemandStartTimeout { get; set; } = "10s";

        [JsonProperty("sourceOnDemandCloseAfter", Order = 6)]
        public string SourceOnDemandCloseAfter { get; set; } = "10s";

        [JsonProperty("maxReaders", Order = 7)]
        public int MaxReaders { get; set; }

        [JsonProperty("srtReadPassphrase", Order = 8)]
        public string SrtReadPassphrase { get; set; }

        [JsonProperty("fallback", Order = 9)]
        public string Fallback { get; set; }

        [JsonProperty("record", Order = 10)]
        public bool Record { get; set; } = false;

        [JsonProperty("recordPath", Order = 11)]
        public string RecordPath { get; set; } = "./recordings/%path/%Y-%m-%d_%H-%M-%S-%f";

        [JsonProperty("recordFormat", Order = 12)]
        public string RecordFormat { get; set; } = "fmp4";

        [JsonProperty("recordPartDuration", Order = 13)]
        public string RecordPartDuration { get; set; } = "100ms";

        [JsonProperty("recordSegmentDuration", Order = 14)] 
        public string RecordSegmentDuration { get; set; } = "1h0m0s";

        [JsonProperty("recordDeleteAfter", Order = 15)]
        public string RecordDeleteAfter { get; set; } = "24h0m0s";

        [JsonProperty("publishUser", Order = 16)]
        public string PublishUser { get; set; }

        [JsonProperty("publishPass", Order = 17)]
        public string PublishPass { get; set; }

        [JsonProperty("publishIPs", Order = 18)]
        public List<string> PublishIPs { get; set; }

        [JsonProperty("readUser", Order = 19)]
        public string ReadUser { get; set; }

        [JsonProperty("readPass", Order = 20)]
        public string ReadPass { get; set; }

        [JsonProperty("readIPs", Order = 21)]
        public List<string> ReadIPs { get; set; }

        [JsonProperty("overridePublisher", Order = 22)]
        public bool OverridePublisher { get; set; } = true;

        [JsonProperty("srtPublishPassphrase", Order = 23)]
        public string SrtPublishPassphrase { get; set; }

        [JsonProperty("rtspTransport", Order = 24)]
        public string RtspTransport { get; set; } = "automatic";

        [JsonProperty("rtspAnyPort", Order = 25)]
        public bool RtspAnyPort { get; set; } = false;

        [JsonProperty("rtspRangeType", Order = 26)]
        public string RtspRangeType { get; set; }

        [JsonProperty("rtspRangeStart", Order = 27)]
        public string RtspRangeStart { get; set; }

        [JsonProperty("sourceRedirect", Order = 28)]
        public string SourceRedirect { get; set; }

        [JsonProperty("rpiCameraCamID", Order = 29)]
        public int RpiCameraCamID { get; set; } = 0;

        [JsonProperty("rpiCameraWidth", Order = 30)]
        public int RpiCameraWidth { get; set; } = 1920;

        [JsonProperty("rpiCameraHeight", Order = 31)]
        public int RpiCameraHeight { get; set; } = 1080;

        [JsonProperty("rpiCameraHFlip", Order = 32)]
        public bool RpiCameraHFlip { get; set; } = false;

        [JsonProperty("rpiCameraVFlip", Order = 33)]
        public bool RpiCameraVFlip { get; set; } = false;

        [JsonProperty("rpiCameraBrightness", Order = 34)]
        public int RpiCameraBrightness { get; set; } = 0;

        [JsonProperty("rpiCameraContrast", Order = 35)]
        public int RpiCameraContrast { get; set; } = 1;

        [JsonProperty("rpiCameraSaturation", Order = 36)]
        public int RpiCameraSaturation { get; set; } = 1;

        [JsonProperty("rpiCameraSharpness", Order = 37)]
        public int RpiCameraSharpness { get; set; } = 1;

        [JsonProperty("rpiCameraExposure", Order = 38)]
        public string RpiCameraExposure { get; set; } = "normal";

        [JsonProperty("rpiCameraAWB", Order = 39)]
        public string RpiCameraAWB { get; set; } = "auto";

        [JsonProperty("rpiCameraDenoise", Order = 40)]
        public string RpiCameraDenoise { get; set; } = "off";

        [JsonProperty("rpiCameraShutter", Order = 41)]
        public int RpiCameraShutter { get; set; } = 0;

        [JsonProperty("rpiCameraMetering", Order = 42)]
        public string RpiCameraMetering { get; set; } = "centre";

        [JsonProperty("rpiCameraGain", Order = 43)]
        public int RpiCameraGain { get; set; } = 0;

        [JsonProperty("rpiCameraEV", Order = 44)]
        public int RpiCameraEV { get; set; } = 0;

        [JsonProperty("rpiCameraROI", Order = 45)]
        public string RpiCameraROI { get; set; }

        [JsonProperty("rpiCameraHDR", Order = 46)]
        public bool RpiCameraHDR { get; set; } = false;

        [JsonProperty("rpiCameraTuningFile", Order = 47)]
        public string RpiCameraTuningFile { get; set; }

        [JsonProperty("rpiCameraMode", Order = 48)]
        public string RpiCameraMode { get; set; }

        [JsonProperty("rpiCameraFPS", Order = 49)]
        public int RpiCameraFPS { get; set; } = 30;

        [JsonProperty("rpiCameraIDRPeriod", Order = 50)]
        public int RpiCameraIDRPeriod { get; set; } = 60;

        [JsonProperty("rpiCameraBitrate", Order = 51)]
        public int RpiCameraBitrate { get; set; } = 1000000;

        [JsonProperty("rpiCameraProfile", Order = 52)]
        public string RpiCameraProfile { get; set; } = "main";

        [JsonProperty("rpiCameraLevel", Order = 53)]
        public string RpiCameraLevel { get; set; } = "4.1";

        [JsonProperty("rpiCameraAfMode", Order = 54)]
        public string RpiCameraAfMode { get; set; } = "continuous";

        [JsonProperty("rpiCameraAfRange", Order = 55)]
        public string RpiCameraAfRange { get; set; } = "normal";

        [JsonProperty("rpiCameraAfSpeed", Order = 56)]
        public string RpiCameraAfSpeed { get; set; } = "normal";

        [JsonProperty("rpiCameraLensPosition", Order = 57)]
        public int RpiCameraLensPosition { get; set; } = 0;

        [JsonProperty("rpiCameraAfWindow", Order = 58)]
        public string RpiCameraAfWindow { get; set; }

        [JsonProperty("rpiCameraTextOverlayEnable", Order = 59)]
        public bool RpiCameraTextOverlayEnable { get; set; } = false;

        [JsonProperty("rpiCameraTextOverlay", Order = 60)]
        public string RpiCameraTextOverlay { get; set; } = "%Y-%m-%d %H:%M:%S - Sensorway";

        [JsonProperty("runOnInit", Order = 61)]
        public string RunOnInit { get; set; }

        [JsonProperty("runOnInitRestart", Order = 62)]
        public bool RunOnInitRestart { get; set; } = false;

        [JsonProperty("runOnDemand", Order = 63)]
        public string RunOnDemand { get; set; }

        [JsonProperty("runOnDemandRestart", Order = 64)]
        public bool RunOnDemandRestart { get; set; } = false;

        [JsonProperty("runOnDemandStartTimeout", Order = 65)]
        public string RunOnDemandStartTimeout { get; set; } = "10s";

        [JsonProperty("runOnDemandCloseAfter", Order = 66)]
        public string RunOnDemandCloseAfter { get; set; } = "10s";

        [JsonProperty("runOnUnDemand", Order = 67)]
        public string RunOnUnDemand { get; set; }

        [JsonProperty("runOnReady", Order = 68)]
        public string RunOnReady { get; set; }

        [JsonProperty("runOnReadyRestart", Order = 69)]
        public bool RunOnReadyRestart { get; set; } = false;

        [JsonProperty("runOnNotReady", Order = 70)]
        public string RunOnNotReady { get; set; }

        [JsonProperty("runOnRead", Order = 71)]
        public string RunOnRead { get; set; }

        [JsonProperty("runOnReadRestart", Order = 72)]
        public bool RunOnReadRestart { get; set; } = false;

        [JsonProperty("runOnUnread", Order = 73)]
        public string RunOnUnread { get; set; }

        [JsonProperty("runOnRecordSegmentCreate", Order = 74)]
        public string RunOnRecordSegmentCreate { get; set; }

        [JsonProperty("runOnRecordSegmentComplete", Order = 75)]
        public string RunOnRecordSegmentComplete { get; set; }
    }
}
