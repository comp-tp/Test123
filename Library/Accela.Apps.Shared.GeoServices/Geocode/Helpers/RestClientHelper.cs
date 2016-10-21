using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Apps.Shared.APIHandlers;
using Accela.Core.Logging;
using Accela.Apps.Shared.Utils;
using Accela.Infrastructure.Configurations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Accela.Apps.GeoServices.Geocode.Helpers
{
    public static class RestClientHelper
    {
        private static readonly IConfigurationReader configurationSettings;

        static RestClientHelper()
        {
            configurationSettings = IocContainer.Resolve<IConfigurationReader>();
        }

        public static IRestResponse Execute(IRestRequest request, int retryCount = 3)
        {
            IRestResponse result = null;
            int retries = 0;
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            var stopwatch = new Stopwatch();

            while (retries < retryCount)
            {
                stopwatch.Start();
                result = new RestClient().Execute(request);
                stopwatch.Stop();
                int requestExcuteTime = Convert.ToInt32(stopwatch.ElapsedMilliseconds);

                // log request and response
                try
                {
                    Log(request, result, retries, requestExcuteTime);
                }
                catch (Exception ex)
                {
                    LogFactory.GetLog().Error(ex, "RestClientHelper.Execute() - Log(...)");
                }

                // statusCode==0 means networks connection issue (in most cases) for current version of restClient, for newer version, 
                // need to check if statusCode==0 stands for networks connection issue.
                if (result.StatusCode > 0)
                {
                    break;
                }

                retries++;
            }

            return result;
        }

        private static void Log(IRestRequest request, IRestResponse response, int retryCount, int requestExcuteTime)
        {
            var requestAndResponseLog = RestsharpLogBuilder.BuildRequestAndResponseLog(request, response);
            var isErrorLog = response != null && response.StatusCode != HttpStatusCode.OK;
            var logMessage = String.Format("GeoService Calling - {0}", isErrorLog ? "Error" : "Info");
            var logData = new LogEntity();
            logData.MethodName = String.Format("{0} {1}", request.Method, request.Resource);

            if (retryCount > 0)
            {
                logMessage = String.Format("(Retry-{0}) {1}", retryCount, logMessage);
            }

            var headerList = request.Parameters.Where(p => p.Type == ParameterType.HttpHeader).ToList();

            var pTraceId = headerList.FirstOrDefault(h => h.Name == ResponseHeaderConstants.X_Accela_Header_TraceId);
            string traceId = pTraceId == null ? null : (pTraceId.Value == null ? null : pTraceId.Value.ToString());

            var pUserName = headerList.FirstOrDefault(h => h.Name == ResponseHeaderConstants.X_Accela_Header_SubSystem_User);
            string userName = pUserName == null ? null : (pUserName.Value == null ? null : pUserName.Value.ToString());

            var pAgency = headerList.FirstOrDefault(h => h.Name == ResponseHeaderConstants.X_Accela_Header_Agency);
            string agency = pAgency == null ? null : (pAgency.Value == null ? null : pAgency.Value.ToString());

            var pApp = headerList.FirstOrDefault(h => h.Name == ResponseHeaderConstants.X_Accela_Header_AppId);
            string app = pApp == null ? null : (pApp.Value == null ? null : pApp.Value.ToString());

            var pEnvName = headerList.FirstOrDefault(h => h.Name == ResponseHeaderConstants.X_Accela_Header_Environment);
            string envName = pEnvName == null ? null : (pEnvName.Value == null ? null : pEnvName.Value.ToString());

            logData.Message = logMessage;
            logData.MethodExecuteTime = requestExcuteTime;
            logData.Detail = requestAndResponseLog;
            logData.TraceId = traceId;
            logData.RequestFrom = configurationSettings.Get("current_sub_system");
            logData.RequestTo = "External GeoService";
            logData.UserName = userName;
            logData.Agency = agency;
            logData.EnvName = envName;
            logData.AppId = app;
            logData.Order = 0;

            var logFactory = LogFactory.GetLog();

            if (isErrorLog)
            {
                if (logFactory.IsErrorEnabled)
                {
                    logFactory.Error(logData);
                }
            }
            else
            {
                if (logFactory.IsInfoEnabled)
                {
                    logFactory.Info(logData);
                }
            }
        }
    }
}
