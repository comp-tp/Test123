
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Caches
{

    public interface ITier2Cache
    {
        T Get<T>(string key);

        T Get<T>(string key, TimeSpan slidingExpiration);

        T Get<T>(string key, DateTime absoluteExpiration);


        ILocalCacheProvider LocalCacheProvider { get; }

        IRemoteCacheProvider RemoteCacheProvider { get; }

    }

    public class Tier2Cache : ITier2Cache
    {
        private readonly ILocalCacheProvider localCacheProvider;
        private readonly IRemoteCacheProvider remoteCacheProvider;


        public ILocalCacheProvider LocalCacheProvider { get { return this.localCacheProvider; } }

        public IRemoteCacheProvider RemoteCacheProvider { get { return this.remoteCacheProvider; } }


        public Tier2Cache(ILocalCacheProvider localCacheProvider, IRemoteCacheProvider remoteCacheProvider)
        {
            this.localCacheProvider = localCacheProvider;
            this.remoteCacheProvider = remoteCacheProvider;
        }

        public object Get(string key)
        {
            var cacheItem = localCacheProvider.Instance.Get(key);
            if (cacheItem == null) 
            {
                cacheItem = remoteCacheProvider.Instance.Get(key);
                if (cacheItem != null)
                {
                    localCacheProvider.Instance.Add(key, cacheItem);
                }
            }

            return cacheItem;
        }

        public T Get<T>(string key)
        {
            var cacheItem = localCacheProvider.Instance.Get<T>(key);
            if (cacheItem == null)
            {
                cacheItem = remoteCacheProvider.Instance.Get<T>(key);
                if (cacheItem != null)
                {
                    localCacheProvider.Instance.Add(key, cacheItem);
                }
            }
            return cacheItem;
        }

        public T Get<T>(string key, TimeSpan slidingExpiration)
        {
            var cacheItem = localCacheProvider.Instance.Get<T>(key);
            if (cacheItem == null)
            {
                cacheItem = remoteCacheProvider.Instance.Get<T>(key);
                if (cacheItem != null)
                {
                    localCacheProvider.Instance.Add(key, cacheItem, slidingExpiration);
                }
            }

            return cacheItem;
        }

        public T Get<T>(string key, DateTime absoluteExpiration)
        {
            var cacheItem = localCacheProvider.Instance.Get<T>(key);
            if (cacheItem == null)
            {
                cacheItem = remoteCacheProvider.Instance.Get<T>(key);
                if (cacheItem != null)
                {
                    localCacheProvider.Instance.Add(key, cacheItem, absoluteExpiration);
                }
            }

            return  cacheItem;
        }
    }
}
