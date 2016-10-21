using Accela.Infrastructure.Cache.Couchbase;
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
            container.Register<CacheStoreProvider, CouchbaseCacheProvider>(ServiceLifecycle.Singleton);
            container.Register<ICouchbaseProvider, CouchbaseCacheProvider>(ServiceLifecycle.Singleton);
        }
    }
}
