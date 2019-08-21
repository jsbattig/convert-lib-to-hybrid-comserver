using System.Runtime.Caching;
using System;

namespace Ascentis.ExternalCache
{
    public class ExternalCache : System.EnterpriseServices.ServicedComponent
    {
        private MemoryCache _cache;

        public ExternalCache()
        {
            _cache = new MemoryCache(GetHashCode().ToString());
        }

        public bool Add(string key, object item)
        {
            return _cache.Add(new CacheItem(key, item), null);
        }

        public object AddOrGetExisting(string key, object value)
        {
            return _cache.AddOrGetExisting(key, value, null);
        }

        public bool Contains(string key)
        {
            return _cache.Contains(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public object Remove(string key)
        {
            return _cache.Remove(key);
        }

        public void Set(string key, object value, DateTimeOffset absoluteExpiration)
        {
            _cache.Set(key, value, absoluteExpiration);
        }
    }
}
