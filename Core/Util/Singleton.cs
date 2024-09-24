using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        // thread safe initialization
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance => _instance.Value;

        protected Singleton() 
        { 
            if(_instance.IsValueCreated)
            {
                throw new InvalidOperationException("Already exist instance");
            }
        }
    }
}
