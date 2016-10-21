using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.Utils
{
    public static class RestsharpLogBuilder
    {
        public static string BuildRequestLog(IRestRequest request)
        {
            if (request == null || request.Parameters == null)
            {
                return null;
            }

            var builder = new StringBuilder();

            // build URI
            builder.Append("Request Uri:");
            builder.Append("\r\n");
            var httpMethod = request.Method.ToString();
            builder.AppendFormat("{0} {1}", httpMethod, request.Resource);
            builder.Append("\r\n\r\n");

            // build headers
            builder.Append("Request Headers:");
            builder.Append("\r\n");
            var headerList = request.Parameters
                            .Where(p => p.Type == ParameterType.HttpHeader)
                            .Select(p => String.Format("{0} = {1}", p.Name, p.Value))
                            .ToArray();
            var requestHeadersString = headerList != null ? String.Join("\r\n", headerList) : null;
            builder.Append(requestHeadersString);
            builder.Append("\r\n\r\n");

            // build body
            if ("post".Equals(httpMethod, StringComparison.OrdinalIgnoreCase))
            {
                builder.Append("Request Body:");
                builder.Append("\r\n");
                var bodyParameters = request.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();
                var bodyString = bodyParameters != null && bodyParameters.Value != null ? bodyParameters.Value.ToString() : String.Empty;

                if (String.IsNullOrWhiteSpace(bodyString))
                {
                    var bodyParameterArray = request.Parameters.Where(p => p.Type == ParameterType.GetOrPost).Select(p => String.Format("{0} = {1}", p.Name, p.Value)).ToArray();
                    bodyString = String.Join("\r\n", bodyParameterArray);
                }

                builder.Append(bodyString);
                builder.Append("\r\n\r\n");
            }
            builder.Append("\r\n\r\n");

            // get builder string
            var result = builder.ToString();
            return result;
        }

        public static string BuildResponseLog(IRestResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var builder = new StringBuilder();

            // build URI
            builder.Append("Response Uri:");
            builder.Append("\r\n");
            builder.Append(response.ResponseUri != null ? response.ResponseUri.ToString() : null);
            builder.Append("\r\n\r\n");

            // build http status
            builder.Append("Response HTTP status:");
            builder.Append("\r\n");
            builder.AppendFormat("{0} ({1})", (int)response.StatusCode, response.StatusCode.ToString());
            builder.Append("\r\n\r\n");

            // build headers
            builder.Append("Response Headers:");
            builder.Append("\r\n");
            var headerList = response.Headers
                            .Select(p => String.Format("{0} = {1}", p.Name, p.Value))
                            .ToArray();
            var responseHeadersString = headerList != null ? String.Join("\r\n", headerList) : null;
            builder.Append(responseHeadersString);
            builder.Append("\r\n\r\n");

            // build body
            builder.Append("Response Body:");
            builder.Append("\r\n");
            builder.Append(response.Content);
            builder.Append("\r\n\r\n");
            builder.Append("\r\n\r\n");

            // get builder string
            var result = builder.ToString();

            return result;
        }

        public static string BuildRequestAndResponseLog(IRestRequest request, IRestResponse response)
        {
            var requestString = BuildRequestLog(request);
            var responseString = BuildResponseLog(response);
            var builder = new StringBuilder();
            builder.Append(requestString);
            builder.Append(responseString);
            var result = builder.ToString();
            return result;
        }
    }
}
