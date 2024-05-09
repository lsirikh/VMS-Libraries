using System;

namespace Dotnet.RtspSharp.Rtcp
{
    interface IRtcpSenderStatisticsProvider
    {
        DateTime LastTimeReportReceived { get; }
        long LastNtpTimeReportReceived { get; }
    }
}