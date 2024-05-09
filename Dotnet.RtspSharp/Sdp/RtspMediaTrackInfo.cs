﻿using Dotnet.RtspSharp.Codecs;

namespace Dotnet.RtspSharp.Sdp
{
    class RtspMediaTrackInfo : RtspTrackInfo
    {
        public CodecInfo Codec { get; }
        public int SamplesFrequency { get; }

        public RtspMediaTrackInfo(string trackName, CodecInfo codec, int samplesFrequency)
            : base(trackName)
        {
            Codec = codec;
            SamplesFrequency = samplesFrequency;
        }
    }
}