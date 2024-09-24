using Core.Util;
using Microsoft.Extensions.ObjectPool;
using System.Collections.Concurrent;

namespace Core.Network
{
    public class SessionManager : Singleton<SessionManager>
    {
        public ISessionActor? _sessionActor;

        // session dictionary
        private ConcurrentDictionary<ulong, Session> _sessionDic = new ConcurrentDictionary<ulong, Session>();

        private LimitedObjectPool<Session> _sessionPool = new LimitedObjectPool<Session>();

        public void Init(ISessionActor sessionActor)
        {
            _sessionActor = sessionActor;
        }
    }
}
