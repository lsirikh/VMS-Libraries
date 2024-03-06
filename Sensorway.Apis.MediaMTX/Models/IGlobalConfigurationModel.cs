using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    public interface IGlobalConfigurationModel
    {
        bool Api { get; set; }
        string ApiAddress { get; set; }
        List<string> AuthMethods { get; set; }
        string Encryption { get; set; }
        string ExternalAuthenticationURL { get; set; }
        bool Hls { get; set; }
        string HlsAddress { get; set; }
        string HlsAllowOrigin { get; set; }
        bool HlsAlwaysRemux { get; set; }
        string HlsDirectory { get; set; }
        bool HlsEncryption { get; set; }
        string HlsPartDuration { get; set; }
        int HlsSegmentCount { get; set; }
        string HlsSegmentDuration { get; set; }
        string HlsSegmentMaxSize { get; set; }
        string HlsServerCert { get; set; }
        string HlsServerKey { get; set; }
        List<string> HlsTrustedProxies { get; set; }
        string HlsVariant { get; set; }
        List<string> LogDestinations { get; set; }
        string LogFile { get; set; }
        string LogLevel { get; set; }
        bool Metrics { get; set; }
        string MetricsAddress { get; set; }
        string MulticastIPRange { get; set; }
        int MulticastRTCPPort { get; set; }
        int MulticastRTPPort { get; set; }
        bool Pprof { get; set; }
        string PprofAddress { get; set; }
        List<string> Protocols { get; set; }
        string ReadTimeout { get; set; }
        string RtcpAddress { get; set; }
        bool Rtmp { get; set; }
        string RtmpAddress { get; set; }
        string RtmpEncryption { get; set; }
        string RtmpsAddress { get; set; }
        string RtmpServerCert { get; set; }
        string RtmpServerKey { get; set; }
        string RtpAddress { get; set; }
        bool Rtsp { get; set; }
        string RtspAddress { get; set; }
        string RtspsAddress { get; set; }
        string RunOnConnect { get; set; }
        bool RunOnConnectRestart { get; set; }
        string RunOnDisconnect { get; set; }
        string ServerCert { get; set; }
        string ServerKey { get; set; }
        bool Srt { get; set; }
        string SrtAddress { get; set; }
        int UdpMaxPayloadSize { get; set; }
        bool WebRtc { get; set; }
        List<string> WebRtcAdditionalHosts { get; set; }
        string WebRtcAddress { get; set; }
        string WebRtcAllowOrigin { get; set; }
        bool WebRtcEncryption { get; set; }
        List<string> WebRtcICEServers2 { get; set; }
        bool WebRtcIPsFromInterfaces { get; set; }
        List<string> WebRtcIPsFromInterfacesList { get; set; }
        string WebRtcLocalTCPAddress { get; set; }
        string WebRtcLocalUDPAddress { get; set; }
        string WebRtcServerCert { get; set; }
        string WebRtcServerKey { get; set; }
        List<string> WebRtcTrustedProxies { get; set; }
        int WriteQueueSize { get; set; }
        string WriteTimeout { get; set; }
    }
}