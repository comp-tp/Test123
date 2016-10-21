using Accela.Apps.Apis.Ioc;
using Accela.Apps.Apis.Services.Host.Bootstrap;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Infrastructure.Caches;
using Accela.Apps.Shared.Exceptions;
using Accela.Infrastructure.PubSub;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Accela.Apps.Apis.Services.Host
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //http://blogs.msdn.com/b/tmarq/archive/2007/07/21/asp-net-thread-usage-on-iis-7-0-and-6-0.aspx
            ServicePointManager.DefaultConnectionLimit = 5000;

            // Support TLS
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            // used for developer or test environment(current even if in production, consruct still have dev or test environment which may use self-certificate
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            AreaRegistration.RegisterAllAreas();
            
            // please keep current registration first than other handler for CORS
            //CorsConfig.RegisterCors(GlobalConfiguration.Configuration);

            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Create the container as usual.
            SimpleInjectorBootstrapper.Bootstrap(GlobalConfiguration.Configuration);

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var currentServerName= ConfigurationSettingsManager.Get().Get("current_sub_system");
            if (Log != null && Log.IsInfoEnabled)
            {
                Log.Info(currentServerName + " is started.", null, "Application_Start()");
            }

            string ikey = ConfigurationSettingsManager.Get().Get("APPINSIGHTS_INSTRUMENTATIONKEY");
            if(!string.IsNullOrWhiteSpace(ikey))
            {
                TelemetryConfiguration.Active.InstrumentationKey = ikey;
            }

            try
            {
                IServiceBusConnectionStringSetting sbSetting = new ServiceBusConnectionStringSetting(ConfigurationSettingsManager.Get());
                var subscriber = new Subscriber<MessageEntity>(sbSetting);
                subscriber.OnMessageReceived += Subscribe_MessageReceived;
                string topicName = "adminSettingUpdated";
                string subscriptionName = String.Format("{0}-{1}-{2}", "apis", NetworkInterfaceReader.GetMachineIP().ToString(), NetworkInterfaceReader.GetMachineMacAddress());
                subscriber.Subscribe(topicName, subscriptionName);

                if (Log != null) Log.Info("Subscriber-" + subscriptionName + " is started." , null, "API_Global");
            }
            catch(Exception ex)
            {
               if(Log != null) Log.Critical("subscribe error", ex.ToString(), "API_Global");
            }
        }

        public void Application_End()
        {
            // This will give LE background thread some time to finish sending messages to Logentries.
            var numWaits = 10;
            // TODO: wrap it to accela.core.logger on clean up resource
            while (!LogentriesCore.Net.AsyncLogger.AreAllQueuesEmpty(TimeSpan.FromSeconds(6)) && numWaits > 0)
                numWaits--;
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            try
            {
                if(Server.GetLastError() == null)
                {
                    return;
                }

                var ex = Server.GetLastError();
                HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
                string traceId = LogUtil.NewTraceID();
                if (ex != null && ex is HttpException)
                {
                    int StatusCode = (ex as HttpException).GetHttpCode();
                    Enum.TryParse(StatusCode.ToString(), out httpStatusCode);
                }

                string message = null;
                string code = null;

                if (httpStatusCode == HttpStatusCode.InternalServerError)
                {
                    code = ErrorCodes.internal_server_error_500;
                    message = "Unexpected Exception";
                }
                else
                {
                    message = httpStatusCode.ToString();
                }

                WSErrorResponse errorResponse = new WSErrorResponse
                {
                    TraceId = traceId,
                    Status = (int)httpStatusCode,
                    Code = code,
                    Message = message
                };

                string result = Newtonsoft.Json.JsonConvert.SerializeObject(errorResponse);
                var logData = new LogEntity
                {
                    TraceId = traceId,
                    Message = message,
                    MethodName = "Application_Error",
                    Detail = string.Format("Request:{0} {1}, Response:{2}, Exception:{3}", Request.RequestType.ToString(), Request.Url.ToString(), result, ex.ToString())
                };

                if (httpStatusCode == HttpStatusCode.InternalServerError)
                {
                    // log all unhandle exception
                    System.Diagnostics.Trace.TraceError("Unexpected Exception in API Application_Error." + ex.ToString());
                    if (Log != null) Log.Critical(logData);
                }
                else
                {
                    System.Diagnostics.Trace.TraceWarning("Unexpected Exception in API Application_Error." + ex.ToString());
                    if (Log != null) Log.Warn(logData);
                }

                if (Context != null)
                    Context.ClearError();
         
                Response.AddHeader(Shared.APIHandlers.ResponseHeaderConstants.X_Accela_Header_TraceId, traceId);
                Response.StatusCode = (int)httpStatusCode;
                Response.ContentType = "application/json";
                Response.Write(result);
            }
            catch {}
        }

        private static ILog _log;
        private static ILog Log
        {
            get
            {
                if(_log == null)
                {
                    try
                    {
                        ILogger logger = IocContainer.Resolve<ILogger>();
                        _log = LogFactory.GetLog(logger);
                    }
                    catch { }
                }

                return _log;
            }
        }

        private void Subscribe_MessageReceived(MessageEntity message)
        {
            try
            {
                if (message != null && message.Contents != null)
                {
                    // cache changed, refresh client cache by cache key
                    foreach (var cacheKey in message.Contents)
                    {
                        ClearCacheByKey(cacheKey);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Log != null) Log.Error("subscribe refresh cache failed", ex.ToString(), "API_Global");
            }
        }

        private void ClearCacheByKey(string cacheKey)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(cacheKey))
                {
                    return;
                }
                var cacheStoreProvider = IocContainer.Resolve<CacheStoreProvider>();
                var memoryCacheProvider = IocContainer.Resolve<IMemoryCacheProvider>(); 
                if (cacheStoreProvider != null && cacheStoreProvider.Instance != null)
                {
                    bool successToRemove = true;
                    for (int i = 0; i < 3 && successToRemove; i++)
                    {
                        try
                        {
                            cacheStoreProvider.Instance.Remove(cacheKey);
                            if (memoryCacheProvider != null && memoryCacheProvider.Instance != null)
                            {
                                memoryCacheProvider.Instance.Remove(cacheKey);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (Log != null) Log.Error(String.Format("Remove cache: {0} failed - {1} times.", cacheKey, i + 1), ex.ToString(), "API_Global");
                            successToRemove = false;
                        }
                    }
                }
            }
            catch { }
        }

    }
}