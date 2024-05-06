using System.IO;

namespace Dotnet.RtspSharp.Rtcp
{
    interface ISerializablePacket
    {
        void Serialize(Stream stream);
    }
}