using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Services;
using Accela.Apps.Apis.Services.Handlers.Helpers;
using Accela.Apps.Apis.WSModels.Common;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Apps.Shared.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.APIHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class BatchRequestHandler : DelegatingHandler
    {
        private const int MAX_BATCH_REQUEST_NUM = 25;

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
            WSErrorResponse errorResponse = null;
            var _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");

            try
            {
                traceId = _context.TraceID;
                HttpMessage message = new HttpMessage(request);
                string httpMethod = message.GetHttpMethod();
                string requestAbsoluteUrl = message.GetAPIRelativePathWithoutQueryString();

                if (!"/v4/batch".Equals(requestAbsoluteUrl, StringComparison.OrdinalIgnoreCase))
                {
                    return await base.SendAsync(request, cancellationToken);
                }

                var resourceModel = ResourceHelper.GetResourceModelFromRequestOrCache(request);

                if (resourceModel == null)
                {
                    errorResponse = ErrorResponses.GetAPINotFoundResponse(request, traceId);
                    WriteLog(errorResponse);
                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, traceId);
                }

                // if it's construct batch request api
                string requestBody = request.Content.ReadAsStringAsync().Result;
                WSBatchChildRequest[] requestBodyObjects = null;

                try
                {
                    requestBodyObjects = Newtonsoft.Json.JsonConvert.DeserializeObject(requestBody, typeof(WSBatchChildRequest[])) as WSBatchChildRequest[];
                }
                catch(Exception ex)
                {
                    var errorMessage = "Invalid request body. Failed to parse request body as a json object.";
                    errorResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, errorMessage, null,traceId);
                    WriteLog(errorResponse, ex);
                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, traceId);
                }

                // bad request
                if(requestBodyObjects == null || !requestBodyObjects.Any())
                {
                    errorResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, "Invalid request body, no child api is found.", null, traceId);
                    WriteLog(errorResponse);
                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, traceId);
                }

                // max request limitation
                if (requestBodyObjects.Length > MAX_BATCH_REQUEST_NUM)
                {
                    errorResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, "Batch api only supports to maximum " + MAX_BATCH_REQUEST_NUM + " apis.", null, traceId);
                    WriteLog(errorResponse);
                    return HttpResponseHelper.BuildErrorResponse(request, errorResponse, traceId);
                }

                // validate request data for each child request
                foreach(var requestItem in requestBodyObjects)
                {
                    string errorMessage = null;

                    if (requestItem == null)
                    {
                        errorMessage = "Invalid request body. All chidren request content is requried.";
                    }
                    else
                    {
                        if (requestItem.RelativeUrl != null && !requestItem.RelativeUrl.StartsWith("/"))
                            requestItem.RelativeUrl = "/" + requestItem.RelativeUrl;

                        if (!isValidMethod(requestItem.method) || String.IsNullOrWhiteSpace(requestItem.RelativeUrl))
                        {
                            errorMessage = "Invalid request body. method and url are requied for each child request.";
                        }
                        else if (requestItem.RelativeUrl.StartsWith("/v4/batch", StringComparison.OrdinalIgnoreCase) || requestItem.RelativeUrl.StartsWith("/batch", StringComparison.OrdinalIgnoreCase))
                        {
                            errorMessage = "Invalid request body. Batch api is not allowed as child request.";
                        }
                    }

                    if(errorMessage != null)
                    {
                        errorResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, errorMessage, null, traceId);
                        WriteLog(errorResponse);
                        return HttpResponseHelper.BuildErrorResponse(request, errorResponse, traceId);
                    }
                }

                GenericResultResponse<List<object>> responseBatchObject = new GenericResultResponse<List<object>>();
                responseBatchObject.Status = (int)(HttpStatusCode)200; // Rollback to 200; TODO later 207 - Multi-Status
                responseBatchObject.Result = new List<object>();
                //responseBatchObject.result = new List<WSBatchResponseItem>();
                var applicationRootPath = message.GetApplicationRootUrl();

                Task<string>[] tasks = new Task<string>[requestBodyObjects.Length];
                // Send request one by one
                for(int i=0; i < requestBodyObjects.Length; i++) 
                {
                    var requestItem = requestBodyObjects[i];

                    HttpRequestMessage requestOneByOne = new HttpRequestMessage(ConvertToHttpMethod(requestItem.method), new Uri(applicationRootPath + requestItem.RelativeUrl));
                    requestOneByOne.Headers.TryAddWithoutValidation(ResponseHeaderConstants.X_Accela_Header_TraceId, traceId);
                    requestOneByOne.Properties.Add(Constants.PROPERTIES_KEY_CHILDAPI_FROM_BATCHREQUEST, true);
                    if(requestItem.hearders != null && requestItem.hearders.Any())
                    {
                        foreach(var h in requestItem.hearders)
                        {
                            if(!String.IsNullOrWhiteSpace(h.Value))
                            {
                                requestOneByOne.Headers.TryAddWithoutValidation(h.Key, h.Value);
                            } 
                        }
                    }

                    // put Authorization for each child api
                    if (!requestOneByOne.Headers.Contains("Authorization"))
                    {
                        requestOneByOne.Headers.TryAddWithoutValidation("Authorization", message.GetToken());
                    }
     
                    // Clone request properties
                    //if(request.Properties.Any())
                    //{
                    //    KeyValuePair<string, object>[] requestProperties = new KeyValuePair<string, object>[request.Properties.Count];

                    //    request.Properties.CopyTo(requestProperties, 0);
                        
                    //    foreach(var p in requestProperties)
                    //    {
                    //        // child request has the diffrent apis, resourceModel is different, need to clear from clone request.
                    //        if (!Constants.PROPERTIES_KEY_RESOURCE_MODEL.Equals(p.Key))
                    //        {
                    //            requestOneByOne.Properties.Add(p);
                    //        }
                    //    }
                    //}

                    if(!requestItem.method.Equals("GET",StringComparison.OrdinalIgnoreCase))
                    {
                        requestOneByOne.Content = new StringContent(requestItem.body.ToString());
                        requestOneByOne.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    }

                    // context clone to new request
                    //var context = Context.Clone();
                    //requestOneByOne.Properties.Add(Constants.PROPERTIES_KEY_CONTEXT, context);

                    tasks[i] = Task.Factory.StartNew(() =>
                    {
                        CallContext.LogicalSetData("ContextEntity", new AgencyAppContext { TraceID = traceId });
                   
                        Task<HttpResponseMessage> response = base.SendAsync(requestOneByOne, cancellationToken);
                        SetResponseContentType(response.Result);
                        return response.Result.Content.ReadAsStringAsync().Result;
                    });
                }

                // chunked needs to improve. The most important for performance is not wait for all individual API responded until batch API return response
                // instead, it should return data whenever 1 of the list of API responded fromb biz server
                // test scenario could be 1 biz server turns 1 simple API in 100ms but another API returns complex logic in 10 seconds
                //var stream = await response.Content.ReadAsStreamAsync();
                //response.Content = new ChunkedEncodingHelper(stream);

                await Task.WhenAll(tasks);
                foreach (var t in tasks)
                {
                    responseBatchObject.Result.Add(JObject.Parse(t.Result));
                }

                string result = JsonConvert.SerializeObject(responseBatchObject);

                HttpResponseMessage responseMessage = request.CreateResponse(); 
                // change the Response Transfer Encoding to Chunked
                responseMessage.Content = new ChunkedStreamContent(new MemoryStream(Encoding.UTF8.GetBytes(result)));
                SetResponseContentType(responseMessage);
                //responseMessage.Headers.TransferEncodingChunked = true; // NOTE: this does not work with header

                return responseMessage;
            }
            catch (Exception ex)
            {
                errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Unknown server error, please contact administrator.", null, traceId);
                WriteLog(errorResponse,ex);
                return HttpResponseHelper.BuildErrorResponse(request, errorResponse, _context.TraceID);
            }
        }

        private void WriteLog(WSErrorResponse error, Exception exception = null)
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
                    Detail = String.Format("Respose: {0} \r\n Exception:{1}", more, exception == null ? String.Empty : exception.ToString()),
                    MethodName = "BatchRequestHandler"
                };

                if (error.Status == (int)HttpStatusCode.InternalServerError)
                {
                    Log.Error(logData);
                }
                else
                {
                    Log.Warn(logData);
                }
            }
        }

        private static bool isValidMethod(string method)
        {
            if(String.IsNullOrWhiteSpace(method))
            {
                return false;
            }
            string[] supportedMethods = new string[]{
                "POST",
                "GET",
                "PUT",
                "DELETE"
            };

            return supportedMethods.Contains(method.ToUpper());      
        }

        private static HttpMethod ConvertToHttpMethod(string method)
        {
            string m = method.ToUpper();
            HttpMethod r = HttpMethod.Get;
            switch(m)
            {
                case "GET":
                    break;
                case "POST":
                    r = HttpMethod.Post;
                    break;
                case "DELETE":
                    r = HttpMethod.Delete;
                    break;
                case "PUT":
                    r = HttpMethod.Put;
                    break;
                default:
                    throw new Exception("Invalid Http Method.");
            }

            return r;
        }

        private static void SetResponseContentType(HttpResponseMessage responseMessage)
        {
            if (responseMessage != null && responseMessage.Content != null && responseMessage.Content.Headers != null)
            {
                responseMessage.Content.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            }
        }
    }
}
