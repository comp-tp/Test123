using Accela.Apps.Apis.Services.Tests.Bootstrap;
using Accela.Apps.Shared.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System.Web;

namespace Accela.Apps.Apis.Services.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        protected Container IoContainer { get; private set; }

        protected HttpContextBase Contextbase { get; private set; }

        public IAgencyAppContext Context { get; set; }

        [TestInitialize]
        public virtual void SetUp()
        {
            HttpContext.Current = HttpContextFactory.FakeHttpContext();

            HttpContextFactory.SetCurrentContext();
            HttpContextFactory.Current.Request.Headers.Add("x-accela-appid", "635339775442544632");
            HttpContextFactory.Current.Request.Headers.Add("x-accela-agency", "SOLNDEV-ENG");
            HttpContextFactory.Current.Request.Headers.Add("x-accela-environment", "PROD");

            this.Contextbase = HttpContextFactory.Current;

            IoContainer = SimpleInjectorBootstrapper.Bootstrap();
            //CivicIdAuthConfig.RegisterAuth(IocContainer.Current);

            Context = new UnKownAgencyAppContext();
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            IoContainer = null;
        }
    }
}
