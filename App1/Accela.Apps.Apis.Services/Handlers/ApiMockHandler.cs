using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Apps.Shared.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.APIHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiMockHandler : DelegatingHandler
    {
        private IResourceBusinessEntity _resourceBusinessEntity { get { return IocContainer.Resolve<IResourceBusinessEntity>(); } }
        private IAgencyAppContext _context = new UnKownAgencyAppContext();

        /// <summary>
        /// Constructor.
        /// </summary>
        public ApiMockHandler()
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
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
            try
            {
                HttpMessage message = new HttpMessage(request);
                string httpMethod = message.GetHttpMethod();
                string requestAbsoluteUrl = message.GetAPIRelativePath();
                var resourceModel = _resourceBusinessEntity.GetResource(requestAbsoluteUrl, httpMethod);
                WSErrorResponse errorResponse = null;

                // check API definition
                if (resourceModel == null)
                {
                    errorResponse = ErrorResponses.GetAPINotFoundResponse(request, _context.TraceID);

                    return HttpResponseHelper.SendAsync(request, errorResponse, _context.TraceID);
                }
                
                var enableMock = !string.IsNullOrEmpty(message.GetHeaderValue("x-accela-enablemock")) && message.GetHeaderValue("x-accela-enablemock").ToLowerInvariant() == "true";
                if (!enableMock)
                {
                    // Routing to web api other handler. 
                    return base.SendAsync(request, cancellationToken);                        
                }                     

                string mockData = DownloadMockFile(httpMethod,resourceModel.Api);
                var responseMessage = new Task<HttpResponseMessage>(() =>
                {
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(mockData, Encoding.UTF8, "application/json"),
                        StatusCode = HttpStatusCode.OK
                    };
                }, cancellationToken);
                responseMessage.Start();

                return responseMessage;             
                
            }
            catch (Exception ex)
            {
                Log.Critical("Error happen in ApiMockHandler", ex.TraceInformation(), "ApiMockHandler.SendAsync()");
                var errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, ex.ToString(), null, _context.TraceID);

                return HttpResponseHelper.SendAsync(request, errorResponse, _context.TraceID);
            }
        }

        private static string GetBlobName(string method, string url)
        {            
            string blobName = method + url.Replace("/","_").Replace("{","").Replace("}","") + ".json";
            return blobName.ToLowerInvariant();
        }

        private static string DownloadMockFile(string method, string url)
        {
            string blobName = GetBlobName(method, url);

            //BlobHelper blobHelper = new BlobHelper("Api_StorageConnectionString");            
            //var isMockFileExist = blobHelper.CheckBlobExist(container, blobName);
            //if (!isMockFileExist)
            //{
            //    throw new Exception("Cannot find mock data.");
            //}

            //var fileStream = blobHelper.DownloadFromStream(container, blobName, true);
            //if (fileStream != null && fileStream.Length > 0)
            //{
            //    using (StreamReader sr = new StreamReader(fileStream))
            //    {
            //        return sr.ReadToEnd();
            //    }
            //}
            return string.Empty;
        }
    }
}
