﻿using System;

namespace Dotnet.RtspSharp.RawFrames.Video
{
    public class RawH264PFrame : RawH264Frame
    {
        public RawH264PFrame(DateTime timestamp, ArraySegment<byte> frameSegment) :
            base(timestamp, frameSegment)
        {
        }
    }
}