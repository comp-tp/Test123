using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Caches
{
    public sealed class MemoryCacheStoreProvider : CacheStoreProvider, IMemoryCacheProvider
    {

        private static ICache Cache;
        static readonly Object _lock = new Object();

        static MemoryCacheStoreProvider()
        {
            GetCache();
        }

        /// <summary>
        /// Explicit Interface Implementation is required when IMemoryCacheProvider is being used and NOT CacheStoreProvider.
        /// </summary>
        public override ICache Instance
        {
            get
            {
                if (Cache == null)
                {
                    lock (_lock)
                    {
                        Cache = GetCacheStore();
                    }
                }
                return Cache;
            }
        }

        public MemoryCacheStoreProvider()
        {
            //Cache = GetCache();
        }

        private static ICache GetCache()
        {
            if (Cache == null)
            {
                lock (_lock)
                {
                    //todo: add cahce policy
                    Cache = new InMemoryCache(new CacheItemPolicy { AbsoluteExpiration = DateTime.UtcNow.AddHours(24) });
                }
            }
            return Cache;
        }


        protected override ICache GetCacheStore()
        {
            return GetCache();
        }
    }
}
