using Accela.Apps.Apis.Models.DomainModels.AsyncRequestModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Accela.Apps.Apis.Services.Handlers.Helpers
{
    public static class AsyncHttpMessageExtensions
    {
        public static HttpResponseMessage ToHttpResponseMessage(this AsyncHttpResponseMessage asyncHttpResposeMessage, HttpRequestMessage request)
        {
            HttpResponseMessage responseMessage = request.CreateResponse();
            responseMessage.StatusCode = asyncHttpResposeMessage.StatusCode;


            foreach (var h in asyncHttpResposeMessage.Headers)
            {
                responseMessage.Headers.TryAddWithoutValidation(h.Key, h.Value);
            }

            responseMessage.Content = new StreamContent(asyncHttpResposeMessage.Content);
            if (responseMessage.Content != null && !String.IsNullOrWhiteSpace(asyncHttpResposeMessage.ContentType_MediaType))
            {
                responseMessage.Content.Headers.ContentType = new global::System.Net.Http.Headers.MediaTypeHeaderValue(asyncHttpResposeMessage.ContentType_MediaType);
            }

            return responseMessage;
        }


        public static AsyncHttpRequestMessage ToAsyncHttpRequestMessage(this HttpRequestMessage httpRequestMessage)
        {
            AsyncHttpRequestMessage clone = new AsyncHttpRequestMessage();
            clone.HttpMethod = httpRequestMessage.Method.ToString();
            clone.Url = httpRequestMessage.RequestUri.ToString();
            //clone.Version = req.Version;

            if (httpRequestMessage.Content != null)
            {
                clone.Content = ConvertToStreamContent(httpRequestMessage.Content);
                if(httpRequestMessage.Content.Headers.ContentType != null)
                {
                    if (!String.IsNullOrWhiteSpace(httpRequestMessage.Content.Headers.ContentType.MediaType))
                    {
                        clone.ContentType_MediaType = httpRequestMessage.Content.Headers.ContentType.MediaType;
                    }

                    if (httpRequestMessage.Content.Headers.ContentType.Parameters != null
                        && httpRequestMessage.Content.Headers.ContentType.Parameters.Count > 0)
                    {
                        clone.ContentType_Parameters = new Dictionary<string, string>();

                        foreach (var item in httpRequestMessage.Content.Headers.ContentType.Parameters)
                        {
                            clone.ContentType_Parameters.Add(item.Name, item.Value);
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(httpRequestMessage.Content.Headers.ContentType.CharSet))
                    {
                        clone.ContentType_CharSet = httpRequestMessage.Content.Headers.ContentType.CharSet;
                    }
                }
            }

            //foreach (KeyValuePair<string, object> prop in req.Properties)
            //{
            //    clone.Properties.Add(prop);
            //}

            foreach (KeyValuePair<string, IEnumerable<string>> header in httpRequestMessage.Headers)
            {
                clone.Headers.Add(header.Key, header.Value.FirstOrDefault());
            }

            return clone;
        }

        public static AsyncHttpResponseMessage ToAsyncHttpResponseMessage(this HttpResponseMessage httpResponseMessage)
        {
            AsyncHttpResponseMessage clone = new AsyncHttpResponseMessage();

            if (httpResponseMessage.Content != null)
            {
                clone.Content = ConvertToStreamContent(httpResponseMessage.Content);
                clone.ContentType_MediaType = httpResponseMessage.Content.Headers.ContentType == null ? null : httpResponseMessage.Content.Headers.ContentType.MediaType;
            }

            //clone.Version = res.Version;
            clone.ReasonPhrase = httpResponseMessage.ReasonPhrase;
            clone.StatusCode = httpResponseMessage.StatusCode;
            //clone.RequestMessage = res.RequestMessage;

            foreach (KeyValuePair<string, IEnumerable<string>> header in httpResponseMessage.Headers)
            {
                clone.Headers.Add(header.Key, header.Value.FirstOrDefault());
                //clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        public static HttpMethod ToHttpMethod(this string method)
        {
            HttpMethod result = HttpMethod.Get;

            if (HttpMethod.Get.ToString().Equals(method, StringComparison.OrdinalIgnoreCase))
            {
                result = HttpMethod.Get;
            }
            else if (HttpMethod.Post.ToString().Equals(method, StringComparison.OrdinalIgnoreCase))
            {
                result = HttpMethod.Post;
            }
            else if (HttpMethod.Put.ToString().Equals(method, StringComparison.OrdinalIgnoreCase))
            {
                result = HttpMethod.Put;
            }
            else if (HttpMethod.Delete.ToString().Equals(method, StringComparison.OrdinalIgnoreCase))
            {
                result = HttpMethod.Delete;
            }
            //else if (HttpMethod.Head.ToString().Equals(method, StringComparison.OrdinalIgnoreCase))
            //{
            //    result = HttpMethod.Head;
            //}
            else
            {
                throw new Exception(String.Format("Invalid Http Method {0}.", method));
            }

            return result;
        }

        private static Stream ConvertToStreamContent(HttpContent originalContent)
        {
            if (originalContent == null)
            {
                return null;
            }

            StreamContent streamContent = originalContent as StreamContent;
            MemoryStream ms = new MemoryStream();

            originalContent.CopyToAsync(ms).Wait();

            // Reset the stream position back to 0 as in the previous CopyToAsync() call,
            // a formatter for example, could have made the position to be at the end
            ms.Position = 0;

            //streamContent = new StreamContent(ms);
            return ms;
        }
    }
}
