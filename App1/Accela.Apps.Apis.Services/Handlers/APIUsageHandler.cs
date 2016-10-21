using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Apis.Services.Handlers.Helpers;
using Accela.Apps.Shared.Contexts;
using Accela.Core.Analytics;
using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Infrastructure.Configurations;
using System;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.APIHandlers
{
    public class APIUsageHandler : DelegatingHandler
    {
        private static IConfigurationReader ConfigurationReader { get { return ConfigurationSettingsManager.Get(); } }

        private ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        /// <summary>
        /// Get Trace
        /// </summary>
        private ITrace Tracer
        {
            get
            {
                return TraceFactory.Instance.GetTracer();
            }
        }


        /// <summary>
        /// Trace API usage
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
            try
            {
                HttpMessage message = new HttpMessage(request);
                string requestAbsoluteUrl = message.GetAPIRelativePath();
                var resource = ResourceHelper.GetResourceModelFromRequestOrCache(request);

                // prefix '/apis/' is used for internal api
                if (resource != null && !requestAbsoluteUrl.StartsWith("/apis/", StringComparison.OrdinalIgnoreCase))
                {
                    StatsData apiUsage = new StatsData()
                    {
                        //Id = TraceId, analytics does not need ID; diff from log
                        Resource = resource.Api,
                        RequestMethod = message.GetHttpMethod(),
                        RequestUri = request.RequestUri.LocalPath,
                        RequestQuery = request.RequestUri.Query,
                        RequestUserAgent = (request.Headers.UserAgent==null)? null : request.Headers.UserAgent.ToString(),
                        App = context.App,
                        Agency = context.Agency,
                        Environment = context.EnvName,
                        User = context.LoginName,
                        ClientIP = message.GetClientIP(),
                        RequestTime = DateTime.UtcNow
                    };
                    if (apiUsage.Resource != null)
                    {
                        apiUsage.Resource = apiUsage.Resource.ToLower();
                    }
                    if (string.IsNullOrEmpty(apiUsage.App))
                    {
                        apiUsage.App = message.GetAppID();
                    }

                    Tracer.Trace(apiUsage);
                }
            }
            catch(Exception ex)
            {
                Log.Critical(ex, "APIUsageHandler");
            }

            return await base.SendAsync(request, cancellationToken);
        }
        
    }
}
