using Accela.Core.Ioc;
using Accela.Core.Ioc.SimpleInjector;
using Accela.Infrastructure.Caches;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Tests.Cache
{


    [TestFixture]
    public class MemoryCacheTest
    {

        [SetUp]
        public void Init()
        {
            IocContainer.Current = new ServiceLocator();
            IocContainer.Current.LoadAll("Accela.*.dll", "");
        }

        [TearDown]
        public void Dispose()
        {
            IocContainer.Current.Dispose();
            IocContainer.Current = null;
        }


        [Test]
        public void TestMemoryCache_Put_Get_Remove()
        {
            var cache = IocContainer.Current.Resolve<IMemoryCacheProvider>();
            cache.Instance.Put<string>("Test", "Testing");
            var test = cache.Instance.Get<string>("Test");
            Assert.AreEqual("Testing", test);
            cache.Instance.Remove("Test");
            test = cache.Instance.Get<string>("Test");
            Assert.AreEqual(null, test);
        }

        [Test]
        public void TestMemoryCache_Put_Get_Remove_Object()
        {
            var cache = IocContainer.Current.Resolve<IMemoryCacheProvider>();
            cache.Instance.Put<TestCacheClass>("ObjectTest", new TestCacheClass());
            var test = cache.Instance.Get<TestCacheClass>("ObjectTest");
            Assert.IsNotNull(test);
            cache.Instance.Remove("ObjectTest");
            test = cache.Instance.Get<TestCacheClass>("ObjectTest");
            Assert.IsNull(test);
        }


        [Test]
        public void TestMemoryCache_Put_Get_AbsoluteExpiration()
        {
            var cache = IocContainer.Current.Resolve<IMemoryCacheProvider>();

            //Add Test and Expire in 10 seconds.
            cache.Instance.Put<string>("Test", "Testing", DateTime.UtcNow.AddSeconds(2));
            var test = cache.Instance.Get<string>("Test");
            Assert.AreEqual("Testing", test);

            Thread.Sleep(2100);

            //Test should not be in Cache now.
            test = cache.Instance.Get<string>("Test");
            Assert.AreEqual(null, test);
        }

        [Test]
        public void TestMemoryCache_Put_Get_SlidingExpiration()
        {
            var cache = IocContainer.Current.Resolve<IMemoryCacheProvider>();

            //Add Test and Expire in 10 seconds.
            cache.Instance.Put<string>("TestSliding", "Testing", TimeSpan.FromSeconds(3));
            var test = cache.Instance.Get<string>("TestSliding");
            Assert.AreEqual("Testing", test);

            //Mock 2 seconds delay.
            Thread.Sleep(2000);
            test = cache.Instance.Get<string>("TestSliding");
            Assert.AreEqual("Testing", test);

            //Call the Touch Method to Reset Expiration Again to 5 Seconds.
            //This is workaround for Sliding Expiration on Couchbase for now.
            //cache.Instance.Touch("TestSliding", TimeSpan.FromSeconds(5));

            Thread.Sleep(2000);
            test = cache.Instance.Get<string>("TestSliding");
            Assert.AreEqual("Testing", test);


            Thread.Sleep(3100);
            //Test should not be in Cache now.
            test = cache.Instance.Get<string>("TestSliding");
            Assert.AreEqual(null, test);
        }
    }
}
