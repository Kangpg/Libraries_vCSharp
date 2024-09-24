using Microsoft.Extensions.ObjectPool;
using System.Collections.Concurrent;

namespace Core.Util
{
    public class LimitedObjectPool<T> : ObjectPool<T> where T : class, IDisposable, new()
    {
        private readonly ConcurrentBag<T>   _objects = new ConcurrentBag<T>();
        private readonly object             _lock = new object();
        private readonly int                _maxCount = 1000;

        public LimitedObjectPool()
        {
            for (int i = 0; i < _maxCount; i++)
            {
                _objects.Add(new T());
            }
        }

        public override T Get()
        {
            if (_objects.TryTake(out T? obj))
            {
                return obj;
            }

            return null!;
        }

        public override void Return(T obj)
        {
            lock (_lock)
            {
                if (_objects.Count < _maxCount)
                {
                    _objects.Add(obj);
                }
            }
        }
    }
}
