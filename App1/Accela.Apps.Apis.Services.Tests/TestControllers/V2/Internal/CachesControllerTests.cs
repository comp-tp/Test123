using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Services.V2.InternalAPIs;
using Accela.Apps.Core.Cache;
using Accela.Apps.Core.Cache.InMemoryCache;
using Accela.Apps.Core.Cache.Providers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Accela.Apps.Apis.Services.Tests.TestControllers.V2.Internal
{

    [TestFixture]
    public class CachesControllerTests: ApiBaseTest
    {

        public override ApiController Controller
        {
            get
            {
                return cacheController;
            }
        }
        private CachesController cacheController;

        private IMemoryCacheProvider memoryCacheProvider;
        private IPersistedDataBusinessEntity persistedBusinessEntity;
        //private CacheStoreProvider cacheProvider;
        private ICacheStore _cacheStore;
        private ICacheStore _inMemoryCacheStore;

        [SetUp]
        public void Setup()
        {
             //_cacheStore = new Mock<ICacheStore>().Object;
             var mockStore = new Mock<ICacheStore>();
             mockStore.Setup(s => s.Remove(It.IsAny<string>())).Verifiable();
             mockStore.Setup(s => s.Clear()).Verifiable();

            _cacheStore = mockStore.Object;

             var memoryMockStore = new Mock<ICacheStore>();
             memoryMockStore.Setup(s => s.Remove(It.IsAny<string>())).Verifiable();
             memoryMockStore.Setup(s => s.Clear()).Throws<NotImplementedException>();
             _inMemoryCacheStore = memoryMockStore.Object;

            var mockCache = new Mock<CacheStoreProvider>();
            mockCache.SetupGet<ICacheStore>(c => c.Instance).Returns(_cacheStore);

            var mockInMemoryCache = new Mock<IMemoryCacheProvider>();
            mockInMemoryCache.SetupGet<ICacheStore>(c => c.Instance).Returns(_inMemoryCacheStore);


            persistedBusinessEntity = new Mock<IPersistedDataBusinessEntity>().Object;


            memoryCacheProvider = mockInMemoryCache.Object;
            //cacheProvider = mockCache.Object as CacheStoreProvider;

            cacheController = new CachesController(mockCache.Object, persistedBusinessEntity, memoryCacheProvider);

            base.SetUpRequest();
        }


        [Test]
        public void ShouldRemoveCacheKeyFromInMemoryCache()
        {
            var response = cacheController.RemoveCacheKey("inmemory", "resouces");
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        public void ShouldRemoveCacheKeyFromRedisCache()
        {
            var response = cacheController.RemoveCacheKey("redis", "resouces");
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        public void ShouldRemoveCacheKeyFromAllCache()
        {
            var response = cacheController.RemoveCacheKey("all", "resouces");
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        public void ShouldNotRemoveCacheKeyFromCache()
        {
            var response = cacheController.RemoveCacheKey("dummyCache", "resouces");
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [Test]
        public void ShouldClearAll()
        {
            var response = cacheController.ClearCaches("all", "all");
            Assert.That(response.IsSuccess == true);
        }

        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void ShouldNotClearAll()
        {
            memoryCacheProvider.Instance.Clear();
        }
    }
}
