using System;

namespace Dotnet.RtspSharp.Rtsp
{
    [Serializable]
    public class RtspParseResponseException : RtspClientException
    {
        public RtspParseResponseException(string message) : base(message)
        {
        }
    }
}