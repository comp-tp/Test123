using NUnit.Framework;
using System.Net.Http;

namespace Accela.Apps.Shared.APIHandlers.Test
{
    /// <summary>
    /// Test dependency: developer sub-system configured in apps.config up running
    /// </summary>
    [TestFixture]
    public class HttpMessageTest
    {
        public class HttpMessageMock : HttpMessage 
        {
            public HttpMessageMock(HttpRequestMessage requestMessage) : base(requestMessage)
            { }

            public string ApplicationVirtualPath { 
                get { return base.ApplicationVirtualPath; }
                set { base.ApplicationVirtualPath = value; }
            }
        }

        [Test]
        public void TestGetAPIRelativePath()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records/");
            HttpMessageMock httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "";
            Assert.AreEqual("/v4/records/", httpMessage.GetAPIRelativePath());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records/");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records/", httpMessage.GetAPIRelativePath());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records?");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records?", httpMessage.GetAPIRelativePath());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records?a=111");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records?a=111", httpMessage.GetAPIRelativePath());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records/?a=111");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records/?a=111", httpMessage.GetAPIRelativePath());
        }

        [Test]
        public void TestGetAPIRelativePathWithoutQueryString()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records/");
            HttpMessageMock httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records/");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records?");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records?a=111");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records/?a=111");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());


            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/virtualapplication/v4/records/?a=111");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "virtualapplication";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/virtualapplication/v4/records?a=111");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/virtualapplication";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());

            requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/virtualapplication/v4/records");
            httpMessage = new HttpMessageMock(requestMessage);
            httpMessage.ApplicationVirtualPath = "/virtualapplication/";
            Assert.AreEqual("/v4/records", httpMessage.GetAPIRelativePathWithoutQueryString());
        }
    }
}
