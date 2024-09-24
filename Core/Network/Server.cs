using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace Core.Network
{
    public class Server : AppServer<Session, PacketInfo>
    {
        public Server(ISessionActor sessionActor)
            : base(new DefaultReceiveFilterFactory<ServerReceiveFilter, PacketInfo>())
        {
            SessionManager.Instance.Init(sessionActor ?? throw new ArgumentNullException(nameof(sessionActor)));
        }

        protected override void OnStarted()
        {
            base.OnStarted();

            this.NewSessionConnected += new SessionHandler<Session>(s => SessionManager.Instance._sessionActor!.OnConnect(s));
            this.NewRequestReceived += new RequestHandler<Session, PacketInfo>((s, p) => SessionManager.Instance._sessionActor!.OnRecv(s, p));
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }

        protected override void OnSessionClosed(Session session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
        }
    }
}
