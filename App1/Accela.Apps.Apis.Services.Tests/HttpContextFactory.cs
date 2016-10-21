using Accela.Apps.Apis.Services.Tests.SecurityHelpers;
using Accela.Apps.Shared.Contexts;
using Accela.Infrastructure.Configurations;
using Moq;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Routing;
using System.Web.SessionState;

namespace Accela.Apps.Apis.Services.Tests
{
    public class HttpContextFactory
    {

        private IConfigurationReader ConfigurationReader { get { return new AppConfigurationReader(); } }
        private static HttpContextBase m_context;
        public static HttpContextBase Current
        {
            get
            {
                if (m_context != null)
                    return m_context;

                if (HttpContext.Current == null)
                    throw new InvalidOperationException("HttpContext not available");

                return new HttpContextWrapper(HttpContext.Current);
            }
        }

        public static void SetCurrentContext(HttpContextBase context = null)
        {
            if (context == null)
            {
                m_context = getMockedHttpContext();
            }
            else
            {
                m_context = context;
            }
        }


        private static HttpContextBase getMockedHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();
            var urlHelper = new Mock<UrlHelper>();

            //var routes = new RouteCollection();
            //MvcApplication.RegisterRoutes(routes);
            var requestContext = new Mock<RequestContext>();
            requestContext.Setup(x => x.HttpContext).Returns(context.Object);
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);

            request.SetupGet(req => req.Headers).Returns(new NameValueCollection());

            user.Setup(ctx => ctx.Identity).Returns(identity.Object);
            identity.Setup(id => id.IsAuthenticated).Returns(true);
            identity.Setup(id => id.Name).Returns("test");
            request.Setup(req => req.Url).Returns(new Uri("http://localhost"));
            request.Setup(req => req.RequestContext).Returns(requestContext.Object);
            requestContext.Setup(x => x.RouteData).Returns(new RouteData());
            request.SetupGet(req => req.Headers).Returns(new NameValueCollection());

            return context.Object;
        }

        public static HttpContext FakeHttpContext(string requestAbsoluteUrl = "", string httpMethod = "GET")
        {
            IConfigurationReader ConfigurationReader = new AppConfigurationReader();
            var httpRequest = new HttpRequest("", "http://localhost/", "");



            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                    new HttpStaticObjectsCollection(), 10, true,
                                                    HttpCookieMode.AutoDetect,
                                                    SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                        BindingFlags.NonPublic | BindingFlags.Instance,
                                        null, CallingConventions.Standard,
                                        new[] { typeof(HttpSessionStateContainer) },
                                        null)
                                .Invoke(new object[] { sessionContainer });


            //httpContext.Request.Headers.Add("x-accela-appid", "635339775442544632");
            //httpContext.Request.Headers.Add("x-accela-agency", "SOLNDEV-ENG");
            //httpContext.Request.Headers.Add("x-accela-environment", "PROD");

            if (requestAbsoluteUrl == "")
            {
                var entity = new UnKownAgencyAppContext();
                entity.Agency = "SOLNDEV-ENG";
                entity.ServProvCode = "SOLNDEV";
                entity.EnvName = "PROD";
                entity.App = "635339775442544632";
                entity.ContextUser = new UnKownContextUser { LoginName = "Admin", Environment = "PROD", Agency = "SOLNDEV-ENG", AgencyID = Guid.Empty, Id = Guid.Empty };
                entity.Token = ConfigurationReader.Get("CivicIdOauthToken");
                CallContext.LogicalSetData("ContextEntity", entity);
            }
            else
            {
                var entity = new SecurityHandlerHelper().GetAuthenticatedAgencyContext(requestAbsoluteUrl, httpMethod);
                CallContext.LogicalSetData("ContextEntity", entity);
            }
            return httpContext;
        }

    }
}
