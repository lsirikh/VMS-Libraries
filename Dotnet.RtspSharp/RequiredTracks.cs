using System;

namespace Dotnet.RtspSharp
{
    [Flags]
    public enum RequiredTracks
    {
        Video = 1,
        Audio = 2,
        All = Video | Audio
    }
}