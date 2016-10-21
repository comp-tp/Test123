using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Configurations;
using Accela.Core.Logging;
using Accela.Infrastructure.Configurations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.RestClients
{
    public class InternalAPIClient
    {
        private const int TIME_OUT_MILLISECONTS = 1000 * 60 * 15; // 15 mins
        private const string APPLICATION_FORM = "application/x-www-form-urlencoded";
        private const string APPLICATION_JSON = "application/json";
        private const string FAILED_TO_RESPONSE_FROM_SUBSYSTEM = "Failed to get response from sub-system.";

        private IAgencyAppContext _context;

        public WebHeaderCollection ResponsedHeader { get; set; }
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }

        public InternalAPIClient()
        {

        }

        public InternalAPIClient(IAgencyAppContext context)
        {
            _context = context;
        }

        private IAgencyAppContext Context
        {
            get
            {
                if (_context == null)
                {
                    try
                    {
                        //_context = IocContainer.Resolve<IAgencyAppContext>();
                        _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
                    }
                    catch
                    {
                    }
                }

                if(_context == null)
                {
                    _context = new AgencyAppContext();
                }

                return _context;
            }
        }

        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        private static ILog Log
        {
            get
            {
                return LogFactory.GetLog();
            }
        }

        /// <summary>
        /// Get resource thru http GET method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">full resource url.</param>
        /// <returns></returns>
        public T Execute<T>(string resource) where T : new()
        {
            return Execute<T>(resource, null, Method.GET);
        }

        /// <summary>
        /// PUT/UPDATE/DELETE resource.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">full resource url.</param>
        /// <param name="requestPostBody"></param>
        /// <returns></returns>
        public T Execute<T>(string resource, object requestPostBody, Method method = Method.POST, string httpHeaderContentType = APPLICATION_JSON, string httpHeaderAccept = APPLICATION_JSON) where T : new()
        {
            T result = default(T);

            if (APPLICATION_FORM.Equals(httpHeaderContentType, StringComparison.OrdinalIgnoreCase))
            {
                result = ExecuteFormRequest<T>(resource, requestPostBody, method, httpHeaderAccept);
            }
            else
            {
                result = ExecuteJsonRequest<T>(resource, requestPostBody, method, httpHeaderAccept);
            }

            return result;
        }

        public Task<HttpResponseMessage> SendAsync(string requestUrl, HttpMethod httpMethod, HttpContent content = null, IDictionary<string, string> requestHeaders = null, string traceId = null)
        {
            var startTime = DateTime.UtcNow;
            if (string.IsNullOrWhiteSpace(traceId))
            {
                traceId = LogUtil.NewTraceID();
            }

            Task<HttpResponseMessage> response = null;
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = httpMethod;
            request.RequestUri = new Uri(requestUrl);
            // add request headers
            BuildHeaders(request, Context);
            AddHttpHeaders(request, requestHeaders);
            request.Headers.TryAddWithoutValidation("Accept", "application/json,image/*,text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            string accessKey = ConfigurationSettings.Get("InternalAPI_AccessKey");
            request.Headers.TryAddWithoutValidation("x-accela-subsystem-accesskey", accessKey);

            if (httpMethod == HttpMethod.Get)
            {
                request.Content = null;
            }
            else
            {
                request.Content = content;
            }
            
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            using (var client = new HttpClient())
            {
                response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

                response.Result.Headers.TransferEncodingChunked = false;

                #region Log Response

                if (Log != null && Log.IsDebugEnabled)
                {
                    response.ContinueWith((t, m) =>
                    {
                        var log = new LogEntity();
                        log.MethodName = "InternalAPIClient.SendAsync()";
                        log.Message = String.Format("InternalAPIClient Response from {0}", requestUrl);
                        log.Detail = t.Result != null && t.Result.Content != null ? t.Result.Content.ReadAsStringAsync().Result : "response is null";
                        log.TraceId = traceId;
                        log.MethodExecuteTime = Convert.ToInt32((DateTime.UtcNow - startTime).TotalMilliseconds);
                        Log.Debug(log);
                    }, traceId);
                }
                #endregion

                return response;
            }
        }


        private T ExecuteFormRequest<T>(string resource, object requestPostBody, Method method = Method.POST, string httpHeaderAccept = APPLICATION_JSON) where T : new()
        {
            T result = default(T);
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            var requestHeaders = BuildHeaders(APPLICATION_FORM, httpHeaderAccept);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string tempResult = String.Empty;
            Exception responseException = null;
            var requestBody = requestPostBody as string;

            using (WebClient webClient = new WebClient())
            {
                SetHeaders(webClient, requestHeaders);

                try
                {
                    tempResult = webClient.UploadString(resource, requestBody);
                }
                catch (Exception ex)
                {
                    responseException = ex;
                }
                this.ResponsedHeader = webClient.ResponseHeaders;
            }

            watch.Stop();
            int requestExcuteTime = Convert.ToInt32(watch.ElapsedMilliseconds);

            // log data (info or error, etc.)
            string apiName = method.ToString() + " " + resource;
            LogData(apiName, 0, requestHeaders, requestBody, requestExcuteTime, this.ResponsedHeader, responseException, tempResult);

            if (responseException != null)
            {
                var exception = new MobileException(FAILED_TO_RESPONSE_FROM_SUBSYSTEM, responseException);
                throw exception;
            }

            if (!String.IsNullOrWhiteSpace(tempResult))
            {
                result = JsonConverter.FromJsonTo<T>(tempResult);
            }

            watch = null;
            return result;
        }

        private T ExecuteJsonRequest<T>(string resource, object requestPostBody, Method method = Method.POST, string httpHeaderAccept = APPLICATION_JSON) where T : new()
        {
            T result = default(T);
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            var requestHeaders = BuildHeaders(APPLICATION_JSON, httpHeaderAccept);
            Stopwatch watch = new Stopwatch();
            IRestResponse<T> response = null;
            int retries = 0;
            var requestBodyString = requestPostBody is string || requestPostBody == null ? requestPostBody as string : JsonConverter.ToJson(requestPostBody);

            while (retries < 3)
            {
                watch.Start();
                var request = CreateRestRequest(resource, method, requestPostBody, requestHeaders);
                response = new RestClient().Execute<T>(request);
                watch.Stop();
                int requestExcuteTime = Convert.ToInt32(watch.ElapsedMilliseconds);

                // log data (info or error, etc.)
                string apiName = method.ToString() + " " + resource;
                LogData(apiName, retries, requestHeaders, requestBodyString, requestExcuteTime, response);

                // statusCode==0 means networks connection issue (in most cases) for current version of restClient, for newer version, 
                // need to check if statusCode==0 stands for networks connection issue.
                if (response.StatusCode > 0)
                {
                    break;
                }

                retries++;
            }

            var exception = GetException(response);

            if (exception != null)
            {
                throw exception;
            }

            result = response != null ? response.Data : result;
            watch = null;
            return result;
        }

        private Exception GetException<T>(IRestResponse<T> response) where T : new()
        {
            Exception result = null;

            if (response != null && response.ErrorException != null)
            {
                result = new MobileException("Internal Server Error. Please contact the administrator.", response.ErrorException, ErrorCodes.internal_server_error_500);
            }
            else if (response != null && response.StatusCode != HttpStatusCode.OK)
            {
                WSErrorResponse aaErrorResponse = null;
                try
                {
                    aaErrorResponse = JsonConverter.FromJsonTo<WSErrorResponse>(response.Content);
                }
                catch (Exception ex)
                {
                    result = new MobileException("Internal Server Error. Please contact the administrator.", ex, ErrorCodes.internal_server_error_500);
                }

                if (result == null)
                {
                    string aaErrorMessage = (aaErrorResponse != null && !String.IsNullOrEmpty(aaErrorResponse.Message)) ? aaErrorResponse.Message : FAILED_TO_RESPONSE_FROM_SUBSYSTEM;
                    string aaErrorMessageMore = aaErrorResponse != null && !String.IsNullOrWhiteSpace(aaErrorResponse.More) ? aaErrorResponse.More : null;
                    string aaErrorMessageCode = aaErrorResponse != null && !String.IsNullOrWhiteSpace(aaErrorResponse.Code) ? aaErrorResponse.Code : ErrorCodes.internal_server_error_500;

                    string clientToolsErrorMessage = response != null && !String.IsNullOrWhiteSpace(response.ErrorMessage) ? response.ErrorMessage : null;
                    string messageMore = String.IsNullOrWhiteSpace(aaErrorMessageMore) ? clientToolsErrorMessage : aaErrorMessageMore;

                    if (Enum.IsDefined(typeof(HttpStatusCode), aaErrorResponse.Status))
                        result = new MobileException(aaErrorMessage, messageMore, aaErrorMessageCode, ((HttpStatusCode)aaErrorResponse.Status));
                    else
                        result = new MobileException(aaErrorMessage, messageMore, aaErrorMessageCode);
                }
            }

            return result;
        }

        private IRestRequest CreateRestRequest(string resource, Method method, object requestPostBody, WebHeaderCollection headers)
        {
            string requestUrl = null;

            requestUrl = resource;

            IRestRequest request = new RestRequest(requestUrl, method);
            request.Timeout = TIME_OUT_MILLISECONTS;
            SetHeaders(request, headers);

            if (requestPostBody != null)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddBody(requestPostBody);
            }

            return request;
        }

        public static void BuildHeaders(HttpRequestMessage request, IAgencyAppContext Context)
        {
            if (!String.IsNullOrEmpty(Context.TraceID))
            {
                request.Headers.Add(ResponseHeaderConstants.X_Accela_Header_TraceId, Context.TraceID);
            }

            if (!String.IsNullOrEmpty(Context.App))
            {
                request.Headers.Add(ResponseHeaderConstants.X_Accela_Header_AppId, Context.App);
            }

            if (!String.IsNullOrEmpty(Context.Agency))
            {
                request.Headers.Add(ResponseHeaderConstants.X_Accela_Header_Agency, Context.Agency);
            }

            if (!String.IsNullOrEmpty(Context.EnvName))
            {
                request.Headers.Add(ResponseHeaderConstants.X_Accela_Header_Environment, Context.EnvName);
            }

            if (!String.IsNullOrWhiteSpace(Context.CivicId))
            {
                request.Headers.Add(ResponseHeaderConstants.X_Accela_Header_Civic_ID, Context.CivicId);
            }
        }

        private WebHeaderCollection BuildHeaders(string httpHeaderContentType, string httpHeaderAccept)
        {
            var headers = new WebHeaderCollection();

            string accessKey = ConfigurationSettings.Get("InternalAPI_AccessKey");

            if (string.IsNullOrEmpty(accessKey))
            {
                throw new ArgumentNullException("Not set internal api access key.");
            }

            if (String.IsNullOrWhiteSpace(httpHeaderContentType))
            {
                httpHeaderContentType = APPLICATION_JSON;
            }

            if (String.IsNullOrWhiteSpace(httpHeaderAccept))
            {
                httpHeaderAccept = APPLICATION_JSON;
            }

            headers["Content-Type"] = httpHeaderContentType;
            headers["Accept-Encoding"] = "gzip, deflate";
            headers["Accept"] = httpHeaderAccept;

            if (!String.IsNullOrEmpty(Context.TraceID))
            {
                headers[ResponseHeaderConstants.X_Accela_Header_TraceId] = Context.TraceID;
            }

            if (!String.IsNullOrEmpty(Context.App))
            {
                headers[ResponseHeaderConstants.X_Accela_Header_AppId] = Context.App;
            }

            if (!String.IsNullOrEmpty(Context.AppVer))
            {
                headers[ResponseHeaderConstants.X_Accela_Header_AppVersion] = Context.AppVer;
            }

            if (!String.IsNullOrEmpty(Context.Agency))
            {
                headers[ResponseHeaderConstants.X_Accela_Header_Agency] = Context.Agency;
            }

            if (!String.IsNullOrEmpty(Context.LoginName))
            {
                headers[ResponseHeaderConstants.X_Accela_Header_SubSystem_User] = Context.LoginName;
            }

            if (!String.IsNullOrWhiteSpace(Context.CivicId))
            {
                headers[ResponseHeaderConstants.X_Accela_Header_Civic_ID] = Context.CivicId;
            }

            if (!String.IsNullOrEmpty(Context.EnvName))
            {
                headers[ResponseHeaderConstants.X_Accela_Header_Environment] = Context.EnvName;
            }

            headers[ResponseHeaderConstants.X_Accela_Header_SubSystem_Caller] = ConfigurationSettings.Get(ConfigurationConstant.CURRENT_SUB_SYSTEM);
            int callSequence = Context.Index = Context.Index + 1;
            callSequence = callSequence * 10;
            headers[ResponseHeaderConstants.X_Accela_Header_SubSystem_CallSequence] = callSequence.ToString();
            headers[ResponseHeaderConstants.X_Accela_Header_SubSystem_AccessKey] = accessKey;
            return headers;
        }

        private string GetHeadersString(IList<Parameter> headers)
        {
            string result = null;

            if (headers != null && headers.Count > 0)
            {
                var tempResult = (from h in headers
                                  where h != null
                                  && !String.IsNullOrWhiteSpace(h.Name)
                                  select String.Format("{0}: {1}", h.Name, h.Value)
                                  ).ToArray();
                result = String.Join("\r\n", tempResult);
            }

            return result;
        }

        private void SetHeaders(WebClient webClient, WebHeaderCollection headers)
        {
            if (webClient != null && headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    webClient.Headers[key] = headers[key];
                }
            }
        }

        private void SetHeaders(IRestRequest request, WebHeaderCollection headers)
        {
            if (request != null && headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    request.AddHeader(key, headers[key]);
                }
            }
        }

        public static void AddHttpHeaders(HttpRequestMessage request, IDictionary<string, string> requestHeaders)
        {
            if (requestHeaders != null && request != null)
            {
                foreach (var header in requestHeaders)
                {
                    request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
        }

        private void LogData(string requestUrl, int retryCount, WebHeaderCollection requestHeaders, string requestBody, int requestExcuteTime, WebHeaderCollection responseHeaders, Exception ex, string responseContent)
        {
            try
            {
                var requestHeadersString = requestHeaders != null ? requestHeaders.ToString().TrimEnd('\r', '\n') : null;
                var responseHeadersString = responseHeaders != null ? responseHeaders.ToString().TrimEnd('\r', '\n') : null;
                var fullExceptionString = ex != null ? ex.TraceInformation() : null;
                var responseHttpStatus = HttpStatusCode.OK;

                if (ex != null && ex is WebException)
                {
                    var response = ((WebException)ex).Response;
                    var httpWebResponse = response != null ? (System.Net.HttpWebResponse)response : null;
                    responseHttpStatus = httpWebResponse != null ? httpWebResponse.StatusCode : HttpStatusCode.Unused;
                }

                LogData(requestUrl, retryCount, requestHeadersString, requestBody, requestExcuteTime, responseHttpStatus, responseHeadersString, responseContent, fullExceptionString);
            }
            catch { }
        }

        private void LogData<T>(string requestUrl, int retryCount, WebHeaderCollection requestHeaders, string requestBody, int requestExcuteTime, IRestResponse<T> response) where T : new()
        {
            try
            {
                if (response == null)
                {
                    return;
                }

                var requestHeadersString = requestHeaders != null ? requestHeaders.ToString().TrimEnd('\r', '\n') : null;
                var responseHeadersString = GetHeadersString(response.Headers);
                var fullExceptionString = response.ErrorException != null ? response.ErrorException.TraceInformation() : response.ErrorMessage;

                LogData(requestUrl, retryCount, requestHeadersString, requestBody, requestExcuteTime, response.StatusCode, responseHeadersString, response.Content, fullExceptionString);
            }
            catch { }
        }

        private void LogData(string requestUrl, int retryCount, string requestHeadersString, string requestBody, int requestExcuteTime, HttpStatusCode responseHttpStatus, string responseHeadersString, string responseContent, string fullExceptionString)
        {
            var isErrorLog = responseHttpStatus != HttpStatusCode.OK;

            if (isErrorLog || Log.IsDebugEnabled)
            {
                var logData = new LogEntity();
                logData.MethodName = requestUrl;
                var messageSummary = isErrorLog ? "SubSystem Calling - Exception occurred" : "SubSystem Calling - Debug";
                if (retryCount > 0)
                {
                    messageSummary = String.Format("(Retry-{0}) {1}", retryCount, messageSummary);
                }
                logData.Message = messageSummary;
                logData.MethodExecuteTime = requestExcuteTime;

                StringBuilder sbDetail = new StringBuilder();

                sbDetail.Append("Request Uri: ");
                sbDetail.Append(logData.MethodName).Append("  ");

                sbDetail.Append("Request Headers:  ");
                // secure code and credencial should be logged
                sbDetail.Append(requestHeadersString).Append("  ");

                sbDetail.Append("Request Body:  ");

                // secure code and credencial should NOT be logged
                //if (requestUrl.EndsWith("/oauth2/token", StringComparison.OrdinalIgnoreCase))
                //{
                //    requestBody = ClearTextPasswordProtectionUtil.ReplaceClearTextPasswordForOAuthAPI(requestBody);
                //}

                sbDetail.Append(requestBody).Append("  ");

                sbDetail.Append("  ");

                sbDetail.Append("Response Http Status:  ");
                sbDetail.Append(responseHttpStatus).Append("  ");

                sbDetail.Append("Response Headers: ");
                sbDetail.Append(responseHeadersString).Append("  ");

                if (isErrorLog)
                {
                    sbDetail.Append("Response Exception: ");
                    sbDetail.Append(fullExceptionString).Append("  ");
                }

                sbDetail.Append("Response Body: ");

                //if (requestUrl.EndsWith("/aaauth/aausertoken", StringComparison.OrdinalIgnoreCase))
                //{
                //    responseContent = ClearTextPasswordProtectionUtil.ReplaceClearTextPasswordForAAUserToken(responseContent);
                //}

                sbDetail.Append(responseContent).Append("  ");

                logData.Detail = sbDetail.ToString();

                logData.TraceId = Context.TraceID;
                logData.UserName = Context.LoginName;
                logData.Agency = Context.Agency;
                logData.AppId = Context.App;
                logData.Order = Context.Index++;

                if (isErrorLog)
                {
                    Log.Error(logData);
                }
                else
                {
                    Log.Debug(logData);
                }
            }
        }
    }
}
