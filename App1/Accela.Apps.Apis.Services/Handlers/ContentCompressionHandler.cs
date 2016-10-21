using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Accela.Apps.Shared.APIHandlers;
using System.Net;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using System.Web;
using System.IO;
using System.Net.Http.Headers;
using System.IO.Compression;
using System.Web.Routing;
using System.Diagnostics;
using Accela.Core.Logging;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Shared.Contexts;
using System.Runtime.Remoting.Messaging;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.APIHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class ContentCompressionHandler : DelegatingHandler
    {

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
        /// ContentCompressionHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
            try
            {
                var acceptEncoding = request.Headers.AcceptEncoding;
                
                return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((responseToCompleteTask) =>
                {
                    HttpResponseMessage response = responseToCompleteTask.Result;

                    if (acceptEncoding != null && acceptEncoding.Count > 0)
                    {
                        string encodingType = null;
                        foreach (var item in acceptEncoding)
                        {
                            if ("gzip".Equals(item.Value, StringComparison.OrdinalIgnoreCase))
                            {
                                encodingType = "gzip";
                                break;
                            }
                            else if ("deflate".Equals(item.Value, StringComparison.OrdinalIgnoreCase))
                            {
                                encodingType = "deflate";
                                break;
                            }
                        }

                        if (encodingType != null)
                        {
                            response.Content = new CompressedContent(response.Content, encodingType);
                        }
                    }
                    
                    return response;
                },
                TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            catch (Exception ex)
            {
                Log.Critical("Error happen in ContentCompressionHandler", ex.TraceInformation(), "ContentCompressionHandler.SendAsync()");
                var errorResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Unknown server error, please contact administrator.", null, _context.TraceID);

                return HttpResponseHelper.SendAsync(request, errorResponse, _context.TraceID);
            }
        }
    }

    /// <summary>
    /// CompressedContent
    /// </summary>
    public class CompressedContent : HttpContent
    {
        private HttpContent originalContent;
        private string encodingType;

        public CompressedContent(HttpContent content, string encodingType)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (encodingType == null)
            {
                throw new ArgumentNullException("encodingType");
            }

            originalContent = content;
            this.encodingType = encodingType.ToLowerInvariant();

            if (this.encodingType != "gzip" && this.encodingType != "deflate")
            {
                throw new InvalidOperationException(string.Format("Encoding '{0}' is not supported. Only supports gzip or deflate encoding.", this.encodingType));
            }

            // copy the headers from the original content
            foreach (KeyValuePair<string, IEnumerable<string>> header in originalContent.Headers)
            {
                this.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            this.Headers.ContentEncoding.Clear();
            this.Headers.ContentEncoding.Add(encodingType);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;

            return false;
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            Stream compressedStream = null;

            if (encodingType == "gzip")
            {
                compressedStream = new GZipStream(stream, CompressionMode.Compress, leaveOpen: true);
            }
            else if (encodingType == "deflate")
            {
                compressedStream = new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true);
            }

            return originalContent.CopyToAsync(compressedStream).ContinueWith(tsk =>
            {
                if (compressedStream != null)
                {
                    compressedStream.Dispose();
                }
            });
        }
    }
}
