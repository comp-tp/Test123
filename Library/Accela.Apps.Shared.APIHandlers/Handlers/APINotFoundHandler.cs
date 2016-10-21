using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.Shared.Exceptions;
using System.Threading;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Shared.APIHandlers
{
    public class APINotFoundHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpMessage message = new HttpMessage(request);
            string url = message.GetRequestUri();
            string traceId = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_TraceId);
            var errorResponse = new WSErrorResponse(
             HttpStatusCode.NotFound,
             ErrorCodes.not_found_404,
             "The requested resource is not found.",
             String.Format("The requested resource {0} {1} does not exist on the server.", request.Method, url),
             null);

            return HttpResponseHelper.SendAsync(request, errorResponse, traceId);
        }
    }
}
