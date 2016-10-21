using Accela.Apps.Shared.APIHandlers.Handlers;
using Accela.Core.Ioc;
using Accela.Infrastructure.Configurations;
using Moq;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace Accela.Apps.Shared.APIHandlers.Test
{
    /// <summary>
    /// Test dependency: developer sub-system configured in apps.config up running
    /// </summary>
    [TestFixture]
    public class InternalAPIProxyHandlerTest
    {
        [SetUp]
        public void startup()
        {
            var configProvider = new Mock<IConfigurationReader>();
            configProvider.Setup<string>(s => s.Get("Test", "")).Returns("Test");
            var mockServiceLocator = new Mock<IServiceLocator>();
            mockServiceLocator.Setup<IConfigurationReader>(s => s.Resolve<IConfigurationReader>()).Returns(configProvider.Object);
            IocContainer.Current = mockServiceLocator.Object;
        }

        [Test]
        public void TestSendAsyncBase()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost");
            var handler = new InternalAPIProxyHandler()
            {
                InnerHandler = new DummyHandler()
            };
            using (HttpResponseMessage response = handler.SendAsyncInternal(request, new CancellationToken()).Result)
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public void TestSendAsyncBase2()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost/dummy");
            var handler = new InternalAPIProxyHandler()
            {
                InnerHandler = new DummyHandler()
            };
            using (HttpResponseMessage response = handler.SendAsyncInternal(request, new CancellationToken()).Result)
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public  void TestSendAsyncGet()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost/dev/apps/635442545792218073");
            var handler = new InternalAPIProxyHandler()
            {
                InnerHandler = new DummyHandler()
            };
            using (HttpResponseMessage response = handler.SendAsyncInternal(request, new CancellationToken()).Result)
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public void TestSendAsyncPost()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost/dev/apps/search");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent("{\"Status\":\"Published\"}");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var handler = new InternalAPIProxyHandler()
            {
                InnerHandler = new DummyHandler()
            };
            using (HttpResponseMessage response = handler.SendAsyncInternal(request, new CancellationToken()).Result)
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }
    }
}
