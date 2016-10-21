using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using Accela.Apps.Shared.WSModels;
using System.Net.Http.Formatting;
using System.Net;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.APIHandlers
{
    public class HttpResponseHelper
    {
        public static Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, WSErrorResponse response, string traceId)
        {
            return Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                return BuildErrorResponse(request, response, traceId);
            });
        }

        public static HttpResponseMessage BuildErrorResponse(HttpRequestMessage request, WSErrorResponse response, string traceId)
        {
            HttpStatusCode httpStatus = ConvertToStatusCode(response.Status);

            var responseMessage = request.CreateResponse(httpStatus);

            responseMessage.Content = new ObjectContent(typeof(WSErrorResponse), response, new JsonMediaTypeFormatter());
            if (String.IsNullOrEmpty(response.TraceId))
            {
                response.TraceId = traceId;
            }

            responseMessage.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_TraceId, response.TraceId);
            responseMessage.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_Error_Code, response.Code);
            responseMessage.AddHeaderKey(ResponseHeaderConstants.X_Accela_Header_Error_Message, response.Message);

            return responseMessage;
        }

        private static HttpStatusCode ConvertToStatusCode(int status)
        {
            HttpStatusCode result;
            bool isSuccess = Enum.TryParse<HttpStatusCode>(status.ToString(),out result);

            if (!isSuccess)
            {
                result = HttpStatusCode.InternalServerError;
            }

            return result;
        }

        public static string RemoveInvalidNewLine(string headerValue)
        {
            if (String.IsNullOrEmpty(headerValue))
            {
                return headerValue;
            }
            else
            {
                return headerValue.Replace("\r\n", "");
            }
        }
    }
}
