using Accela.Apps.Shared.Contexts;
using Accela.Core.Ioc;
using Accela.Infrastructure.Configurations;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Accela.Apps.Shared.RestClients
{
    [TestFixture]
    public class InternalAPIClientTest
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
        public void TestHeaders()
        {
            IAgencyAppContext context = new AgencyAppContext()
            {
                Agency = "UT-AGENCY",
                EnvName = "TEST"
            };
            //InternalAPIClient client = new InternalAPIClient(context);
            HttpRequestMessage request = new HttpRequestMessage();
            InternalAPIClient.BuildHeaders(request, context);
            var agencyInHeader = request.Headers.GetValues("x-accela-agency").ToArray();
            Assert.AreEqual(1, agencyInHeader.Length);
            Assert.AreEqual("UT-AGENCY", agencyInHeader[0]);

            IDictionary <string, string> requestHeaders = new Dictionary<string, string>();
            requestHeaders.Add("x-accela-agency", "REQUEST-AGENCY");
            InternalAPIClient.AddHttpHeaders(request, requestHeaders);
            agencyInHeader = request.Headers.GetValues("x-accela-agency").ToArray();
            Assert.AreEqual(1, agencyInHeader.Length);
            Assert.AreEqual("REQUEST-AGENCY", agencyInHeader[0]);

        }
    }
}
