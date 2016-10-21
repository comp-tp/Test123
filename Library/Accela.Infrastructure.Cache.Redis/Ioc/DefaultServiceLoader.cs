using Accela.Infrastructure.Cache.Redis;
using Accela.Infrastructure.Caches;
using System;

namespace Accela.Core.Ioc
{
    public class DefaultServiceLoader : IServiceLoader
    {
        public int SortOrder
        {
            //should be loaded before everyone else
            get { return Int32.MinValue; }
        }

        public void Load(IServiceLocator container)
        {
            container.RegisterWithRegistration<RedisCacheProvider>(ServiceLifecycle.Singleton, typeof(CacheStoreProvider), typeof(IRedisProvider), typeof(IRemoteCacheProvider),typeof(ICacheProvider));
            //container.Register<CacheStoreProvider, RedisCacheProvider>(ServiceLifecycle.Singleton);
            //container.Register<IRedisProvider, RedisCacheProvider>(ServiceLifecycle.Singleton);
            //container.Register<IRemoteCacheProvider, RedisCacheProvider>(ServiceLifecycle.Singleton);
        }
    }
}
