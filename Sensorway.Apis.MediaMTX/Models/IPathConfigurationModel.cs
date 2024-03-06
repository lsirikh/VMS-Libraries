using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    public interface IPathConfigurationModel
    {
        string Fallback { get; set; }
        int MaxReaders { get; set; }
        string Name { get; set; }
        bool OverridePublisher { get; set; }
        List<string> PublishIPs { get; set; }
        string PublishPass { get; set; }
        string PublishUser { get; set; }
        List<string> ReadIPs { get; set; }
        string ReadPass { get; set; }
        string ReadUser { get; set; }
        bool Record { get; set; }
        string RecordDeleteAfter { get; set; }
        string RecordFormat { get; set; }
        string RecordPartDuration { get; set; }
        string RecordPath { get; set; }
        string RecordSegmentDuration { get; set; }
        string RpiCameraAfMode { get; set; }
        string RpiCameraAfRange { get; set; }
        string RpiCameraAfSpeed { get; set; }
        string RpiCameraAfWindow { get; set; }
        string RpiCameraAWB { get; set; }
        int RpiCameraBitrate { get; set; }
        int RpiCameraBrightness { get; set; }
        int RpiCameraCamID { get; set; }
        int RpiCameraContrast { get; set; }
        string RpiCameraDenoise { get; set; }
        int RpiCameraEV { get; set; }
        string RpiCameraExposure { get; set; }
        int RpiCameraFPS { get; set; }
        int RpiCameraGain { get; set; }
        bool RpiCameraHDR { get; set; }
        int RpiCameraHeight { get; set; }
        bool RpiCameraHFlip { get; set; }
        int RpiCameraIDRPeriod { get; set; }
        int RpiCameraLensPosition { get; set; }
        string RpiCameraLevel { get; set; }
        string RpiCameraMetering { get; set; }
        string RpiCameraMode { get; set; }
        string RpiCameraProfile { get; set; }
        string RpiCameraROI { get; set; }
        int RpiCameraSaturation { get; set; }
        int RpiCameraSharpness { get; set; }
        int RpiCameraShutter { get; set; }
        string RpiCameraTextOverlay { get; set; }
        bool RpiCameraTextOverlayEnable { get; set; }
        string RpiCameraTuningFile { get; set; }
        bool RpiCameraVFlip { get; set; }
        int RpiCameraWidth { get; set; }
        bool RtspAnyPort { get; set; }
        string RtspRangeStart { get; set; }
        string RtspRangeType { get; set; }
        string RtspTransport { get; set; }
        string RunOnDemand { get; set; }
        string RunOnDemandCloseAfter { get; set; }
        bool RunOnDemandRestart { get; set; }
        string RunOnDemandStartTimeout { get; set; }
        string RunOnInit { get; set; }
        bool RunOnInitRestart { get; set; }
        string RunOnNotReady { get; set; }
        string RunOnRead { get; set; }
        bool RunOnReadRestart { get; set; }
        string RunOnReady { get; set; }
        bool RunOnReadyRestart { get; set; }
        string RunOnRecordSegmentComplete { get; set; }
        string RunOnRecordSegmentCreate { get; set; }
        string RunOnUnDemand { get; set; }
        string RunOnUnread { get; set; }
        string Source { get; set; }
        string SourceFingerprint { get; set; }
        bool SourceOnDemand { get; set; }
        string SourceOnDemandCloseAfter { get; set; }
        string SourceOnDemandStartTimeout { get; set; }
        string SourceRedirect { get; set; }
        string SrtPublishPassphrase { get; set; }
        string SrtReadPassphrase { get; set; }
    }
}