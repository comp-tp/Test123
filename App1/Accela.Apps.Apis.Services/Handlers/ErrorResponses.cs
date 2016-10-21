using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Shared.WSModels;
using System.Net;
using Accela.Apps.Shared.Exceptions;
using System.Net.Http;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.APIHandlers
{
    public static class ErrorResponses
    {
        public static WSErrorResponse GetAPINotFoundResponse(HttpRequestMessage request, string traceId)
        {
            HttpMessage message = new HttpMessage(request);
            string httpMethod = message.GetHttpMethod();
            var errorResponse = new WSErrorResponse(
            HttpStatusCode.NotFound,
            ErrorCodes.api_not_found_404,
            "The requested api is not found.",
            String.Format("The requested api {0} {1} is not defined on the server.", request.Method, message.GetRequestUri()), traceId);
            return errorResponse;
        }
    }
}
