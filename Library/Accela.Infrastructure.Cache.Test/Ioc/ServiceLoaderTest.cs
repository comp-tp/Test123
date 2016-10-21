using Accela.Apps.Core.Tests.Ioc;
using Accela.Core.Ioc;
using Accela.Core.Ioc.SimpleInjector;
using Accela.Infrastructure.Caches;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Cache.Test.Ioc
{
    [Serializable]
    public class ServiceLoaderTest
    {
        [Test]
        public void Test_IsSingleton_InMemoryCache()
        {
            using (var container = new ServiceLocator())
            {
                container.RegisterWithRegistration<MemoryCacheStoreProvider>(ServiceLifecycle.Singleton, typeof(CacheStoreProvider), typeof(IMemoryCacheProvider), typeof(ILocalCacheProvider));
                //resolve
                var cache1 = container.Resolve<CacheStoreProvider>();
                var cache2 = container.Resolve<IMemoryCacheProvider>();
                var cache3 = container.Resolve<ILocalCacheProvider>();

                Assert.IsNotNull(cache1);
                Assert.IsNotNull(cache2);
                Assert.IsNotNull(cache3);

                Assert.AreEqual(cache1.GetHashCode(), cache2.GetHashCode());
                Assert.AreEqual(cache1.GetHashCode(), cache3.GetHashCode());
                Assert.AreEqual(cache3.GetHashCode(), cache2.GetHashCode());
            }
        }

        [Test]
        public void Test_IsSingleton_RedisCache()
        {
            using (var container = new ServiceLocator())
            {
                container.RegisterWithRegistration<MockCacheProvider>(ServiceLifecycle.Singleton, typeof(CacheStoreProvider), typeof(IRemoteCacheProvider));

                //resolve
                var cache1 = container.Resolve<CacheStoreProvider>();
                var cache3 = container.Resolve<IRemoteCacheProvider>();

                Assert.IsNotNull(cache1);
                Assert.IsNotNull(cache3);

                Assert.AreEqual(cache1.GetHashCode(), cache3.GetHashCode());
            }
        }

        [Test]
        public void Test_IsSingleton_Tier2Cache()
        {
            using (var container = new ServiceLocator())
            {
                container.RegisterWithRegistration<MemoryCacheStoreProvider>(ServiceLifecycle.Singleton, typeof(IMemoryCacheProvider), typeof(ILocalCacheProvider));
                container.RegisterWithRegistration<MockCacheProvider>(ServiceLifecycle.Singleton, typeof(IRemoteCacheProvider));
                container.Register<ITier2Cache, Tier2Cache>(ServiceLifecycle.Singleton);

                //resolve
                //var cache1 = container.Resolve<CacheStoreProvider>();
                var tier2Cache = container.Resolve<ITier2Cache>();
                var tier2Cache1 = container.Resolve<ITier2Cache>();

                var localCache = container.Resolve<ILocalCacheProvider>();
                var remoteCache = container.Resolve<IRemoteCacheProvider>();

                Assert.IsNotNull(tier2Cache);
                Assert.IsNotNull(tier2Cache1);
                Assert.IsNotNull(localCache);
                Assert.IsNotNull(remoteCache);

                Assert.AreEqual(tier2Cache.GetHashCode(), tier2Cache1.GetHashCode());

                Assert.AreEqual(tier2Cache.LocalCacheProvider.GetHashCode(), localCache.GetHashCode());
                Assert.AreEqual(tier2Cache.RemoteCacheProvider.GetHashCode(), remoteCache.GetHashCode());

            }
        }


    }
}
