using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.Common;
using Accela.Apps.Apis.Models.DomainModels.AsyncRequestModels;
using Accela.Apps.Apis.Services.Handlers.Helpers;
using Accela.Apps.Apis.WSModels.Common;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Accela.Apps.Apis.APIHandlers
{
    public class AvoidDuplicateSubmissionHandler : DelegatingHandler
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

        private IAsyncRequestBusinessEntity _asyncRequestBiz = null;
        private IAsyncRequestBusinessEntity AsyncRequestBiz
        {
            get
            {
                if(_asyncRequestBiz == null)
                {
                    _asyncRequestBiz = IocContainer.Resolve<IAsyncRequestBusinessEntity>();
                }

                return _asyncRequestBiz;
            }
        }

        private const string ASYNC_FLAG_IN_QUERYSTRING = "async";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");

            string traceId = _context.TraceID;
            try
            {
                var message = new HttpMessage(request);
                string requestAbsoluteUrl = message.GetAPIRelativePath();
                // 1.prefix '/apis/' is used for internal api and skip it
                if (requestAbsoluteUrl.StartsWith("/apis/", StringComparison.OrdinalIgnoreCase))
                {
                    return await base.SendAsync(request, cancellationToken);
                }

                // 2.if it is '/v4/async/result?requestId={requestId}' api then continue process and return the result
                if (IsGetAsyncResultAPI(request))
                {
                    return await GetAsyncResultHandle(request, cancellationToken, traceId);
                }

                // 3.else check whether the api with async=true in querystring
                bool isRequestForAvoidDuplicateSubmission = IsRequestForAvoidDuplicateSubmission(request);

                // if there exists async=true in querystring, means it is async request
                if (isRequestForAvoidDuplicateSubmission)
                {
                    var resourceModel = ResourceHelper.GetResourceModelFromRequestOrCache(request);

                    if (resourceModel == null)
                    {
                        var resourceNotFound = ErrorResponses.GetAPINotFoundResponse(request, traceId);
                        resourceNotFound.TraceId = traceId;
                        WriteLog(resourceNotFound);
                        return HttpResponseHelper.BuildErrorResponse(request, resourceNotFound, traceId);
                    }

                    //4. Cache request data and immidiatly response requestId to client
                    return AsyncAPIImmediatelyResponseHandle(request, cancellationToken);
                }
                
            }
            catch (Exception ex)
            {
                var logData = new LogEntity {
                    TraceId = traceId,
                    Message = "AvoidDuplicateSubmissionHandler",
                    Detail  = ex.ToString()
                };

                Log.Critical(logData);
                var errorResponse = new WSErrorResponse
                {
                    Code = ErrorCodes.internal_server_error_500,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    More = ex.ToString(),
                    TraceId = traceId
                };

                return HttpResponseHelper.BuildErrorResponse(request, errorResponse, traceId);                
            }

            //5. no flag with async=true, call next handler.
            return await base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> GetAsyncResultHandle(HttpRequestMessage request, CancellationToken cancellationToken, string traceId)
        {
            string requestId = HttpUtility.ParseQueryString(request.RequestUri.Query).Get("RequestId").Trim().ToLower();

            #region 1. request id validation
            // 1. Validate request id((guid-yyyyMMdd)
            if (String.IsNullOrWhiteSpace(requestId) || requestId.Length != 41)
            {
                var errorResponse = new WSErrorResponse
                {
                    TraceId = traceId,
                    Status = (int)HttpStatusCode.BadRequest,
                    Code = ErrorCodes.data_validation_error_400,
                    Message = "Invalid requestId.",
                    More = String.IsNullOrWhiteSpace(requestId) ? "requestId parameter is required in URL." : "The requestId is invalid."
                };
                WriteLog(errorResponse);

                return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
            }

            #endregion

            #region 2. validate whether request model in cache
            // 2. Get current request status by request id
            var requestStatusModel = AsyncRequestBiz.Get(requestId);

            // 2.1 request id doesn't exist
            if(requestStatusModel == null)
            {
                var errorResponse = new WSErrorResponse
                {
                    TraceId = traceId,
                    Status = (int)HttpStatusCode.BadRequest,
                    Code = ErrorCodes.data_validation_error_400,
                    Message = "Invalid requestId.",
                    More = "Invalid requestId or the requestId has been removed."
                };
                WriteLog(errorResponse);
                return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
            }

            #endregion

            // 2.2 get current request status
            string currentProcessStatus = requestStatusModel.Status;

            // 3. Handle flow by status
            if (currentProcessStatus == AsyncProcessState.Created.ToString())
            {
                #region 3.1 Update status to 'Running' and continue handle the request
                //3.1 Sync process
                if (requestStatusModel.RequestData == null)
                {
                    var errorResponse = new WSErrorResponse
                    {
                        TraceId = traceId,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Code = ErrorCodes.internal_server_error_500,
                        Message = "Invalid requestId.",
                        More = "Invalid requestId or the requestId has been removed."
                    };
                    WriteLog(errorResponse);

                    return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
                }

                //update request status to 'Running'
                AsyncRequestBiz.UpdateRequestStatus(requestId, AsyncProcessState.Running);

                try
                {
                    HttpRequestMessage requestMessage = new HttpRequestMessage();

                    requestMessage.Method = requestStatusModel.RequestData.HttpMethod.ToHttpMethod();
                    // removed async=true from query string 
                    requestMessage.RequestUri = new Uri(RemoveQueryStringByKey(requestStatusModel.RequestData.Url, "async"));

                    foreach (var h in requestStatusModel.RequestData.Headers)
                    {
                        // Replace previous cached traceId with new traceId
                        if (h.Key.Equals(ResponseHeaderConstants.X_Accela_Header_TraceId,StringComparison.OrdinalIgnoreCase))
                        {
                            requestMessage.Headers.Remove(ResponseHeaderConstants.X_Accela_Header_TraceId);
                            requestMessage.Headers.TryAddWithoutValidation(h.Key, traceId);
                        }
                        else
                        {
                            requestMessage.Headers.TryAddWithoutValidation(h.Key, h.Value);
                        }
                    }

                    requestMessage.Headers.TryAddWithoutValidation(ResponseHeaderConstants.X_Accela_Header_SubSystem_Caller, ConfigurationReader.Get(ConfigurationConstant.CURRENT_SUB_SYSTEM));

                    if (requestMessage.Method == HttpMethod.Get)
                    {
                        requestMessage.Content = null;
                    }
                    else
                    {
                        if (requestStatusModel.RequestData != null)
                        {
                            requestMessage.Content = new StreamContent(requestStatusModel.RequestData.Content);

                           if (!String.IsNullOrWhiteSpace(requestStatusModel.RequestData.ContentType_MediaType))
                           {
                               requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(requestStatusModel.RequestData.ContentType_MediaType);
                           }

                           if (requestMessage.Content.Headers.ContentType != null
                               && requestStatusModel.RequestData.ContentType_Parameters != null
                               && requestStatusModel.RequestData.ContentType_Parameters.Count > 0
                               )
                           {
                               foreach (var p in requestStatusModel.RequestData.ContentType_Parameters)
                               {
                                   System.Net.Http.Headers.NameValueHeaderValue item = new System.Net.Http.Headers.NameValueHeaderValue(p.Key);
                                   item.Value = p.Value;
                                   requestMessage.Content.Headers.ContentType.Parameters.Add(item);
                               }
                           }

                           if (!String.IsNullOrWhiteSpace(requestStatusModel.RequestData.ContentType_CharSet))
                           {
                               requestMessage.Content.Headers.ContentType.CharSet = requestStatusModel.RequestData.ContentType_CharSet;
                           }
                        }
                    }

                    // send request to target url
                    // TODO: consolidate HTTP client logic and timeout configuration
                    var httpClient = new HttpClient();
                    httpClient.Timeout = new TimeSpan(0, 0, 5, 0, 0); // timeout = 5 mins
                    var responseMessage = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead);
                    responseMessage.Result.Headers.TransferEncodingChunked = false;

                    AsyncHttpResponseMessage clone = responseMessage.Result.ToAsyncHttpResponseMessage();
                    // update status to complete
                    AsyncRequestBiz.UpdateResponseData(requestId, clone);

                    return responseMessage;
                }
                catch(Exception ex)
                {
                    // update status to complete with error message
                    AsyncRequestBiz.UpdateResponseData(requestId, null, 
                        ex.InnerException == null ? ex.Message : string.Format("{0}; {1}",ex.Message , ex.InnerException.Message));

                    var errorResponse = new WSErrorResponse
                    {
                        TraceId = traceId,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Code = ErrorCodes.internal_server_error_500,
                        Message = "Server Error, please conatct administrator.",
                        More = ex.ToString()
                    };
                    try
                    {
                        AsyncRequestBiz.UpdateResponseData(requestId, null, ex.Message);
                    }
                    catch{}
                    WriteLog(errorResponse);
                    return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
                }
                #endregion 3.1 Update status to 'Running' and continue handle the request
            }
            else if(currentProcessStatus == AsyncProcessState.Running.ToString())
            {
                #region 3.2 Handle Running case - waitting until the status is change to 'Completed'
                // waitting until the status is change to 'Completed'
                int times = 100; // 100*3 = 300 seconds
                AsyncRequestStatusModel requestStatusModelRefresh = null;
                while(currentProcessStatus != AsyncProcessState.Completed.ToString() && times > 0)
                {
                    times--;
                    Thread.Sleep(3000);
                    requestStatusModelRefresh = AsyncRequestBiz.Get(requestId);
                }

                if (requestStatusModelRefresh != null && requestStatusModelRefresh.Status == AsyncProcessState.Completed.ToString())
                {
                    return GetCompleteResult(request, requestStatusModelRefresh, traceId);
                }
                else // timeout
                {
                    // maybe something is wrong and can't convert status to 'Completed' or the backend handle is more than 300s
                    var errorResponse = new WSErrorResponse
                    {
                        TraceId = traceId,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Code = ErrorCodes.internal_server_error_500,
                        Message = "Server Error, please conatct administrator.",
                        More = "Perhaps something is wrong in server side and can't convert status to 'Completed' or the backend handle is more than 300s."
                    };

                    try { 
                    AsyncRequestBiz.UpdateResponseData(requestId, null, "Running Timeout");
                    }
                    catch { }
                    WriteLog(errorResponse);
                    return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
                }

                #endregion
            }
            else if(currentProcessStatus == AsyncProcessState.Completed.ToString())
            {
                #region 3.3 Response cached date if the status is 'Completed'

                return GetCompleteResult(request, requestStatusModel, traceId);

                #endregion
            }
            else
            {
                #region 3.4 Exception Case - SHOULD not happen
                var errorResponse = new WSErrorResponse
                {
                    TraceId = traceId,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Code = ErrorCodes.internal_server_error_500,
                    Message = "Server Error, please conatct administrator.",
                    More = "Invalid async request status -" + currentProcessStatus
                };
                WriteLog(errorResponse);
                return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
                #endregion
            }
        }

        private HttpResponseMessage AsyncAPIImmediatelyResponseHandle(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Return Http Code 202 - Accepted
            // 1. Generate a unique request id
            string requestId = GenerateRequestId();

            AsyncHttpRequestMessage clonedRequestData = request.ToAsyncHttpRequestMessage();

            AsyncRequestStatusModel asyncRequestModel = new AsyncRequestStatusModel
            {
                RequestID = requestId,
                RequestUrl = request.RequestUri.ToString(),
                HttpMethod = request.Method.Method,
                RequestData = clonedRequestData
            };

            AsyncRequestBiz.Add(asyncRequestModel);

            return SendCurrentState(requestId, AsyncProcessState.Created.ToString(), request);
        }

        private static HttpResponseMessage SendCurrentState(string requestId, string state, HttpRequestMessage request, HttpStatusCode statusCode = HttpStatusCode.Accepted)
        {
            var responseEntity = new GenericResultResponse<AsyncRequestIdV4>
            {
                Result = new AsyncRequestIdV4 { RequestId = requestId, State = state },
                Status = (int)statusCode
            };

            var responseMessage = request.CreateResponse(statusCode);
            responseMessage.Content = new ObjectContent(typeof(GenericResultResponse<AsyncRequestIdV4>), responseEntity, new JsonMediaTypeFormatter());

            return responseMessage;
        }

        private Task<HttpResponseMessage> GetCompleteResult(HttpRequestMessage request, AsyncRequestStatusModel asyncStatusModel,string traceId)
        {
            #region 3.3 Response cached date if the status is 'Completed'
            // response result - Ok - 200
            if (asyncStatusModel.ResponseData == null)
            {
                var errorResponse = new WSErrorResponse
                {
                    TraceId = traceId,
                    Status = (int)HttpStatusCode.BadRequest,
                    Code = ErrorCodes.bad_request_400,
                    Message = "Invalid requestId.",
                    More = "Invalid requestId or the response data was expired or removed."
                };
                WriteLog(errorResponse);

                return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
            }
            else
            {
                HttpResponseMessage cloneReturn = asyncStatusModel.ResponseData.ToHttpResponseMessage(request);

                // revise cached trace id with exact trace id for this response
                cloneReturn.Headers.Remove(ResponseHeaderConstants.X_Accela_Header_TraceId);
                cloneReturn.Headers.TryAddWithoutValidation(ResponseHeaderConstants.X_Accela_Header_TraceId, traceId);

                return Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return cloneReturn;
                });
            }
            #endregion
        }

        /// <summary>
        /// Indicates whether request api requires async.
        /// </summary>
        /// <param name="request">current request instance of HttpRequestMessage.</param>
        /// <returns>true/false.</returns>
        private bool IsRequestForAvoidDuplicateSubmission(HttpRequestMessage request)
        {
            string asyncFlag = HttpUtility.ParseQueryString(request.RequestUri.Query).Get(ASYNC_FLAG_IN_QUERYSTRING);

            if (String.IsNullOrWhiteSpace(asyncFlag))
            {
                return false;
            }

            return asyncFlag.Trim().Equals(Boolean.TrueString, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether the apis is '/v4/async/result'
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool IsGetAsyncResultAPI(HttpRequestMessage request)
        {
            var message = new HttpMessage(request);
            var apiRelatieUrl = message.GetAPIRelativePathWithoutQueryString();   
            return apiRelatieUrl.Equals("/v3/async/result", StringComparison.OrdinalIgnoreCase)
                || apiRelatieUrl.Equals("/v4/async/result", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// New a unique request id(guid-yyyyMMdd).
        /// </summary>
        /// <returns>request id.</returns>
        private static string GenerateRequestId()
        {
            // request Id plus expirydate
            return Guid.NewGuid().ToString().ToLower().Replace("-",String.Empty) + "-" + 
                DateTime.UtcNow.AddDays(CacheConstants.API_TEMPDATA_ASYNCDATA_DAYS).ToString(CacheConstants.API_TEMPDATA_CONTAINER_DATEFORMAT);
        }

        private static string RemoveQueryStringByKey(string url, string key)
        {                   
            var uri = new Uri(url);

            // this gets all the query string key value pairs as a collection
            var newQueryString = HttpUtility.ParseQueryString(uri.Query);

            // this removes the key if exists
            newQueryString.Remove(key);

            // this gets the page path from root without QueryString
            string pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

            return newQueryString.Count > 0
                ? String.Format("{0}?{1}", pagePathWithoutQueryString, newQueryString)
                : pagePathWithoutQueryString;
        }



        private void WriteLog(WSErrorResponse error)
        {
            if (error != null)
            {
                string more = null;
                try
                {
                    more = Accela.Apps.Shared.JsonConverter.ToJson(error);
                }
                catch (Exception ex)
                {
                    more = error.More;
                }

                var logData = new LogEntity
                {
                    TraceId = error.TraceId,
                    Message = error.Message,
                    Detail =  more,
                    MethodName = "AvoidDuplicateSubmissionHandler"
                };
                Log.Error(logData);
            }
        }
    }
}