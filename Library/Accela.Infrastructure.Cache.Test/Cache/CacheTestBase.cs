using Accela.Infrastructure.Caches;
using Accela.Infrastructure.Cache.Couchbase;
using Accela.Infrastructure.Cache.Redis;
using Accela.Core.Ioc;
using Accela.Core.Ioc.SimpleInjector;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Tests.Cache
{
    [Serializable]
    public class TestCacheClass
    {

        public string AppName { get; set; }

        public string AppVersion { get; set; }

        public int UserId { get; set; }
    }

    //[TestFixture(typeof(CouchbaseCacheProvider))]
    [TestFixture(typeof(RedisCacheProvider))]
    [TestFixture(typeof(MemoryCacheStoreProvider))]
    public class CacheTestBase<TCacheStore> where TCacheStore : CacheStoreProvider
    {
        private TCacheStore cacheStore;

        protected TCacheStore CacheStore
        {
            get
            {
                if (cacheStore == null)
                {
                    cacheStore = IocContainer.Current.Resolve<TCacheStore>();
                }
                return cacheStore;
            }
        }

        [SetUp]
        public virtual void Init()
        {
            IocContainer.Current = new ServiceLocator();
            IocContainer.Current.LoadAll("Accela.Infrastructure.*.dll", "");
        }

        [TearDown]
        public virtual void Dispose()
        {
            IocContainer.Current.Dispose();
            IocContainer.Current = null;
        }


        [TestCase( TestName = "Cache Test - Put Get Remove")]
        public virtual void Test_Put_Get_Remove()
        {
            //var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();
            CacheStore.Instance.Put<string>("Test", "Testing");
            var test = CacheStore.Instance.Get<string>("Test");
            Assert.AreEqual("Testing", test);
            CacheStore.Instance.Remove("Test");
            test = CacheStore.Instance.Get<string>("Test");
            Assert.AreEqual(null, test);
        }

        [Test]
        public virtual void Test_Put_Get_Remove_Object()
        {
            //var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();
            CacheStore.Instance.Put<TestCacheClass>("ObjectTest", new TestCacheClass());
            var test = CacheStore.Instance.Get<TestCacheClass>("ObjectTest");
            Assert.IsNotNull(test);
            CacheStore.Instance.Remove("ObjectTest");
            test = CacheStore.Instance.Get<TestCacheClass>("ObjectTest");
            Assert.IsNull(test);
        }


        [Test]
        public virtual void Test_Put_Get_AbsoluteExpiration()
        {
            //var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();

            //Add Test and Expire in 5 seconds.
            CacheStore.Instance.Put<string>("Test", "Testing", DateTime.UtcNow.AddSeconds(5));
            var test = CacheStore.Instance.Get<string>("Test");
            Assert.AreEqual("Testing", test);

            //Mock 10 seconds delay.
            Thread.Sleep(10000);

            //Test should not be in Cache now.
            test = CacheStore.Instance.Get<string>("Test");
            Assert.AreEqual(null, test);
        }

        [Test]
        public virtual void Test_Put_Get_SlidingExpiration()
        {
            //var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();

            //Add Test and Expire in 10 seconds.
            CacheStore.Instance.Put<string>("TestSliding", "Testing", TimeSpan.FromSeconds(5));
            var test = CacheStore.Instance.Get<string>("TestSliding");
            Assert.AreEqual("Testing", test);

            //Mock 10 seconds delay.
            Thread.Sleep(4000);
            test = CacheStore.Instance.Get<string>("TestSliding");
            Assert.AreEqual("Testing", test);

            //Call the Touch Method to Reset Expiration Again to 5 Seconds.
            //This is workaround for Sliding Expiration on Couchbase for now.
            //CacheStore.Instance.Touch("TestSliding", TimeSpan.FromSeconds(5));

            //Thread.Sleep(4000);
            test = CacheStore.Instance.Get<string>("TestSliding");
            Assert.AreEqual("Testing", test);


            Thread.Sleep(5000);
            //Test should not be in Cache now.
            test = CacheStore.Instance.Get<string>("TestSliding");
            Assert.AreEqual(null, test);
        }
    }
}
