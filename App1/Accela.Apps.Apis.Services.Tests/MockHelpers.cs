using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Accela.Apps.Apis.Services.Tests
{
    public static class MvcMockHelpers
    {
        public static HttpContextBase FakeHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();

            var headers = new NameValueCollection
            {
                { 
                    "Special-Header-Name", "false" 
                }
            };
            request.Setup(x => x.Headers).Returns(headers);

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);

            return context.Object;
        }

        public static HttpContextBase FakeHttpContext(string url)
        {
            HttpContextBase context = FakeHttpContext();
            context.Request.SetupRequestUrl(url);
            return context;
        }

        //public static void SetFakeControllerContext(this ApiController controller)
        //{
        //    var httpContext = FakeHttpContext();
        //    HttpControllerContext context = new HttpControllerContext(new RequestContext(httpContext, new RouteData()),
        //                                                      controller);
        //    controller.ControllerContext = context;
        //}

        public static void SetHttpBrowserCapabilities(this HttpRequestBase request,
                                                      HttpBrowserCapabilitiesBase httpBrowserCapabilities)
        {
            Mock.Get(request)
                .Setup(p => p.Browser)
                .Returns(httpBrowserCapabilities);
        }

        private static string GetUrlFileName(string url)
        {
            if (url.Contains("?"))
                return url.Substring(0, url.IndexOf("?"));
            else
                return url;
        }

        private static NameValueCollection GetQueryStringParameters(string url)
        {
            if (url.Contains("?"))
            {
                NameValueCollection parameters = new NameValueCollection();

                string[] parts = url.Split("?".ToCharArray());
                string[] keys = parts[1].Split("&".ToCharArray());

                foreach (string key in keys)
                {
                    string[] part = key.Split("=".ToCharArray());
                    parameters.Add(part[0], part[1]);
                }

                return parameters;
            }
            else
            {
                return null;
            }
        }

        public static void SetHttpMethodResult(this HttpRequestBase request, string httpMethod)
        {
            Mock.Get(request)
                .Setup(req => req.HttpMethod)
                .Returns(httpMethod);
        }


        public static void SetAjaxRequest(this HttpRequestBase request)
        {
            var headers = new NameValueCollection();

            Mock.Get(request).SetupGet(x => x.Headers).Returns(headers);

            headers["X-Requested-With"] = "XMLHttpRequest";
        }

        public static void SetJsonRequest(this HttpRequestBase request)
        {
            Mock.Get(request)
                .SetupGet(req => req.ContentType)
                .Returns("application/json");
        }

        public static void SetupRequestUrl(this HttpRequestBase request, string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            // rlb:  we need fully qualified uris.
            //if (!url.StartsWith("~/"))
            //    throw new ArgumentException("Sorry, we expect a virtual url starting with \"~/\".");

            var mock = Mock.Get(request);

            mock.Setup(req => req.QueryString)
                .Returns(GetQueryStringParameters(url));
            mock.Setup(req => req.AppRelativeCurrentExecutionFilePath)
                .Returns(GetUrlFileName(url));
            mock.Setup(req => req.PathInfo)
                .Returns(string.Empty);
            mock.SetupGet(req => req.Url)
                .Returns(new Uri(url, UriKind.RelativeOrAbsolute));
        }
    }
}
