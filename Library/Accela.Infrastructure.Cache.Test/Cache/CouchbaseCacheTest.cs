//using Accela.Infrastructure.Cache.Couchbase;
//using Accela.Apps.Core.Cache;
//using Accela.Apps.Core.Cache.Providers;
//using Accela.Core.Ioc;
//using Accela.Core.Ioc.SimpleInjector;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Accela.Apps.Core.Tests.Cache
//{

//    [Serializable]
//    public class TestCacheClass {

//        public string AppName { get;set;}

//        public string AppVersion { get; set; }

//        public int UserId { get; set; }
//    }
    
//    [Category("Cache")]
//    [TestFixture(typeof(CouchbaseCacheProvider))]
//    public class CouchbaseCacheTest : CacheTestBase<CouchbaseCacheProvider>
//    {
//        //private CacheStoreProvider cacheStore;
//        //[SetUp]
//        //public void Init()
//        //{
//        //    IocContainer.Current = new ServiceLocator();
//        //    IocContainer.Current.LoadAll("Accela.*.dll", "");
//        //}

//        //[TearDown]
//        //public void Dispose()
//        //{
//        //    IocContainer.Current.Dispose();
//        //    IocContainer.Current = null;
//        //}


//        //[Test]
//        //public void TestCouchbase_Put_Get_Remove()
//        //{
//        //    var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();
//        //    cache.Instance.Put<string>("Test", "Testing");
//        //    var test = cache.Instance.Get<string>("Test");
//        //    Assert.AreEqual("Testing", test);
//        //    cache.Instance.Remove("Test");
//        //    test = cache.Instance.Get<string>("Test");
//        //    Assert.AreEqual(null, test);
//        //}

//        //[Test]
//        //public void TestCouchbase_Put_Get_Remove_Object()
//        //{
//        //    var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();
//        //    cache.Instance.Put<TestCacheClass>("ObjectTest", new TestCacheClass());
//        //    var test = cache.Instance.Get<TestCacheClass>("ObjectTest");
//        //    Assert.IsNotNull(test);
//        //    cache.Instance.Remove("ObjectTest");
//        //    test = cache.Instance.Get<TestCacheClass>("ObjectTest");
//        //    Assert.IsNull(test);
//        //}


//        //[Test]
//        //public void TestCouchbase_Put_Get_AbsoluteExpiration()
//        //{
//        //    var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();

//        //    //Add Test and Expire in 10 seconds.
//        //    cache.Instance.Put<string>("Test", "Testing", DateTime.UtcNow.AddSeconds(5));
//        //    var test = cache.Instance.Get<string>("Test");
//        //    Assert.AreEqual("Testing", test);

//        //    //Mock 10 seconds delay.
//        //    Thread.Sleep(10000);

//        //    //Test should not be in Cache now.
//        //    test = cache.Instance.Get<string>("Test");
//        //    Assert.AreEqual(null, test);
//        //}

//        //[Test]
//        //public void TestCouchbase_Put_Get_SlidingExpiration()
//        //{
//        //    var cache = IocContainer.Current.Resolve<ICouchbaseProvider>();

//        //    //Add Test and Expire in 10 seconds.
//        //    cache.Instance.Put<string>("TestSliding", "Testing", TimeSpan.FromSeconds(5));
//        //    var test = cache.Instance.Get<string>("TestSliding");
//        //    Assert.AreEqual("Testing", test);

//        //    //Mock 10 seconds delay.
//        //    Thread.Sleep(4000);
//        //    test = cache.Instance.Get<string>("TestSliding");
//        //    Assert.AreEqual("Testing", test);

//        //    //Call the Touch Method to Reset Expiration Again to 5 Seconds.
//        //    //This is workaround for Sliding Expiration on Couchbase for now.
//        //    cache.Instance.Touch("TestSliding", TimeSpan.FromSeconds(5));

//        //    Thread.Sleep(4000);
//        //    test = cache.Instance.Get<string>("TestSliding");
//        //    Assert.AreEqual("Testing", test);


//        //    Thread.Sleep(5000);
//        //    //Test should not be in Cache now.
//        //    test = cache.Instance.Get<string>("TestSliding");
//        //    Assert.AreEqual(null, test);
//        //}


//        //protected override CacheStoreProvider CacheStore
//        //{
//        //    get
//        //    {
//        //        if (cacheStore == null)
//        //        {
//        //            cacheStore = IocContainer.Current.Resolve<ICouchbaseProvider>() as CacheStoreProvider;
//        //        }
//        //        return cacheStore;
//        //    }
//        //    set
//        //    {
//        //        throw new NotImplementedException();
//        //    }
//        //}
//    }
//}
