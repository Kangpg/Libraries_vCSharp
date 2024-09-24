using SuperSocket;
using SuperSocket.SocketBase;

namespace Core.Network
{
    public interface ISessionActor
    {
        void OnConnect(Session session);
        void OnDisconnect(Session session);
        void OnRecv(Session session, PacketInfo packetInfo);
        void OnSend(Session session);
    }

    public delegate void SessionAction();

    public class Session : AppSession<Session, PacketInfo>, IDisposable
    {
        private bool _disposed = false;

        public SessionAction OnConnect { get; set; }
        public SessionAction OnDisconnect { get; set; }
        public SessionAction OnRecv { get; set; }
        public SessionAction OnSend { get; set; }

        public void Dispose()
        {
            // TODO

            GC.SuppressFinalize(this);
        }

        public void Connect()
        {
            OnConnect?.Invoke();
        }
        public void Disconnect() 
        {
            OnDisconnect?.Invoke();
        }
        public void Recv()
        {
            OnRecv?.Invoke();
        }
        public void Send()
        {
            OnSend?.Invoke();
        }
    }
}
