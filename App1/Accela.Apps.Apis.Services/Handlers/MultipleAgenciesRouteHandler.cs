using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Services.Handlers.Helpers;
using Accela.Apps.Apis.WSModels.V4;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.User.Models;
using Accela.Apps.User.WSModels.V2.CloudUser;
using Accela.Apps.User.WSModels.V4;
using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.APIHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class MultipleAgenciesRouteHandler : DelegatingHandler
    {
        private static IConfigurationReader ConfigurationReader { get { return ConfigurationSettingsManager.Get(); } }

        private const string ALL_AGENCIES = "ALL";

        public MultipleAgenciesRouteHandler()
        {
            
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
            var _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");

            string traceId =String.Empty;
            WSErrorResponse errorResponse = null;
            try
            {
               
                traceId = _context.TraceID;
                string env = _context.EnvName;
                HttpMessage message = new HttpMessage(request);
                string agencies = message.GetHeaderValue("x-accela-agencies").Trim();

                if (String.IsNullOrEmpty(agencies))
                {
                    return await base.SendAsync(request, cancellationToken);
                }

                string appId = _context.App;

                string cloudUserId = _context.CivicId;

                if (string.IsNullOrWhiteSpace(cloudUserId))
                {
                    errorResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, "Token is required for data aggregation.", null, traceId);
                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                }

                string subsystemBaseUrl = ConfigurationReader.Get("Ref_InternalAPI_User").Split(new string[] { "/apis/" }, StringSplitOptions.None)[0];
                var resourceUri = UrlHelper.CombinePath(subsystemBaseUrl, "/apis/v4/civicId/accounts"); 
                var client = new InternalAPIClient(_context);  
                var wsAccounts = client.Execute<GenericResultResponse<WSLinkedAccountsV4>>(resourceUri);

                if(wsAccounts == null)
                {
                    return GetEmptyJsonResult(request);
                }

                IDictionary<string, string[]> agencyToAATokenMap = new Dictionary<string, string[]>();
                var accounts = new List<LinkedSocialAccountModel>();

                if(_context.AppType == AppType.Agency)
                {
                    if (wsAccounts.Result.AgencyAccounts == null || !wsAccounts.Result.AgencyAccounts.Any())
                    {
                        return GetEmptyJsonResult(request);
                    }

                    // get linked agency Accounts
                    if (ALL_AGENCIES.Equals(agencies,StringComparison.OrdinalIgnoreCase))
                    {
                        accounts = wsAccounts.Result.AgencyAccounts;
                    }
                    else
                    {
                        // Fiter agency by client request
                        var agencyListFromHeader = GetAgenciesFromHeader(agencies);
                        accounts = GetLinkedAccountsFilterBy(GetAgenciesFromHeader(agencies), wsAccounts.Result.AgencyAccounts);
                    }

                    if(accounts == null || accounts.Count == 0)
                    {
                        return GetEmptyJsonResult(request);
                    }

                    // get AA token per agency(Agency)
                    foreach (var account in accounts)
                    {
                        BizTokenModel bizToken = null;
                        try
                        {
                            bizToken = BizTokenHelper.GetRegisteredAgencyUserToken(cloudUserId, account.AgencyName, account.Name, env, _context);
                            agencyToAATokenMap.Add(account.AgencyName, new string[2] { bizToken.Token, env });
                        }
                        catch(Exception ex)
                        {
                            var logData = new LogEntity
                            {
                                TraceId = traceId,
                                Message = ex.Message,
                                Detail = ex.TraceInformation(),
                                MethodName = "MultipleAgenciesRouteHandler.SendAsync()"
                            };
                            Log.Error(logData);
                        }
                    }               
                }
                else if(_context.AppType == AppType.Citizen)
                {
                    if (wsAccounts.Result.CitizenAccounts == null || !wsAccounts.Result.CitizenAccounts.Any())
                    {
                        return GetEmptyJsonResult(request);
                    }

                    // get linked Citizen Accounts

                    if (ALL_AGENCIES.Equals(agencies,StringComparison.OrdinalIgnoreCase))
                    {
                        accounts = wsAccounts.Result.CitizenAccounts;
                    }
                    else
                    {
                        // Fiter agency by client request
                        var agencyListFromHeader = GetAgenciesFromHeader(agencies);
                        accounts = GetLinkedAccountsFilterBy(agencyListFromHeader, wsAccounts.Result.CitizenAccounts);
                    }

                    if (accounts == null || accounts.Count == 0)
                    {
                        return GetEmptyJsonResult(request);
                    }

                    // get AA token per agency(Citizen)
                    foreach (var account in accounts)
                    {
                        BizTokenModel bizToken = null;
                        try
                        {
                            bizToken = bizToken = BizTokenHelper.GetRegisteredCitizenUserToken(cloudUserId, account.AgencyName, account.Name, env, false, _context);
                            agencyToAATokenMap.Add(account.AgencyName, new string[2] { bizToken.Token, env });
                        }
                        catch (Exception ex)
                        {
                            var logData = new LogEntity
                            {
                                TraceId = traceId,
                                Message = ex.Message,
                                Detail = ex.TraceInformation(),
                                MethodName = "MultipleAgenciesRouteHandler.SendAsync()"
                            };
                            Log.Error(logData);

                            if(ex is MobileException)
                            {
                                MobileException me = ex as MobileException;

                                // this needs a proper error code instead of common 401, means no linked accounts.
                                if(me.ErrorCode == ErrorCodes.unauthorized_401 && me.Message == "Biz token is expired, please try to sign in.")
                                {
                                    continue;
                                }
                            }
                            // No linked account at this environment, notice the message is confused but is thrown when get linked account in use subsystem
                            // just a quick fix, need to a story follow up.
                            if(!ex.Message.Contains("Environment name not found"))
                            {
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("App Type is null.");
                }

                // if AA token not found, return empty
                if(agencyToAATokenMap.Count == 0)
                {
                    return GetEmptyJsonResult(request);
                }

                var agencyToAATokenModels = agencyToAATokenMap.ToArray();

                Task<HttpResponseMessage>[] tasks = new Task<HttpResponseMessage>[agencyToAATokenModels.Length];
                List<JObject> responsesOfJObjects = new List<JObject>();

                bool allRequestsReturnSameHttpStatus = true;
                bool existHttpStatusOk = false;

                // Change Context to specific agency context
                for (int i = 0; i < agencyToAATokenModels.Length; i++ )
                {
                    var token = agencyToAATokenModels[i];
                    var agencyName = token.Key;
                    var bizToken = token.Value[0];
                    var environment = token.Value[1];
                    HttpRequestMessage requestOne = new HttpRequestMessage();
                    var requestClone = Clone(request);

                    // flag to indicate whether update context(agency/environment/biztoken)
                    if (requestClone.Properties.ContainsKey("x-accela-replacecontext"))
                    {
                        requestClone.Properties["x-accela-replacecontext"] = true;
                    }
                    else
                    {
                        requestClone.Properties.Add("x-accela-replacecontext", true);
                    }

                    requestClone.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_TraceId, _context.TraceID);
                    requestClone.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_Environment, environment);
                    requestClone.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_Agency, agencyName);

                    if (requestClone.Properties.ContainsKey("x-accela-biztoken"))
                    {
                        requestClone.Properties["x-accela-biztoken"] = bizToken;
                    }
                    else
                    {
                        requestClone.Properties.Add("x-accela-biztoken", bizToken);
                    }
                   
                    tasks[i] = Task.Factory.StartNew(() =>
                    {
                        var childContext = _context.Clone();
                        childContext.Agency = agencyName;
                        childContext.EnvName = environment;
                        CallContext.LogicalSetData("ContextEntity", childContext);
                        Task<HttpResponseMessage> response = base.SendAsync(requestClone, cancellationToken);

                        return response.Result;
                    });
                }

                await Task.WhenAll(tasks);

                HttpStatusCode tmpStatus = HttpStatusCode.OK;
                HttpResponseMessage tmpResponse = null;

                for(int i=0; i < tasks.Length ; i++)
                {
                    if (tasks[i].Result.StatusCode == HttpStatusCode.OK)
                    {
                        existHttpStatusOk = true;
                        var r = AddResourceElementToResponse(tasks[i].Result, agencyToAATokenModels[i].Key, agencyToAATokenModels[i].Value[1]);

                        responsesOfJObjects.Add(r);
                    }
                    else
                    {
                        var logData = new LogEntity
                        {
                            TraceId = traceId,
                            Message = String.Format("Responsed error from Agency:{0}, Environment:{1}. HttpStatus : {2}", agencyToAATokenModels[i].Key, agencyToAATokenModels[i].Value[1], tasks[i].Result.StatusCode),
                            Detail = tasks[i].Result.Content == null ? "Result.Content is null" : tasks[i].Result.Content.ReadAsStringAsync().Result,
                            MethodName = "MultipleAgenciesRouteHandler.SendAsync()"
                        };

                        Log.Error(logData);
                    }

                    if(i == 0)
                    {
                        tmpStatus = tasks[i].Result.StatusCode;
                        tmpResponse = tasks[i].Result;
                    }
                    else
                    {
                        if(tasks[i].Result.StatusCode != tmpStatus)
                        {
                            allRequestsReturnSameHttpStatus = false; 
                        }
                    }
                }

                // if return the same error response from all agenies then response any one of errors
                if (!existHttpStatusOk && allRequestsReturnSameHttpStatus)
                {
                    return tmpResponse;
                }

                // merge all responses
                var mergedJObject = MergeJObjectsToOneJObject(responsesOfJObjects.ToArray());

                if(mergedJObject == null)
                {
                    var logData = new LogEntity
                    {
                        TraceId = traceId,
                        Message = "There is no data response from remote server."
                    };

                    Log.Error(logData);
                    //throw new Exception("There is no data response from remote server.");
                    errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, logData.Message, null, traceId);

                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
                }

                HttpResponseMessage responseMessage = null;

                responseMessage = ConvertJObjectToHttpResponseMessage(mergedJObject, request);
                responseMessage.Content.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                return responseMessage;
            }
            catch (Exception ex)
            {
                var logData = new LogEntity
                {
                    TraceId = traceId,
                    Message = "Error happen in MultipleAgenciesRouteHandler",
                    Detail = ex.TraceInformation(),
                    MethodName = "MultipleAgenciesRouteHandler.SendAsync()"
                };
                Log.Error(logData);
                string errorMsg = "Unknown server error, please contact administrator.";
                if(ex is MobileException)
                {
                    errorMsg = ex.Message;
                }
                errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, errorMsg, ex.ToString(), traceId);

                return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
            }
        }

        private JObject MergeJObjectsToOneJObject(JObject[] jobjects)
        {
            JObject jResult = null;

            if (jobjects == null || jobjects.Length == 0)
            {
                return null;
            }

            if (jobjects.Length == 1)
            {
                return jobjects[0];
            }
            else
            {
                var mergeSettings = new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union
                };

                // There is no 'result' element in reponse in some apis, e.g: {"status":200}
                jResult = null;
                bool hasResultsInJobject = false;

                for (int i = 0; i < jobjects.Length; i++)
                {
                    var tmpResult = jobjects[i].SelectToken("result");
                    if (!hasResultsInJobject && tmpResult != null)
                    {
                        jResult = jobjects[i];
                        hasResultsInJobject = true;
                        continue;
                    }

                    if(tmpResult != null)
                    {
                        (jResult.SelectToken("result") as JArray).Merge(tmpResult, mergeSettings);
                    }   
                }

                // if there is no 'result' element, return 1st result which status is ok
                if(jResult == null)
                {
                    foreach(var obj in jobjects)
                    {
                        var jTokenForStatus = obj.SelectToken("status");
                        if(jTokenForStatus != null && jTokenForStatus.Value<int?>() == (int) HttpStatusCode.OK)
                        {
                            return obj;
                        }
                    }

                    // other case just return 1st jobject.
                    jResult = jobjects[0];
                }
            }

            return jResult;
        }

        private HttpResponseMessage ConvertJObjectToHttpResponseMessage(JObject jobject, HttpRequestMessage request)
        {
            if(jobject == null)
            {
                throw new ArgumentNullException("jobject is null.");
            }

            var r = jobject.ToString(Formatting.None);

            var result = request.CreateResponse();
            result.Content = new StringContent(r);

            return result;
        }

        private JObject AddResourceElementToResponse(HttpResponseMessage response, string agency, string environment)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            var jResult = JObject.Parse(content);
            JArray jarray = jResult.SelectToken("result") as JArray;

            if(jarray == null)
            {
                return jResult;
            }

            foreach (var item in jarray.Children())
            {
                var addedElement = new JObject();
                addedElement["agency"] = agency;
                addedElement["environment"] = environment;
                item["resource"] = addedElement;
            }

            return jResult;
        }

        private Task<HttpResponseMessage> AsyncRequest(string requestUrl, IAgencyAppContext context)
        {
            var logData = new LogEntity
            {
                TraceId = context.TraceID,
                Message = "MultipleAgenciesRouteHandler.AsyncRequest()",
                Detail = "request url:\r\n" + requestUrl
            };
            Log.Info(logData);

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            HttpRequestMessage request = new HttpRequestMessage();

            request.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_TraceId, context.TraceID);
            request.AddHeaderKey("Authorization", context.Token);
            request.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_AppId, context.App);

            request.RequestUri = new Uri(requestUrl);
            var httpClient = new HttpClient();
            var responseMessage = httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            responseMessage.Result.Headers.TransferEncodingChunked = false;

            return responseMessage;

        }

        private static List<LinkedSocialAccountModel> GetLinkedAccountsFilterBy(List<string> agencyListFromHeader, List<LinkedSocialAccountModel> allLinkedAccounts)
        {
            var result = new List<LinkedSocialAccountModel>();

            foreach (var agency in allLinkedAccounts)
            {
                foreach (var agencyInHeader in agencyListFromHeader)
                {
                    if (agencyInHeader.Equals(agency.AgencyName, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(agency);
                        break;
                    }
                }
            }

            return result;
        }

        private static List<string> GetAgenciesFromHeader(string agencies)
        {
            List<string> result = new List<string>();

            if(String.IsNullOrWhiteSpace(agencies))
            {
                return result;
            }

            result = agencies.Trim().Split(',').ToList();

            // Remove duplicate items
            return result;
        }

        private static HttpRequestMessage Clone( HttpRequestMessage req)
        {
            HttpRequestMessage clone = new HttpRequestMessage(req.Method, req.RequestUri);

            clone.Content = req.Content;
            clone.Version = req.Version;

            foreach (KeyValuePair<string, object> prop in req.Properties)
            {
                clone.Properties.Add(prop);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in req.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        private static void SetResponseContentType(HttpResponseMessage responseMessage)
        {
            if (responseMessage != null && responseMessage.Content != null && responseMessage.Content.Headers != null)
            {
                responseMessage.Content.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            }
        }

        private static HttpResponseMessage GetEmptyJsonResult(HttpRequestMessage request)
        {
            var result = request.CreateResponse();
            result.Content = new ObjectContent<object>(new
            {
                status = 200,
                result = new List<object>(),
            }, new System.Net.Http.Formatting.JsonMediaTypeFormatter());

            return result;
        }
    }
}
