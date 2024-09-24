using System;
using System.Buffers;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace Core.Network
{
    public class ServerReceiveFilter : FixedHeaderReceiveFilter<PacketInfo>
    {
        public ServerReceiveFilter()
            : base(10)
        {

        }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            ReadOnlySpan<byte> headerSpan = new ReadOnlySpan<byte>(header, offset, length);
            // TODO
            throw new NotImplementedException();
        }

        protected override PacketInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            ReadOnlySequence<byte> dataSpan = new ReadOnlySequence<byte>(bodyBuffer, offset, length);

            throw new NotImplementedException();
        }
    }
}
