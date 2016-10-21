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
            //Default CacheStore provider is set to Memory Cache, 
            //This can be overwritten at Application level by changing SortOrder higher than Int32.MinValue
            //container.Register<CacheStoreProvider, MemoryCacheStoreProvider>(ServiceLifecycle.Singleton);
            //container.Register<IMemoryCacheProvider, MemoryCacheStoreProvider>(ServiceLifecycle.Singleton);
            //container.Register<ILocalCacheProvider, MemoryCacheStoreProvider>(ServiceLifecycle.Singleton);

            container.RegisterWithRegistration<MemoryCacheStoreProvider>(ServiceLifecycle.Singleton, typeof(CacheStoreProvider), typeof(IMemoryCacheProvider), typeof(ILocalCacheProvider));
            //container.Register<ITier2Cache, Tier2Cache>(ServiceLifecycle.Singleton);
        }
    }
}
