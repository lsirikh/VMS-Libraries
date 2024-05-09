using System;

namespace Dotnet.RtspSharp
{
    interface ITransportStream
    {
        void Process(ArraySegment<byte> payloadSegment);
    }
}