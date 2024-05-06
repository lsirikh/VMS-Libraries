using System;

namespace Dotnet.RtspSharp.Rtsp
{
    [Serializable]
    public class RtspBadResponseException : RtspClientException
    {
        public RtspBadResponseException(string message) : base(message)
        {
        }
    }
}