using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Infrastructure.Configurations;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.APIHandlers
{
    public class MessageLoggingHandler : DelegatingHandler
    {
        private ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        private static IConfigurationReader ConfigurationReader { get { return ConfigurationSettingsManager.Get(); } }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IAgencyAppContext context = new UnKownAgencyAppContext();
            HttpMessage message = new HttpMessage(request);
            string traceId = message.GetTraceId();
            long startTimeTicks = DateTime.UtcNow.Ticks;
            string api = null;
            try
            {
                // clear thread context object
                CallContext.LogicalSetData("ContextEntity", null);

                context = BuildContext(message);
                CallContext.LogicalSetData("ContextEntity", context);

                api = message.GetRequestUriTemplate();
                try
                {
                    if (api.Equals("{*value}"))
                    {
                        api = message.GetAPIRelativePath();
                    }
                    if (api.IndexOf('?') > 0)
                    {
                        api = api.Substring(0, api.IndexOf('?'));   // log only API path but not parameters
                    }
                    api = request.Method.ToString() + ' ' + api;
                }
                catch (Exception exception)
                {
                    var logData = new LogEntity
                    {
                        TraceId = context.TraceID,
                        Message = "Error process API",
                        Detail = string.Format("API:{0}, Exception:{1}", api, exception.ToString()),
                        MethodName = "MessageLoggingHandler.SendAsync()"
                    };
                    Log.Error(logData);
                }

                var guid = Guid.NewGuid().ToString();
                string timeTicks = guid.Substring(guid.Length - 8);
                LogRequest(timeTicks, context, request, message, api);

                var response = await base.SendAsync(request, cancellationToken);

                if (!response.Headers.Contains(ResponseHeaderConstants.X_Accela_Header_TraceId))
                {
                    response.Headers.Add(ResponseHeaderConstants.X_Accela_Header_TraceId, HttpResponseHelper.RemoveInvalidNewLine(traceId));
                }

                int requestExcuteTime = Convert.ToInt32((new TimeSpan(DateTime.UtcNow.Ticks - startTimeTicks)).TotalMilliseconds);
                LogResponse(timeTicks, context, response, api, requestExcuteTime);

                return response;
            }
            catch (Exception ex)
            {
                int requestExcuteTime = Convert.ToInt32((new TimeSpan(DateTime.UtcNow.Ticks - startTimeTicks)).TotalMilliseconds);
                var logData = new LogEntity
                {
                    TraceId = traceId,
                    Message = "Exception in MessageLoggingHandler",
                    Detail = string.Format("API:{0}, Exception:{1}", api, ex.ToString()),
                    MethodName = "MessageLoggingHandler.SendAsync()",
                    MethodExecuteTime = requestExcuteTime
                };
                Log.Error(logData);
                var errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, ex.Message, null, traceId);
                return HttpResponseHelper.SendAsync(request, errorResponse, traceId).Result;
            }
        }


        private IAgencyAppContext BuildContext(HttpMessage message)
        {
            IAgencyAppContext context = new AgencyAppContext();
            context.TraceID = message.GetTraceId();
            context.App = message.GetAppID();
            context.AppSecret = message.GetAppSecretCode();
            context.AppVer = message.GetAppVer();
            context.EnvName = message.GetEnvironment();

            context.ClientIP = message.GetClientIP();
            context.Language = message.GetLanguage();
            context.Token = message.GetToken();
            context.RequestUri = message.GetRequestUri();
            context.RequestUriTemplate = message.GetRequestUriTemplate();
            context.HttpMethod = message.GetHttpMethod();
            context.HttpHeader = message.GetHttpHeader();
            context.ContentType = message.GetContentType();
            context.ContentLength = message.GetContentLength();
            //SubSystem Caller
            if (String.IsNullOrEmpty(message.GetSubSystemCaller()))
            {
                context.SubSystemCaller = "Client";
            }
            else
            {
                context.SubSystemCaller = message.GetSubSystemCaller();
            }

            context.LoginName = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_SubSystem_User);
            context.CivicId = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Civic_ID);
            context.Agency = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency);

            //CallSequence
            string callSequence = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_SubSystem_CallSequence);
            int callIndex = 0;
            if (Int32.TryParse(callSequence, out callIndex))
            {
                context.Index = callIndex;
            }

            return context;
        }

        private void LogRequest(string timeTicks, IAgencyAppContext context, HttpRequestMessage request, HttpMessage message, string api)
        {
            try {
                StringBuilder requestContent = new StringBuilder();
                requestContent.Append("URL:").Append(message.GetRequestUri()).Append(";");
                requestContent.Append("Content-Type:").Append(message.GetContentType()).Append(";");
                requestContent.Append("Header:").Append(ToLogString(request.Headers)).Append(";");

                if (request.Method != HttpMethod.Get && request.Content != null)
                {
                    requestContent.Append("Body:");
                    if (request.Content is StreamContent && request.Content.Headers != null 
                         && IsBinaryContent(request.Content.Headers))
                    {
                        requestContent.Append("<binary>");
                    }
                    else
                    {
                        string requestData = request.Content.ReadAsStringAsync().Result;
                        requestContent.Append(requestData);
                    }
                }

                LogEntity logData = new LogEntity();
                logData.MethodName = api;
                logData.RequestFrom = context.SubSystemCaller;
                logData.RequestTo = ConfigurationReader.Get(ConfigurationConstant.CURRENT_SUB_SYSTEM);
                logData.Message = String.Format("API Request - {0}", timeTicks);
                logData.Detail = requestContent.ToString();
                logData.MethodInSize = message.GetContentLength();
                logData.Order = context.Index;

                logData.TraceId = context.TraceID;
                logData.AppId = context.App;
                logData.Agency = context.Agency;
                logData.EnvName = context.EnvName;
                logData.UserName = context.LoginName;
                logData.ClientIP = message.GetClientIP();
                Log.Info(logData);
            }
            catch (Exception exception)
            {
                var logData = new LogEntity
                {
                    TraceId = context.TraceID,
                    Message = "Log Error",
                    Detail = string.Format("API:{0}, Exception:{1}", message.GetRequestUri(), exception.ToString()),
                    MethodName = "MessageLoggingHandler.LogRequest()"
                };
                Log.Error(logData);
            }
        }

        private async void LogResponse(string timeTicks, IAgencyAppContext context, HttpResponseMessage response, string api, int requestExcuteTime)
        {
            try
            {
                var logData = new LogEntity();

                logData.Detail = "Headers:" + response.Headers.ToString() + ";Http Status: " + (int)response.StatusCode;

                if (response.Content != null)
                {
                    if (response.Content is StreamContent && response.Content.Headers != null 
                        && IsBinaryContent(response.Content.Headers))
                    {
                        logData.Detail += ";Body: <binary>";

                        logData.MethodOutSize = response.Content.Headers.ContentLength.HasValue ? Convert.ToInt32(response.Content.Headers.ContentLength.Value) : 0;
                    }
                    else
                    {
                        var responseMessage = await response.Content.ReadAsStringAsync();

                        if (responseMessage != null)
                        {
                            logData.Detail += ";Body: " + responseMessage;
                            logData.MethodOutSize = responseMessage.Length;
                        }
                    }
                }

                logData.TraceId = context.TraceID;
                logData.Order = context.Index;
                logData.UserName = context.LoginName;
                logData.Agency = context.Agency;
                logData.EnvName = context.EnvName;

                logData.MethodName = api;
                logData.RequestFrom = ConfigurationReader.Get(ConfigurationConstant.CURRENT_SUB_SYSTEM);
                logData.RequestTo = context.SubSystemCaller;
                logData.AppId = context.App;
                logData.Message = String.Format("API Response - {0}", timeTicks);
                logData.MethodExecuteTime = requestExcuteTime;

                Log.Info(logData);
            }
            catch (Exception exception)
            {
                var logData = new LogEntity
                {
                    TraceId = context.TraceID,
                    Message = "Log Error",
                    Detail = string.Format("API:{0}, Exception:{1}", api, exception.ToString()),
                    MethodName = "MessageLoggingHandler.LogResponse()"
                };
                Log.Error(logData);
            }
        }

        private static string ToLogString(HttpRequestHeaders headers)
        {
            if (headers == null) return "";

            StringBuilder builder = new StringBuilder();
            foreach(var h in headers)
            {
                // for security, token can't be logged; log security handler takes care of it generically but still logs a lot
                // with complex API scope names, token could be pretty long 1K+, and waste a lot of bandwidth
                // so do special handling here
                if ( h.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                    builder.Append("Auth*:*** ");  // still log it so we can tell request use what kind of auth; sensitive data log util mask first 100 characters
                else if (h.Key.Equals(ResponseHeaderConstants.X_Accela_Header_AppSecret, StringComparison.OrdinalIgnoreCase))
                    builder.Append("x-accela-*secret:*** ");  // still log it so we can tell request use what kind of auth; sensitive data log util mask first 100 characters
                else if (h.Key.Equals(ResponseHeaderConstants.X_Accela_Header_SubSystem_AccessKey, StringComparison.OrdinalIgnoreCase))
                    continue; // accesskey no need to be logged
                else
                    builder.Append(h.Key).Append(':').Append(string.Join(",", h.Value)).Append(' ');
            }
            return builder.ToString();
        }

        private readonly string[] BinaryContentTypes = new string[] { "image", "octet-stream", "audio", "video" };

        private bool IsBinaryContent(HttpContentHeaders headers)
        {
            if (headers.ContentDisposition != null)
            {
                return headers.ContentDisposition.DispositionType.Equals("attachment");
            }
            else if (headers.ContentType != null)
            {
                var contentType = headers.ContentType.ToString().ToLowerInvariant();

                foreach (var t in BinaryContentTypes)
                {
                    if (contentType.Contains(t))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}