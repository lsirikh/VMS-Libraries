using Dotnet.RtspSharp.Utils;

namespace Dotnet.RtspSharp.Rtp
{
    internal interface IRtpSequenceAssembler
    {
        RefAction<RtpPacket> PacketPassed { get; set; }

        void ProcessPacket(ref RtpPacket rtpPacket);
    }
}