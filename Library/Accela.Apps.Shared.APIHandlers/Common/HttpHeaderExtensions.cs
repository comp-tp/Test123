using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Accela.Apps.Shared.APIHandlers
{
    public static class HttpHeaderExtensions
    {
        public static void CopyTo(this HttpRequestHeaders from, HttpRequestHeaders to)
        {
            foreach (var header in from)
            {
                to.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        public static void CopyHeadersTo(this HttpRequestMessage from, HttpRequestMessage to)
        {
            from.Headers.CopyTo(to.Headers);
        }

        public static void AddHeaderKey(this HttpRequestMessage requestMessage, string key, string value, bool overrideIfExist = true)
        {
            if(String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }

            if (overrideIfExist)
            {
                requestMessage.Headers.Remove(key);
            }

            requestMessage.Headers.TryAddWithoutValidation(key, HttpResponseHelper.RemoveInvalidNewLine(value));
        }

        public static void AddHeaderKey(this HttpResponseMessage responseMessage, string key, string value, bool overrideIfExist = true)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }

            if (overrideIfExist)
            {
                responseMessage.Headers.Remove(key);
            }
            
            responseMessage.Headers.TryAddWithoutValidation(key, HttpResponseHelper.RemoveInvalidNewLine(value));
        }


        public static void CopyTo(this HttpContentHeaders from, HttpContentHeaders to)
        {
            foreach (var header in from)
            {
                to.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        public static void CopyHeadersTo(this HttpContent from, HttpContent to)
        {
            from.Headers.CopyTo(to.Headers);
        }

        public static void CopyTo(this HttpResponseHeaders from, HttpResponseHeaders to)
        {
            foreach (var header in from)
            {
                to.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        public static void CopyHeadersTo(this HttpResponseMessage from, HttpResponseMessage to)
        {
            from.Headers.CopyTo(to.Headers);
        }
    }
}
