using Accela.Infrastructure.Cache.Redis;
using Accela.Core.Ioc;
using Accela.Infrastructure.Caches;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Tests.Cache
{

    class TestCache
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [TestFixture]
    public class Tier2CacheTests
    {

        private Tier2Cache tier2Cache;

        [SetUp]
        public void SetUp()
        {
            var mockRemoteStore = new Mock<ICache>();
            mockRemoteStore.Setup(s => s.Get<string>("Test")).Returns<string>((s) => "String from remote cache");
            mockRemoteStore.Setup(s => s.Get("Test")).Returns(new TestCache {Id = 1, Name = "Testing" });

            var mockLocalStore = new Mock<ICache>();
            mockLocalStore.Setup(s => s.Get<string>("Test")).Returns<string>(s => null);
            mockLocalStore.Setup(s => s.Get("Test")).Returns(null);
            mockLocalStore.Setup(s => s.Get<string>("TestLocal")).Returns<string>(s => "String from local cache");

            var mockRemoteCacheProvider = new Mock<IRemoteCacheProvider>();
            mockRemoteCacheProvider.SetupGet<ICache>(c => c.Instance).Returns(mockRemoteStore.Object);

            var mockLocalCacheProvider = new Mock<ILocalCacheProvider>();
            mockLocalCacheProvider.SetupGet<ICache>(c => c.Instance).Returns(mockLocalStore.Object);

            tier2Cache = new Tier2Cache(mockLocalCacheProvider.Object, mockRemoteCacheProvider.Object);
        }


        [Test]
        public void ShouldGetObjectFromRemote()
        {
            var cachedValue = (TestCache)tier2Cache.Get("Test");
            Assert.IsNotNull(cachedValue);
            Assert.AreEqual(1, cachedValue.Id);
        }

        [Test]
        public void ShouldGetFromRemote()
        {
            var cachedValue = tier2Cache.Get<string>("Test");
            Assert.AreEqual("String from remote cache", cachedValue);
        }

        [Test]
        public void ShouldGetFromLocal()
        {
            var cachedValue = tier2Cache.Get<string>("TestLocal");
            Assert.AreEqual("String from local cache", cachedValue);
        }


        [Test]
        public void ShouldGetFromRemoteWithSliding()
        {
            var cachedValue = tier2Cache.Get<string>("Test", TimeSpan.FromSeconds(2));
            Assert.AreEqual("String from remote cache", cachedValue);
        }

        [Test]
        public void ShouldGetFromLocalWithExpiration()
        {
            var cachedValue = tier2Cache.Get<string>("TestLocal", DateTime.Now.AddSeconds(2));
            Assert.AreEqual("String from local cache", cachedValue);
        }


        [Test]
        public void ShouldHaveLocalCacheProvider()
        {
            Assert.IsNotNull(tier2Cache.LocalCacheProvider);
        }

        [Test]
        public void ShouldHaveRemoteCacheProvider()
        {
            Assert.IsNotNull(tier2Cache.RemoteCacheProvider);
        }

      
    }
}
