using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Apps.Shared.Toolkits.Encrypt;
using Accela.Infrastructure.Caches;
using System;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Accela.Apps.Apis.Services.Handlers.Helpers
{
    /// <summary>
    /// cache helper
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        /// get cache
        /// </summary>
        /// <typeparam name="T">type of cache data</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <returns>cache result</returns>
        public static T GetCache<T>(string cacheKey) where T : class
        {
            var result = default(T);
            if (CurrentCache != null)
            {
                try
                {
                    result = CurrentCache.Get(cacheKey) as T;
                }
                catch (Exception ex)
                {
                    Log.Critical(ex.Message, ex.ToString(), "GetCache()");
                }
            }

            return result;
        }

        /// <summary>
        /// get cache
        /// </summary>
        /// <typeparam name="T">type of cache data</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <param name="fromMemoryCache"></param>
        /// <returns>cache result</returns>
        public static T GetCache<T>(string cacheKey, bool fromMemoryCache = false) where T : class
        {
            var result = default(T);
            var cacheStore = fromMemoryCache ? MemoryCache : CurrentCache;
            if (cacheStore != null)
            {
                try
                {
                    result = cacheStore.Get(cacheKey) as T;
                    //if not found get it from CacheStore, and add it to InMmemory;
                    if (fromMemoryCache && result == null)
                    {
                        result = CurrentCache.Get(cacheKey) as T;
                        if (result != null)
                        {
                            cacheStore.Put(cacheKey, result,DateTime.UtcNow.Add(TimeSpan.FromMinutes(15)));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Critical(ex.Message, ex.ToString(), "GetCache(fromMemoryCache)");
                }
            }

            return result;
        }

        /// <summary>
        /// insert cache
        /// </summary>
        /// <typeparam name="T">type of cache data</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <param name="cacheData">cache data</param>
        /// <param name="expiresInMinutes">cache duration in minutes</param>
        /// <param name="isSlidingExpiration">is sliding expiration</param>
        public static void InsertCache<T>(string cacheKey, T cacheData, int expiresInMinutes, bool isSlidingExpiration = false) where T : class
        {
            if (CurrentCache != null)
            {
                try
                {
                    if (isSlidingExpiration)
                    {
                        CurrentCache.Put(cacheKey, cacheData, TimeSpan.FromMinutes(expiresInMinutes));
                    }
                    else
                    {
                        CurrentCache.Put(cacheKey, cacheData, System.DateTime.UtcNow.AddMinutes(expiresInMinutes));
                    }
                }
                catch (Exception ex)
                {
                    Log.Critical(ex.Message, ex.ToString(), "InsertCache()");
                }
            }
        }

        private static ICache CurrentCache
        {
            get
            {
                ICache result = null;
                var cacheProvider = IocContainer.Resolve<CacheStoreProvider>();
                if (cacheProvider != null)
                {
                    result = cacheProvider.Instance;
                }
                return result;
            }
        }

        private static ICache MemoryCache
        {
            get
            {
                ICache result = null;
                var cacheProvider = IocContainer.Resolve<IMemoryCacheProvider>();
                if (cacheProvider != null)
                {
                    result = cacheProvider.Instance;
                }
                return result;
            }
        }



        private static ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }
    }
}
