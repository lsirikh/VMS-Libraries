using System;
using Dotnet.RtspSharp.RawFrames;

namespace Dotnet.RtspSharp.MediaParsers
{
    interface IMediaPayloadParser
    {
        Action<RawFrame> FrameGenerated { get; set; }

        void Parse(TimeSpan timeOffset, ArraySegment<byte> byteSegment, bool markerBit);

        void ResetState();
    }
}