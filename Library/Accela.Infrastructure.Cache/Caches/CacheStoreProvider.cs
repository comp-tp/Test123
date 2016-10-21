using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Caches
{
    /// <summary>
    /// Base class for cache provider
    /// IoC registration must use <CacheProviderBase></CacheProviderBase>
    /// </summary>
    public abstract class CacheStoreProvider : ICacheProvider
    {
        private static ICache Cache;
        static readonly Object _lock = new Object();

        public virtual ICache Instance
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

        protected internal abstract ICache GetCacheStore();
    }
}
