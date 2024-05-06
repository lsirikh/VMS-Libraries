using System.IO;

namespace Dotnet.RtspSharp.Rtcp
{
    abstract class RtcpSdesItem
    {
        public abstract int SerializedLength { get; }

        public abstract void Serialize(Stream stream);
    }
}