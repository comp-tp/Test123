using Accela.Apps.Shared.APIHandlers.Handlers;
using Accela.Core.Ioc;
using Accela.Infrastructure.Configurations;
using Moq;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Accela.Apps.Shared.APIHandlers.Test
{
    /// <summary>
    /// Test dependency: developer sub-system configured in apps.config up running
    /// </summary>
    [TestFixture]
    public class InternalAPISecurityHandlerTest
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

        //[TestMethod]
        //public void TestSendAsyncUnauthorized()
        //{
        //    var request = new HttpRequestMessage();
        //    request.RequestUri = new Uri("http://localhost");
        //    var handler = new InternalAPISecurityHandler()
        //    {
        //        InnerHandler = new DummyHandler()
        //    };
        //    using (HttpResponseMessage response = handler.SendAsyncInternal(request, new CancellationToken()).Result)
        //    {
        //        Assert.AreEqual(response.StatusCode, HttpStatusCode.Unauthorized);
        //    }
        //}

        [Test]
        public void TestSendAsyncAuthorized()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost/dummy");
            string internalKey = ConfigurationManager.AppSettings.Get("InternalAPI_AccessKey");
            request.Headers.Add(ResponseHeaderConstants.X_Accela_Header_SubSystem_AccessKey, internalKey);
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
