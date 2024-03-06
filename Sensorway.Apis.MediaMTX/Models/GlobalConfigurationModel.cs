using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sensorway.Apis.MediaMTX.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/8/2024 1:27:57 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GlobalConfigurationModel : IGlobalConfigurationModel
    {
        public void update(GlobalConfigurationModel model)
        {
            LogLevel = model.LogLevel;
            LogDestinations = new List<string>(model.LogDestinations);
            LogFile = model.LogFile;
            ReadTimeout = model.ReadTimeout;
            WriteTimeout = model.WriteTimeout;
            WriteQueueSize = model.WriteQueueSize;
            UdpMaxPayloadSize = model.UdpMaxPayloadSize;
            ExternalAuthenticationURL = model.ExternalAuthenticationURL;
            Api = model.Api;
            ApiAddress = model.ApiAddress;
            Metrics = model.Metrics;
            MetricsAddress = model.MetricsAddress;
            Pprof = model.Pprof;
            PprofAddress = model.PprofAddress;
            RunOnConnect = model.RunOnConnect;
            RunOnConnectRestart = model.RunOnConnectRestart;
            RunOnDisconnect = model.RunOnDisconnect;
            Rtsp = model.Rtsp;
            Protocols = new List<string>(model.Protocols);
            Encryption = model.Encryption;
            RtspAddress = model.RtspAddress;
            RtspsAddress = model.RtspsAddress;
            RtpAddress = model.RtpAddress;
            RtcpAddress = model.RtcpAddress;
            MulticastIPRange = model.MulticastIPRange;
            MulticastRTPPort = model.MulticastRTPPort;
            MulticastRTCPPort = model.MulticastRTCPPort;
            ServerKey = model.ServerKey;
            ServerCert = model.ServerCert;
            AuthMethods = new List<string>(model.AuthMethods);
            Rtmp = model.Rtmp;
            RtmpAddress = model.RtmpAddress;
            RtmpEncryption = model.RtmpEncryption;
            RtmpsAddress = model.RtmpsAddress;
            RtmpServerKey = model.RtmpServerKey;
            RtmpServerCert = model.RtmpServerCert;
            Hls = model.Hls;
            HlsAddress = model.HlsAddress;
            HlsEncryption = model.HlsEncryption;
            HlsServerKey = model.HlsServerKey;
            HlsServerCert = model.HlsServerCert;
            HlsAlwaysRemux = model.HlsAlwaysRemux;
            HlsVariant = model.HlsVariant;
            HlsSegmentCount = model.HlsSegmentCount;
            HlsSegmentDuration = model.HlsSegmentDuration;
            HlsPartDuration = model.HlsPartDuration;
            HlsSegmentMaxSize = model.HlsSegmentMaxSize;
            HlsAllowOrigin = model.HlsAllowOrigin;
            HlsTrustedProxies = new List<string>(model.HlsTrustedProxies);
            HlsDirectory = model.HlsDirectory;
            WebRtc = model.WebRtc;
            WebRtcAddress = model.WebRtcAddress;
            WebRtcEncryption = model.WebRtcEncryption;
            WebRtcServerKey = model.WebRtcServerKey;
            WebRtcServerCert = model.WebRtcServerCert;
            WebRtcAllowOrigin = model.WebRtcAllowOrigin;
            WebRtcTrustedProxies = new List<string>(model.WebRtcTrustedProxies);
            WebRtcLocalUDPAddress = model.WebRtcLocalUDPAddress;
            WebRtcLocalTCPAddress = model.WebRtcLocalTCPAddress;
            WebRtcIPsFromInterfaces = model.WebRtcIPsFromInterfaces;
            WebRtcIPsFromInterfacesList = new List<string>(model.WebRtcIPsFromInterfacesList);
            WebRtcAdditionalHosts = new List<string>(model.WebRtcAdditionalHosts);
            WebRtcICEServers2 = new List<string>(model.WebRtcICEServers2);
            Srt = model.Srt;
            SrtAddress = model.SrtAddress;
        }

        [JsonProperty("logLevel", Order = 1)]
        public string LogLevel { get; set; }

        [JsonProperty("logDestinations", Order = 2)]
        public List<string> LogDestinations { get; set; }

        [JsonProperty("logFile", Order = 3)]
        public string LogFile { get; set; }

        [JsonProperty("readTimeout", Order = 4)]
        public string ReadTimeout { get; set; }

        [JsonProperty("writeTimeout", Order = 5)]
        public string WriteTimeout { get; set; }

        [JsonProperty("writeQueueSize", Order = 6)]
        public int WriteQueueSize { get; set; }

        [JsonProperty("udpMaxPayloadSize", Order = 7)]
        public int UdpMaxPayloadSize { get; set; }

        [JsonProperty("externalAuthenticationURL", Order = 8)]
        public string ExternalAuthenticationURL { get; set; }

        [JsonProperty("api", Order = 9)]
        public bool Api { get; set; }

        [JsonProperty("apiAddress", Order = 10)]
        public string ApiAddress { get; set; }

        [JsonProperty("metrics", Order = 11)]
        public bool Metrics { get; set; }

        [JsonProperty("metricsAddress", Order = 12)]
        public string MetricsAddress { get; set; }

        [JsonProperty("pprof", Order = 13)]
        public bool Pprof { get; set; }

        [JsonProperty("pprofAddress", Order = 14)]
        public string PprofAddress { get; set; }

        [JsonProperty("runOnConnect", Order = 15)]
        public string RunOnConnect { get; set; }

        [JsonProperty("runOnConnectRestart", Order = 16)]
        public bool RunOnConnectRestart { get; set; }

        [JsonProperty("runOnDisconnect", Order = 17)]
        public string RunOnDisconnect { get; set; }

        [JsonProperty("rtsp", Order = 18)]
        public bool Rtsp { get; set; }

        [JsonProperty("protocols", Order = 19)]
        public List<string> Protocols { get; set; }

        [JsonProperty("encryption", Order = 20)]
        public string Encryption { get; set; }

        [JsonProperty("rtspAddress", Order = 21)]
        public string RtspAddress { get; set; }

        [JsonProperty("rtspsAddress", Order = 22)]
        public string RtspsAddress { get; set; }

        [JsonProperty("rtpAddress", Order = 23)]
        public string RtpAddress { get; set; }

        [JsonProperty("rtcpAddress", Order = 24)]
        public string RtcpAddress { get; set; }

        [JsonProperty("multicastIPRange", Order = 25)]
        public string MulticastIPRange { get; set; }

        [JsonProperty("multicastRTPPort", Order = 26)]
        public int MulticastRTPPort { get; set; }

        [JsonProperty("multicastRTCPPort", Order = 27)]
        public int MulticastRTCPPort { get; set; }

        [JsonProperty("serverKey", Order = 28)]
        public string ServerKey { get; set; }

        [JsonProperty("serverCert", Order = 29)]
        public string ServerCert { get; set; }

        [JsonProperty("authMethods", Order = 30)]
        public List<string> AuthMethods { get; set; }

        [JsonProperty("rtmp", Order = 31)]
        public bool Rtmp { get; set; }

        [JsonProperty("rtmpAddress", Order = 32)]
        public string RtmpAddress { get; set; }

        [JsonProperty("rtmpEncryption", Order = 33)]
        public string RtmpEncryption { get; set; }

        [JsonProperty("rtmpsAddress", Order = 34)]
        public string RtmpsAddress { get; set; }

        [JsonProperty("rtmpServerKey", Order = 35)]
        public string RtmpServerKey { get; set; }

        [JsonProperty("rtmpServerCert", Order = 36)]
        public string RtmpServerCert { get; set; }

        [JsonProperty("hls", Order = 37)]
        public bool Hls { get; set; }

        [JsonProperty("hlsAddress", Order = 38)]
        public string HlsAddress { get; set; }

        [JsonProperty("hlsEncryption", Order = 39)]
        public bool HlsEncryption { get; set; }

        [JsonProperty("hlsServerKey", Order = 40)]
        public string HlsServerKey { get; set; }

        [JsonProperty("hlsServerCert", Order = 41)]
        public string HlsServerCert { get; set; }

        [JsonProperty("hlsAlwaysRemux", Order = 42)]
        public bool HlsAlwaysRemux { get; set; }

        [JsonProperty("hlsVariant", Order = 43)]
        public string HlsVariant { get; set; }

        [JsonProperty("hlsSegmentCount", Order = 44)]
        public int HlsSegmentCount { get; set; }

        [JsonProperty("hlsSegmentDuration", Order = 45)]
        public string HlsSegmentDuration { get; set; }

        [JsonProperty("hlsPartDuration", Order = 46)]
        public string HlsPartDuration { get; set; }

        [JsonProperty("hlsSegmentMaxSize", Order = 47)]
        public string HlsSegmentMaxSize { get; set; }

        [JsonProperty("hlsAllowOrigin", Order = 48)]
        public string HlsAllowOrigin { get; set; }

        [JsonProperty("hlsTrustedProxies", Order = 49)]
        public List<string> HlsTrustedProxies { get; set; }

        [JsonProperty("hlsDirectory", Order = 50)]
        public string HlsDirectory { get; set; }

        [JsonProperty("webrtc", Order = 51)]
        public bool WebRtc { get; set; }

        [JsonProperty("webrtcAddress", Order = 52)]
        public string WebRtcAddress { get; set; }

        [JsonProperty("webrtcEncryption", Order = 53)]
        public bool WebRtcEncryption { get; set; }

        [JsonProperty("webrtcServerKey", Order = 54)]
        public string WebRtcServerKey { get; set; }

        [JsonProperty("webrtcServerCert", Order = 55)]
        public string WebRtcServerCert { get; set; }

        [JsonProperty("webrtcAllowOrigin", Order = 56)]
        public string WebRtcAllowOrigin { get; set; }

        [JsonProperty("webrtcTrustedProxies", Order = 57)]
        public List<string> WebRtcTrustedProxies { get; set; }

        [JsonProperty("webrtcLocalUDPAddress", Order = 58)]
        public string WebRtcLocalUDPAddress { get; set; }

        [JsonProperty("webrtcLocalTCPAddress", Order = 59)]
        public string WebRtcLocalTCPAddress { get; set; }

        [JsonProperty("webrtcIPsFromInterfaces", Order = 60)]
        public bool WebRtcIPsFromInterfaces { get; set; }

        [JsonProperty("webrtcIPsFromInterfacesList", Order = 61)]
        public List<string> WebRtcIPsFromInterfacesList { get; set; }

        [JsonProperty("webrtcAdditionalHosts", Order = 62)]
        public List<string> WebRtcAdditionalHosts { get; set; }

        [JsonProperty("webrtcICEServers2", Order = 63)]
        public List<string> WebRtcICEServers2 { get; set; }

        [JsonProperty("srt", Order = 64)]
        public bool Srt { get; set; }

        [JsonProperty("srtAddress", Order = 65)]
        public string SrtAddress { get; set; }
    }
}
