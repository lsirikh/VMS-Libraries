﻿using System;
using Dotnet.RtspSharp.Codecs.Audio;
using Dotnet.RtspSharp.RawFrames.Audio;

namespace Dotnet.RtspSharp.MediaParsers
{
    class PCMAudioPayloadParser : MediaPayloadParser
    {
        private readonly PCMCodecInfo _pcmCodecInfo;

        public PCMAudioPayloadParser(PCMCodecInfo pcmCodecInfo)
        {
            _pcmCodecInfo = pcmCodecInfo ?? throw new ArgumentNullException(nameof(pcmCodecInfo));
        }

        public override void Parse(TimeSpan timeOffset, ArraySegment<byte> byteSegment, bool markerBit)
        {
            DateTime timestamp = GetFrameTimestamp(timeOffset);

            var frame = new RawPCMFrame(timestamp, byteSegment, _pcmCodecInfo.SampleRate, _pcmCodecInfo.BitsPerSample,
                _pcmCodecInfo.Channels);

            OnFrameGenerated(frame);
        }

        public override void ResetState()
        {
        }
    }
}