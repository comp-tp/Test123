//using Accela.Apps.Core.Cache;
//using Accela.Apps.Core.Cache.Providers;
using Accela.Core.Ioc;
using Accela.Infrastructure.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Cache.Redis
{
    public sealed class RedisCacheProvider : CacheStoreProvider, IRedisProvider
    {

        private static ICache Cache;
        static readonly Object _lock = new Object();

        static RedisCacheProvider()
        {
            GetCache();
        }

        /// <summary>
        /// Explicit Interface Implementation is required when IRedisProvider is being used and NOT CacheStoreProvider.
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

        private static ICache GetCache()
        {
            if (Cache == null)
            {
                lock (_lock)
                {
                    Cache = new RedisCache();
                }
            }
            return Cache;
        }

        public RedisCacheProvider()
        {

        }

        protected override ICache GetCacheStore()
        {
            return GetCache();
        }

    }
}
