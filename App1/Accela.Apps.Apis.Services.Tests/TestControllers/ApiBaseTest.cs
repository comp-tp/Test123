using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Accela.Apps.Apis.Services.Tests.TestControllers
{
    public abstract class ApiBaseTest
    {
        public abstract ApiController Controller { get;}


        public virtual void SetUpRequest()
        {
            Controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://dummyhost/api/dummypath")
            };

            Controller.Configuration = new HttpConfiguration();
            Controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            Controller.RequestContext.RouteData = new HttpRouteData(route: new HttpRoute(), values: new HttpRouteValueDictionary { { "dummycontroller", "index" } });
        }
    }
}
