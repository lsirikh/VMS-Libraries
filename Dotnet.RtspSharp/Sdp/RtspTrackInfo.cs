﻿namespace Dotnet.RtspSharp.Sdp
{
    abstract class RtspTrackInfo
    {
        public string TrackName { get; }

        protected RtspTrackInfo(string trackName)
        {
            TrackName = trackName;
        }
    }
}