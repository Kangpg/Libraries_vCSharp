using Core.Network;
using System.Runtime;

namespace SServer
{
    public class CustomSessionActor : ISessionActor
    {
        public void OnConnect(Session session)
        {

        }
        public void OnDisconnect(Session session)
        {

        }
        public void OnRecv(Session session, PacketInfo packetinfo)
        {

        }
        public void OnSend(Session session)
        {

        }
    }

    class Program
    {
        public static Server? server;
        static void Main(string[] args)
        {
            if (!GCSettings.IsServerGC)
            {
                throw new InvalidOperationException("Gc mode is not server");
            }

            server = new Server(new CustomSessionActor());

            server.Setup(7777);

            server.Start();

            server.Stop();
        }
    }
}