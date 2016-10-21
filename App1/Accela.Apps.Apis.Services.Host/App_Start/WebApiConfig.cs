using System.Web.Http;
using System.Web.Routing;
using Accela.Apps.Apis.APIHandlers;
using Accela.Apps.Shared.APIHandlers;
using Newtonsoft.Json;
using Accela.Apps.Apis.Services.Handlers;

using Accela.Core.Logging;
using Accela.Core.Configurations;
using Accela.Infrastructure.Queue;
using Accela.Core.Ioc;
using Accela.Apps.Apis.Services.Handlers.Models;
using System.Web.Http.Cors;

namespace Accela.Apps.Apis.Services.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Enable Cors
            //http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            // Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new HomeHandler());
            config.MessageHandlers.Add(new MessageLoggingHandler());
            config.MessageHandlers.Add(new BatchRequestHandler());
            config.MessageHandlers.Add(new SecurityAccessHandler());
            config.MessageHandlers.Add(new APIUsageHandler());  // TODO: it didn't trace batch request

            //enable Mock API
            if (bool.Parse(ConfigurationSettingsManager.Get().Get("EnableMockAPI", bool.FalseString)))
            {
                config.MessageHandlers.Add(new ApiMockHandler());
            }

            config.MessageHandlers.Add(new AvoidDuplicateSubmissionHandler());

            config.MessageHandlers.Add(new MultipleAgenciesRouteHandler());
            config.MessageHandlers.Add(new AAServiceProxyHandler());    
            
            // Comment out the following code.
            // An error occured with message "Not running in a hosted service or the Development Fabric." when enabling 
            // this handler.
            // It may have something to do with a project named Accela.Apps.Apis.Services.Host.Azure which cannot
            // be loaded.
            //config.MessageHandlers.Add(new AnalyticWriterHandler());

            config.Filters.Add(new MobileExceptionFilter());

            /*
             * Regular Expression - http://msdn.microsoft.com/en-us/library/az24scfc.aspx
             * Grouping Construct
             * 
             * (?!subexpression) Zero-width negative lookahead assertion.
             * 
             * Pattern @"((?!a311/images).)*" will match any string which does not containing the (sub) string "a311/images".
            //*/
            config.Routes.MapHttpRoute("web-api-register",
                                       "{*value}",
                                       null,
                                       new RouteValueDictionary { { "value", @"(?!a311/images)(?!apis)(?!home).*" } },
                                       null);

            //config.Routes.MapHttpRoute("NotFoundHandler", "{*value}", null, null, new APINotFoundHandler());
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
