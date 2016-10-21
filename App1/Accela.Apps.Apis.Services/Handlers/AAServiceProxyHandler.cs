using Accela.Apis.Service.Common;
using Accela.Apps.Admin.Agency.Client;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Services;
using Accela.Apps.Apis.Services.Handlers.Helpers;
using Accela.Apps.Shared;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Accela.Apps.Shared.Gateway.Client.Utility;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Exceptions;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Accela.Apps.Apis.APIHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class AAServiceProxyHandler : DelegatingHandler
    {
        private IResourceBusinessEntity _resourceBusinessEntity { get { return IocContainer.Resolve<IResourceBusinessEntity>(); } }

        private const string COMMON_NOT_COMPATIBILE_MESSAGE = "You cannot use the feature since Accela Automation version is not compatibile. Please contact agency administrator.";

        public AAServiceProxyHandler()
        {
            //_resourceBusinessEntity = ServiceLocator.Resolve<IResourceBusinessEntity>();
        }

        /// <summary>
        /// Get Log
        /// </summary>
        private ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string traceId = String.Empty;
            var _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
            try
            {
                string requestBody = null;
                traceId = _context.TraceID;

                HttpMessage message = new HttpMessage(request);
                string httpMethod = message.GetHttpMethod();
                string requestFullUrl = request.RequestUri.ToString();
                string remoteRequestAPIAbsoluteUrl = null;
                string aaToken = _context.SocialToken;
                WSErrorResponse errorResponse = null;
                var gatewayVersion = new Version();
                string _agencyName = _context.Agency;
                string _envName = _context.EnvName;
                IConfigurationReader configurationReader = IocContainer.Resolve<IConfigurationReader>();
                var resourceModel = ResourceHelper.GetResourceModelFromRequestOrCache(request);

                // check API definition
                if (resourceModel == null)
                {
                    errorResponse = ErrorResponses.GetAPINotFoundResponse(request, _context.TraceID);
                    if (request.Method==HttpMethod.Options) errorResponse.Status = (int)HttpStatusCode.OK; 
                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                }

                if (httpMethod != "GET" && Log.IsInfoEnabled)
                {
                    requestBody = await request.Content.ReadAsStringAsync();
                }

                // replace context for data aggregation
                if (request.Properties.ContainsKey("x-accela-replacecontext") && Convert.ToBoolean(request.Properties["x-accela-replacecontext"]) == true)
                {
                    traceId = String.IsNullOrWhiteSpace(message.GetTraceId()) ? _context.TraceID : message.GetTraceId();
                    _envName = String.IsNullOrWhiteSpace(message.GetEnvironment()) ? _context.EnvName : message.GetEnvironment();
                    _agencyName = String.IsNullOrWhiteSpace(message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency)) ? _context.Agency : message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency); 
                    aaToken = _context.SocialToken = request.Properties.ContainsKey("x-accela-biztoken") ? Convert.ToString(request.Properties["x-accela-biztoken"]) : null;

					_context.TraceID = traceId;
					_context.EnvName = _envName;
					_context.Agency = _agencyName;
                }

                // 0 means no proxy, which is cloud own API of API subsystem.
                if (resourceModel.IsProxy == 0)
                {
                    bool isFromBatchRequestAPI = request.Properties.ContainsKey(Constants.PROPERTIES_KEY_CHILDAPI_FROM_BATCHREQUEST);

                    if (isFromBatchRequestAPI)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            httpClient.Timeout = new TimeSpan(0, 0, 5, 0, 0); // timeout = 5 mins
                            var v3apiResponseMessage = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
                            v3apiResponseMessage.Headers.TransferEncodingChunked = false;
                            return v3apiResponseMessage;
                        }
                    }
                    else
                    {
                        return await base.SendAsync(request, cancellationToken);
                    } 
                }

                // read it from resources table.
                bool isConstructInternalProxy = false;
                if (string.IsNullOrWhiteSpace(resourceModel.ProxyRemoteServerName) || Constants.RemoteSystems.BizServer.ToString().Equals(resourceModel.ProxyRemoteServerName, StringComparison.OrdinalIgnoreCase))
                {
                    isConstructInternalProxy = false;
                    if (String.IsNullOrWhiteSpace(_context.Agency))
                    {
                        string error = "agency name is required.";
                        errorResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, error, null, traceId);
                        return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                    }
                }
                else
                {
                    isConstructInternalProxy = true;
                }

                #region  v3/v4 AA API is implemented in cloud thru govXML 
                if (resourceModel.IsProxy == 1 && resourceModel.IsAAGovXMLAPI == 1
                    )
                {
                    bool isFromBatchRequestAPI = request.Properties.ContainsKey(Constants.PROPERTIES_KEY_CHILDAPI_FROM_BATCHREQUEST);

                    if (isFromBatchRequestAPI)
                    {
                        using (var httpClient = new HttpClient())
                        {
                            httpClient.Timeout = new TimeSpan(0, 0, 5, 0, 0); // timeout = 5 mins
                            var v3apiResponseMessage = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
                            v3apiResponseMessage.Headers.TransferEncodingChunked = false;
                            return v3apiResponseMessage;
                        }
                    }
                    else
                    {
                        return await base.SendAsync(request, cancellationToken);
                    }
                }

                #endregion 

                #region check whether it is proxy api
                if (resourceModel.IsProxy == 1 && String.IsNullOrWhiteSpace(resourceModel.ProxyAPI))
                {
                    errorResponse = new WSErrorResponse(
                    HttpStatusCode.InternalServerError,
                    ErrorCodes.internal_server_error_500,
                    "The requested api is a proxy api but remote target API is not defined.",
                    String.Format("The requested api is a proxy api but remote target API is not defined in Resources, Please contact Accela cloud administrator.", request.Method, message.GetRequestUri()),
                    traceId);

                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                }
                #endregion

                #region Parse Relative API Url
                string queryString = request.RequestUri.Query.Split('?').Length <= 1 ? null : request.RequestUri.Query.Split('?')[1];
                string remoteQueryString = null;
                string internalSubSystemBaseUrl = null;

                if (isConstructInternalProxy)
                {
                    if (Constants.RemoteSystems.ConstructAdmin.ToString().Equals(resourceModel.ProxyRemoteServerName, StringComparison.OrdinalIgnoreCase))
                    {
                        internalSubSystemBaseUrl = configurationReader.Get("Ref_InternalAPI_Admin");
                    }
                    else if (Constants.RemoteSystems.ConstructUser.ToString().Equals(resourceModel.ProxyRemoteServerName, StringComparison.OrdinalIgnoreCase))
                    {
                        internalSubSystemBaseUrl = configurationReader.Get("Ref_InternalAPI_User");
                    }
                    else if (Constants.RemoteSystems.ConstructDeveloper.ToString().Equals(resourceModel.ProxyRemoteServerName, StringComparison.OrdinalIgnoreCase))
                    {
                        internalSubSystemBaseUrl = configurationReader.Get("Ref_InternalAPI_Dev");
                    }
                    else if (Constants.RemoteSystems.ConstructAuth.ToString().Equals(resourceModel.ProxyRemoteServerName, StringComparison.OrdinalIgnoreCase))
                    {
                        internalSubSystemBaseUrl = configurationReader.Get("Ref_InternalAPI_OAuth");
                    }

                    // Same as request query string
                    remoteQueryString = queryString;
                }
                else
                {
                    #region Required Agency name and Environment name in Token

                    // Dymaic agency for AA Service Prox is not supported for now
                    if (String.IsNullOrWhiteSpace(aaToken))
                    {
                        errorResponse = new WSErrorResponse(
                            HttpStatusCode.Forbidden,
                            ErrorCodes.forbidden_403,
                            "Agency name and environment name are required.",
                            "BizToken is null. Please make sure you are passing agency name and environment name in access token, or in HTTP Header 'x-accela-agency', 'x-accela-environment' respectively.",
                            traceId);
                        return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                    }

                    #endregion

                    // querystring : if not exists '?', add '?token='
                    if (String.IsNullOrEmpty(queryString))
                    {
                        remoteQueryString = String.Format("token={0}", aaToken);
                    }
                    else
                    {
                        var queryStringKV = HttpUtility.ParseQueryString(queryString);
                        // append AA token -- token={token} to AA rest api url
                        // e.g api/recordTypes?module=building -> api/recordTypes?module=building&token=62370994094573867276
                        queryStringKV["token"] = aaToken;
                        remoteQueryString = queryStringKV.ToString();
                    }
                }

                string remoteRequestAPI = resourceModel.ProxyAPI; // e.g: /v4/records/{recordId}/conditions/{id}?lang={lang}&fields={fields}
                remoteRequestAPIAbsoluteUrl = remoteRequestAPI.Split('?')[0]; // e.g: /v4/records/{recordId}/conditions/{id}
                if (!remoteRequestAPIAbsoluteUrl.StartsWith("/"))
                {
                    remoteRequestAPIAbsoluteUrl = "/" + remoteRequestAPIAbsoluteUrl;
                }

                // Replace sign {} with request value, Get real request url
                if (resourceModel.APIPrameters != null && resourceModel.APIPrameters.Count > 0)
                {
                    foreach (var item in resourceModel.APIPrameters)
                    {
                        remoteRequestAPIAbsoluteUrl = remoteRequestAPIAbsoluteUrl.Replace(item.Key, item.Value);
                    }
                }

                remoteRequestAPI =  string.IsNullOrWhiteSpace(remoteQueryString) ? remoteRequestAPIAbsoluteUrl : String.Format("{0}?{1}", remoteRequestAPIAbsoluteUrl, remoteQueryString);

                if (isConstructInternalProxy)
                {
                    if (String.IsNullOrWhiteSpace(internalSubSystemBaseUrl))
                    {
                        throw new MobileException("Failed to get sub system url setting, please contact administrator.");
                    }

                    // get subsystem base url from configuration - https://apps-admin.cloudapp.net/apis/v3
                    string subsystemBaseUrl = internalSubSystemBaseUrl.Split(new string[] { "/apis/" }, StringSplitOptions.None)[0];
                    var internalRequestUrl = subsystemBaseUrl + remoteRequestAPI;
                    var internalApiClient = new InternalAPIClient(_context);    // pass on context about agency, env.
                    var response = await internalApiClient.SendAsync(internalRequestUrl, request.Method, request.Content, null, traceId);
                    return response;
                }

                #endregion

                #region AA service proxy handler

                HttpResponseMessage responseMessage = null;
                try
                {
                    
                    //ICacheProvider cacheProvider = null;
                    ILogFactory logFactory = IocContainer.Resolve <ILogFactory>();
                    //IAdminSettingsContextService contextService = null;
                    //IAdminSettingsService adminSettingsService = new AdminSettingsService(cacheProvider, logFactory, contextService);
                    IAgencySettingsService adminSettingsService = IocContainer.Resolve<IAgencySettingsService>();

                    IAgencyAppContext gatewayContext = new AgencyAppContext { Agency = _agencyName, EnvName = _envName, TraceID = traceId };
                    //IConfigurationReader configurationReader = IocContainer.Resolve<IConfigurationReader>();
                    // Create gateway service
                    IGatewayService gatewayService = new GatewayService(gatewayContext, adminSettingsService);

                    // create gateway client
                    IGatewayClient gatwayClient = new GatewayClient(gatewayService, logFactory, configurationReader);

                    //var a = await AsyncLongTimeTester.ProcessAsync(30000);

                    // retry anonymous token if token is invalid or expired
                    int tryCount = 0;
                    bool needRetry = false;
                    do
                    {
                        var task = gatwayClient.SendAsync(ApiTypes.NormalApi, remoteRequestAPI, request.Method, request.Content);
                        responseMessage = task.Result;
                        tryCount++;

                        var pathAndQueryString = remoteRequestAPI.Split('?');
                        if(pathAndQueryString.Length < 2)
                        {
                            break;
                        }

                        // anonymous user token expired or invalid, need to refresh token
                        var bizTokenType = _context.Items["tokenType"] == null ? null : _context.Items["tokenType"].ToString();
                        if (tryCount < 2 && bizTokenType == BizTokenType.CitizenAnonymous.ToString()
                            && responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            var bizTokenModel = BizTokenHelper.GetAnonymousUserToken(_agencyName, _envName, true, _context);
                            if(bizTokenModel != null)
                            {
                                var newQueryStringKV = HttpUtility.ParseQueryString(pathAndQueryString[1]);
                                newQueryStringKV["token"] = bizTokenModel.Token;
                                remoteQueryString = newQueryStringKV.ToString();
                                remoteRequestAPI = pathAndQueryString[0] + "?" + remoteQueryString;
                                needRetry = true;
                            }
                        }
                    }
                    while (needRetry && tryCount < 2);

                    #region handler 404 resource not found or api not found error message

                    LogEntity logData = null;
                    // 404 - resource not found or api not found error message

                    if (responseMessage != null
                        && (responseMessage.StatusCode == HttpStatusCode.NotFound
                            ||
                        // AA 7.3.1 with Gateway 2.0
                            (
                                responseMessage.StatusCode == HttpStatusCode.OK
                                && (GetResponseConentLength(responseMessage) == 73)) // (length == 73)
                        //length of {"status":404,"code":1005,"message":"You are experiencing exception 404"}
                        //length of {"status":200,"result":{"successCount":1,"failedCount":0,"failedIDs":[]}}
                            )
                        )
                    {
                        #region 404 not found
                        string aa_not_found_response = null;
                        WSErrorResponse aa_response = null;

                        try
                        {
                            aa_not_found_response = await GetResponseContentString(responseMessage);

                            logData = new LogEntity()
                            {
                                Message = "Responsed Error from AA",
                                Detail = "AA Response 1:\r\n" + aa_not_found_response,
                                MethodName = "AAServiceProxyHandler.SendAsync()",
                                RequestFrom = "AA",
                                TraceId = traceId
                            };
                            Log.Error(logData);

                            aa_response = TryParseAAErrorResponse(aa_not_found_response,traceId);
                        }
                        catch (Exception ex)
                        {
                            string logMessage = String.Format("Response1:\r\n{0}\r\nException:\r\n{1}", aa_not_found_response, ex.TraceInformation());
                            var data = new LogEntity()
                            {
                                Message = "Error happen in AAServiceProxyHandler",
                                Detail = logMessage,
                                MethodName = "AAServiceProxyHandler.SendAsync()",
                                RequestFrom = "AA",
                                TraceId = traceId
                            };
                            Log.Error(data);
                        }

                        // if can't convert ErrorResponse Format
                        if (aa_response == null)
                        {
                            // quick bug fix for inspector getting conditions 
                            if (resourceModel.Api.Equals("/v3p/records/{recordId}/conditions", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "GET")
                            {
                                // call cloud api - /v3p1/records/{recordId}/conditions
                                return await CallV3p1ConditionAPI(requestFullUrl, _context.Token, _context.App, traceId);
                            }
                            else
                            {
                                errorResponse = new WSErrorResponse(
                                HttpStatusCode.NotFound,
                                ErrorCodes.api_not_found_404,
                                COMMON_NOT_COMPATIBILE_MESSAGE,
                                "",
                                traceId);
                                return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                            }
                        }
                        else
                        {
                            #region special fix for app bug.

                            if (((resourceModel.Api.Equals("/v3p/settings/conditions/statuses", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "GET")
                                || (resourceModel.Api.Equals("/v3p/settings/conditions/priorities", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "GET")
                                || (resourceModel.Api.Equals("/v3p/settings/conditions/types", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "GET")
                                || (resourceModel.Api.Equals("/v3p/records/{recordId}/conditions/{id}", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "PUT")
                                || (resourceModel.Api.Equals("/v3p/records/{recordId}/conditions", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "POST"))
                                && aa_response.Code == "1005" && aa_response.Status == 404
                                )
                            {
                                errorResponse = new WSErrorResponse(
                                                HttpStatusCode.NotFound,
                                                ErrorCodes.api_not_found_404,
                                                COMMON_NOT_COMPATIBILE_MESSAGE,
                                                null,
                                                traceId);
                                return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                            }

                            // quick bug fix for inspector getting conditions 
                            if (resourceModel.Api.Equals("/v3p/records/{recordId}/conditions", StringComparison.OrdinalIgnoreCase)
                                && resourceModel.HttpVerb == "GET"
                                && aa_response.Code == "1005"
                                && aa_response.Status == 404)
                            {
                                // call cloud api - /v3p1/records/{recordId}/conditions
                                return await CallV3p1ConditionAPI(requestFullUrl, _context.Token, _context.App, traceId);
                            }


                            #endregion

                            // AA response status 200, 
                            // e.g: {"status":200,"result":{"successCount":1,"failedCount":0,"failedIDs":[]}} (length == 73)
                            // it should return AA response directly 
                            if (aa_response.Status == 200 || String.IsNullOrEmpty(aa_response.Code) || aa_response.Code == ErrorCodes.not_found_404)
                            {
                                await AppendAAErrorMessageToResponseHeader(responseMessage,traceId);
                                return responseMessage;
                            }

                            string errorMessage = aa_response.Message == null ? String.Empty : aa_not_found_response;

                            // code 0 means the resource doesn't exist, api is ok, like get record by id returs null
                            if (aa_response.Code != "0"
                                && aa_response.Status == 404
                                && (errorMessage.Contains("The resource cannot been found")
                                    || errorMessage.Contains("Not Found")
                                    || errorMessage.Contains("You are experiencing exception 404")
                                    )
                                )
                            {
                                if (!String.IsNullOrWhiteSpace(aa_response.Code) || errorMessage.Contains("The resource cannot been found") || errorMessage.Contains("You are experiencing exception 404"))
                                {
                                    errorResponse = new WSErrorResponse(
                                        HttpStatusCode.NotFound,
                                        ErrorCodes.not_found_404,
                                        aa_response.Message,
                                        aa_response.More,
                                        traceId);

                                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                                }
                            }

                            // other apis error response
                            errorResponse = new WSErrorResponse(
                                HttpStatusCode.NotFound,
                                ErrorCodes.api_not_found_404,
                                COMMON_NOT_COMPATIBILE_MESSAGE,
                                null,
                                traceId);
                            return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                        }
                        #endregion 404 not found
                    }
                    #endregion

                    #region gateway 2.x version, gateway only supports get and post method
                    else if (responseMessage != null && responseMessage.StatusCode == HttpStatusCode.MethodNotAllowed) // 405
                    {
                        #region 405 method not allowed
                        errorResponse = new WSErrorResponse(
                            HttpStatusCode.InternalServerError,
                            ExceptionHelper.gateway_unspport_httpmethod_500,
                            COMMON_NOT_COMPATIBILE_MESSAGE,
                            "",
                            traceId);

                        var data = new LogEntity
                        {
                            TraceId = traceId,
                            Message = "Error happen in AAServiceProxyHandler",
                            Detail = "Gateway Http method not allowed. " + httpMethod + " " + requestFullUrl,
                            MethodName = "AAServiceProxyHandler.SendAsync()"
                        };
                        Log.Error(data);

                        return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                        #endregion 405 method not allowed
                    }

                    #endregion

                    #region AA/Gateway responses invalid data format like xml or text/html but HttpStatus is OK
                    else if (responseMessage != null
                        // gateway 3.0
                             && (responseMessage.StatusCode == HttpStatusCode.InternalServerError
                        // 7.2 with gateway 2.0
                                 || (responseMessage.StatusCode == HttpStatusCode.OK
                                        && "Internal Server Error".Equals(responseMessage.ReasonPhrase, StringComparison.OrdinalIgnoreCase)
                        // 7.1 with gateway 2.0 
                                     || (responseMessage.StatusCode == HttpStatusCode.OK
                                            && responseMessage.Content != null
                                            && responseMessage.Content.Headers != null
                                            && responseMessage.Content.Headers.ContentType != null
                                            && "text/html".Equals(responseMessage.Content.Headers.ContentType.MediaType, StringComparison.OrdinalIgnoreCase)
                                        )
                                    )
                               )
                            )
                    {
                        #region 500 internal server error
                        //header status==200
                        // No API framework in previous AA version case
                        //<ns1:XMLFault
                        // xmlns:ns1="http://cxf.apache.org/bindings/xformat">
                        // <ns1:faultstring
                        //    xmlns:ns1="http://cxf.apache.org/bindings/xformat">java.lang.NullPointerException
                        // </ns1:faultstring>
                        //</ns1:XMLFault>
                        string responseConentString = null;
                        try
                        {
                            responseConentString = await GetResponseContentString(responseMessage);
                            logData = new LogEntity()
                            {
                                Message = "Responsed Error from AA",
                                Detail = "AA Response 2:\r\n" + responseConentString,
                                MethodName = "AAServiceProxyHandler.SendAsync()",
                                RequestFrom = "AA",
                                TraceId = traceId
                            };
                            Log.Error(logData);

                            // change error code from gateway_error to friendly connection_failure
                            if (responseMessage != null && responseMessage.StatusCode == HttpStatusCode.InternalServerError)
                            {
                                if (!String.IsNullOrEmpty(responseConentString) && responseConentString.IndexOf("gateway_error") > -1)
                                {
                                    errorResponse = new WSErrorResponse(
                                                HttpStatusCode.InternalServerError,
                                                ExceptionHelper.gateway_connection_failure_500,
                                                String.Format("The connection to agency {0} failed.", _context.ServProvCode),
                                                "",
                                                traceId);
                                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                                }
                            }

                            if (!String.IsNullOrWhiteSpace(responseConentString)
                                && (responseConentString.TrimStart().StartsWith("<ns1:XMLFault", StringComparison.OrdinalIgnoreCase)
                                    || responseConentString.Contains("<title>JBossWeb/2.0.1.GA - Error report</title>")
                                    || (responseConentString.Contains("<title>500 - Internal server error.</title>")
                                        && responseConentString.TrimEnd().EndsWith("500-Gateway throw exception.Thread was being aborted.")
                                        && responseConentString.Contains("There is a problem with the resource you are looking for, and it cannot be displayed.") // only gateway 2.0 error message
                                        )
                                ))
                            {
                                // quick bug fix for inspector getting conditions 
                                if (resourceModel.Api.Equals("/v3p/records/{recordId}/conditions", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "GET")
                                {
                                    // call cloud api - /v3p1/records/{recordId}/conditions
                                    return await CallV3p1ConditionAPI(requestFullUrl,_context.Token,_context.App,traceId);
                                }

                                // other apis error response
                                errorResponse = new WSErrorResponse(
                                    HttpStatusCode.NotFound,
                                    ErrorCodes.api_not_found_404,
                                    COMMON_NOT_COMPATIBILE_MESSAGE,
                                    "",
                                    traceId);
                                return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                            }
                        }
                        catch (Exception ex)
                        {
                            string logMessage = String.Format("Response1:\r\n{0}\r\nException:\r\n{1}", responseConentString, ex.TraceInformation());

                            var data = new LogEntity
                            {
                                TraceId = traceId,
                                Message = "Error happen in AAServiceProxyHandler - aa api framework doesn't exist.",
                                Detail = logMessage,
                                MethodName = "AAServiceProxyHandler.SendAsync()"
                            };
                            Log.Error(data);
                        }
                        #endregion 500 internal server error
                    }
                    #endregion

                    #region AA/Gateway responses invalid data format like xml or text/html but HttpStatus is NOT OK
                    else if (responseMessage != null
                        && responseMessage.StatusCode != HttpStatusCode.OK
                        && responseMessage.Content != null
                        && responseMessage.Content.Headers != null
                        && responseMessage.Content.Headers.ContentType != null
                        && "text/html".Equals(responseMessage.Content.Headers.ContentType.MediaType, StringComparison.OrdinalIgnoreCase)
                        )
                    {
                        #region text/html handle
                        var responseConentString = await GetResponseContentString(responseMessage);
                        responseConentString = responseConentString != null ? responseConentString.Trim() : String.Empty;

                        logData = new LogEntity()
                        {
                            Message = "Responsed Error from AA",
                            Detail = "AA Response 3:\r\n" + responseConentString,
                            MethodName = "AAServiceProxyHandler.SendAsync()",
                            RequestFrom = "AA",
                            TraceId = traceId
                        };
                        Log.Error(logData);

                        // quick bug fix for inspector getting conditions 
                        if (resourceModel.Api.Equals("/v3p/records/{recordId}/conditions", StringComparison.OrdinalIgnoreCase) && resourceModel.HttpVerb == "GET")
                        {
                            // call cloud api - /v3p1/records/{recordId}/conditions
                            return await CallV3p1ConditionAPI(requestFullUrl, _context.Token, _context.App, traceId);
                        }
                        // fix issue "when AA does not response Content-Type header, or response invalid Content-Type header, AA version compatibility Error message handled in this file is thrown."
                        // change to ignore such case here. 
                        if (!String.IsNullOrWhiteSpace(responseConentString)
                            && ((responseConentString.StartsWith("{") && responseConentString.EndsWith("}"))
                                || (responseConentString.StartsWith("[") && responseConentString.EndsWith("]"))
                                )
                            )
                        {
                            await AppendAAErrorMessageToResponseHeader(responseMessage,traceId, false);
                            return responseMessage;
                        }

                        errorResponse = new WSErrorResponse(
                            HttpStatusCode.NotFound,
                            ErrorCodes.api_not_found_404,
                            COMMON_NOT_COMPATIBILE_MESSAGE,
                            "",
                            traceId);
                        return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                        #endregion text/html handle
                    }

                    #endregion

                    // Apped AA Error code and message to http response header
                    await AppendAAErrorMessageToResponseHeader(responseMessage,traceId);

                    return responseMessage;
                }
                catch (Exception ex)
                {
                    var logData = new LogEntity
                    {
                        TraceId = traceId,
                        Message = "Error happen in AAServiceProxyHandler",
                        Detail = ex.TraceInformation(),
                        MethodName = "AAServiceProxyHandler.SendAsync()"
                    };

                    var mobileException = ExceptionHelper.GetMobileExcepiton(ex);

                    if (ErrorCodes.internal_server_error_500.Equals(mobileException.ErrorCode))
                    {
                        Log.Error(logData);
                    }
                    else
                    {
                        Log.Warn(logData);
                    }

                    errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, mobileException.ErrorCode, mobileException.Message, mobileException.Detail, traceId);

                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                }

                #endregion AA Service Proxy Handle

            }
            catch (Exception ex)
            {
                var logData = new LogEntity
                {
                    TraceId = traceId,
                    Message = "Error happen in AAServiceProxyHandler",
                    Detail = ex.TraceInformation(),
                    MethodName = "AAServiceProxyHandler.SendAsync()"
                };
                Log.Error(logData);

                var mobileException = ExceptionHelper.GetMobileExcepiton(ex);
                var errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, mobileException.ErrorCode, mobileException.Message, mobileException.Detail, traceId);

                return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
            }
        }

        /// <summary>
        /// Temporarily fix inspector app 
        /// </summary>
        /// <returns></returns>
        private async Task<HttpResponseMessage> CallV3p1ConditionAPI(string requestUrl, string authToken, string app, string traceId)
        {
            Log.Info("CallV3p1ConditionAPI", "request url:\r\n" + requestUrl, "CallV3p1ConditionAPI()");

            // call cloud api - /v3p1/records/{recordId}/conditions
            requestUrl = requestUrl.Replace("/v3p/", "/v3p1/");
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            HttpRequestMessage request = new HttpRequestMessage();

            request.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_TraceId, traceId);
            request.AddHeaderKey("Authorization", authToken);
            request.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_AppId, app);

            request.RequestUri = new Uri(requestUrl);
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            responseMessage.Headers.TransferEncodingChunked = false;

            return responseMessage;

        }

        private long GetResponseConentLength(HttpResponseMessage responseMessage)
        {
            long result = 0;
            result = responseMessage.Content != null
                && responseMessage.Content.Headers != null
                && responseMessage.Content.Headers.ContentLength != null
                ? responseMessage.Content.Headers.ContentLength.Value : 0;
            return result;
        }

        private WSErrorResponse TryParseAAErrorResponse(string responseContent, string traceId)
        {
            if (String.IsNullOrWhiteSpace(responseContent))
            {
                return null;
            }

            WSErrorResponse aa_response = null;
            try
            {
                aa_response = JsonConverter.FromJsonTo<WSErrorResponse>(responseContent);
            }
            catch { }

            if (aa_response != null && aa_response.Status == 0 && aa_response.Code == null)
            {
                AAResponseBase v1ErrorResponse = null;
                try
                {
                    v1ErrorResponse = JsonConverter.FromJsonTo<AAResponseBase>(responseContent);
                }
                catch { }

                if (v1ErrorResponse != null && v1ErrorResponse.ResponseStatus != null)
                {
                    aa_response.Status = v1ErrorResponse.ResponseStatus.Status;
                    if (v1ErrorResponse.ResponseStatus.Detail != null)
                    {
                        aa_response.Code = v1ErrorResponse.ResponseStatus.Detail.Code;
                        aa_response.Message = v1ErrorResponse.ResponseStatus.Detail.Message;
                        aa_response.More = v1ErrorResponse.ResponseStatus.Detail.More;
                        aa_response.TraceId = traceId;
                    }
                }
            }

            return aa_response;
        }

        /// <summary>
        /// Apped AA Error code and message to http response header
        /// </summary>
        private async Task AppendAAErrorMessageToResponseHeader(HttpResponseMessage responseMessage, string traceId, bool onlyAppendWhenHttpStatusError = true)
        {
            // notice that Gateway 2.X always returns StatusCode as 200
            if (responseMessage != null )
            {
                // ignor if Http status is OK
                if (onlyAppendWhenHttpStatusError && responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return;
                }

                bool existErrorCode = responseMessage.Headers.Contains(ResponseHeaderConstants.X_Accela_Header_Error_Code);
                bool existErrorMessage = responseMessage.Headers.Contains(ResponseHeaderConstants.X_Accela_Header_Error_Message);

                // check response header - ResponseHeaderConstants.X_Accela_Header_Error_Message and Code
                // if doesn't exist, parse error from response body
                if (!existErrorCode || !existErrorMessage)
                {
                    var aa_response_content = await GetResponseContentString(responseMessage);
                    var aa_error_responseObject = TryParseAAErrorResponse(aa_response_content, traceId);

                    if (aa_error_responseObject != null
                        && !String.IsNullOrWhiteSpace(aa_error_responseObject.Code))
                    {
                        responseMessage.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_Error_Code, aa_error_responseObject.Code);
                    }

                    if (aa_error_responseObject != null
                        && !String.IsNullOrWhiteSpace(aa_error_responseObject.Message))
                    {
                        responseMessage.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_Error_Message, aa_error_responseObject.Message);
                    }
                }
            }
        }

        private async Task<string> GetResponseContentString(HttpResponseMessage responseMessage)
        {
            string result = null;

            if (responseMessage != null && responseMessage.Content != null)
            {
                var content = responseMessage.Content;
                var contentEncoding = content.Headers != null && content.Headers.ContentEncoding != null
                    ? content.Headers.ContentEncoding.ToString()
                    : String.Empty;
                var isGZipContentEncoding = contentEncoding.IndexOf("gzip", StringComparison.OrdinalIgnoreCase) != -1;
                var isDeflateContentEncoding = contentEncoding.IndexOf("deflate", StringComparison.OrdinalIgnoreCase) != -1;

                if (isGZipContentEncoding)
                {
                    var data = await content.ReadAsByteArrayAsync();
                    result = DecompressGZip(data);
                }
                //else if (isDeflateContentEncoding)
                //{
                //    api_framework_not_exist = DecompressGZip(content.ReadAsByteArrayAsync().Result);
                //}
                else
                {
                    result = await content.ReadAsStringAsync();
                }

                result = result ?? String.Empty;
            }

            return result;
        }

        private string DecompressGZip(byte[] compressed)
        {
            byte[] buffer = new byte[4096];
            using (MemoryStream ms = new MemoryStream(compressed))
            {
                using (GZipStream gzs = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (MemoryStream uncompressed = new MemoryStream())
                    {
                        for (int r = -1; r != 0; r = gzs.Read(buffer, 0, buffer.Length))
                        {
                            if (r > 0)
                            {
                                uncompressed.Write(buffer, 0, r);
                            }
                        }

                        var bytes = uncompressed.ToArray();
                        var result = Encoding.UTF8.GetString(bytes);
                        return result;
                    }
                }
            }
        }

    }
}
