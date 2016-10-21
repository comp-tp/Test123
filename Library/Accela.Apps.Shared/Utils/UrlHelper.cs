using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Shared.Utils
{
    public static class UrlHelper
    {
        public static string UpdateQueryStringParameterInUrl(string url, string key, string newValue)
        {
            string result = url;

            if (!String.IsNullOrWhiteSpace(url) && !String.IsNullOrWhiteSpace(key))
            {
                try
                {
                    var questionMarkIndex = url.IndexOf("?");
                    var urlTrunk = questionMarkIndex != -1 ? url.Substring(0, questionMarkIndex) : url;
                    var queryString = questionMarkIndex != -1 && questionMarkIndex < (url.Length - 1) ? url.Substring(questionMarkIndex + 1) : String.Empty;
                    var queryStringItems = !String.IsNullOrWhiteSpace(queryString) ? HttpUtility.ParseQueryString(queryString) : null;

                    if (queryStringItems != null)
                    {
                        queryStringItems[key] = newValue;
                        queryString = queryStringItems.ToString();
                        result = String.Format("{0}?{1}", urlTrunk, queryString);
                    }
                }
                catch (UriFormatException ex)
                {
                    throw new MobileException("Error occurred when update query string parameter.", ex);
                }
            }

            return result;
        }

        public static string UpdateQueryStringParameter(string queryString, string key, string newValue)
        {
            string result = queryString;

            if (!String.IsNullOrWhiteSpace(queryString) && !String.IsNullOrWhiteSpace(key))
            {
                try
                {
                    var queryStringItems = !String.IsNullOrWhiteSpace(queryString) ? HttpUtility.ParseQueryString(queryString) : null;

                    if (queryStringItems != null)
                    {
                        queryStringItems[key] = newValue;
                        result = queryStringItems.ToString();
                    }
                }
                catch (UriFormatException ex)
                {
                    throw new MobileException("Error occurred when update query string parameter.", ex);
                }
            }

            return result;
        }

        /// <summary>
        /// return application full path.
        /// example: http://www.server.com/virtualDir/
        /// </summary>
        /// <returns></returns>
        public static string GetRequestApplicationFullPath()
        {
            var currentRequest = System.Web.HttpContext.Current.Request;
            var requestUrl = currentRequest.Url;
            var scheme = requestUrl.Scheme + "://";
            var host = requestUrl.Host;

            var port = string.Empty;
            if (!(requestUrl.Port == 80 || requestUrl.Port == 443))
            {
                port = ":" + requestUrl.Port;
            }

            var domainPart = scheme + host + port;
            var fullPath = CombinePath(domainPart, currentRequest.ApplicationPath);
            return fullPath;
        }

        /// <summary>
        /// combine serval paths into one valid Url.
        /// 
        /// examples:
        /// a. 
        /// input: http://www.server.com/, /dir1/dir2, /fileName
        /// output: http://www.server.com/dir1/dir2/fileName
        /// 
        /// b. 
        /// input: dir1/dir2, dir3/
        /// oupput: dir1/dir2/dir3/
        /// </summary>
        /// <param name="paths">path array</param>
        /// <returns>combined Url</returns>
        public static string CombinePath(params string[] paths)
        {
            if (paths == null || paths.Length == 0)
            {
                return String.Empty;
            }

            var fixedPaths = paths.Where(p => !String.IsNullOrWhiteSpace(p)).ToArray();
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < fixedPaths.Length; i++)
            {
                var path = fixedPaths[i];
                if (!String.IsNullOrWhiteSpace(path))
                {
                    var fixedPath = i > 0 && !path.StartsWith("/") ? "/" + path : path;
                    fixedPath = i < (fixedPaths.Length - 1) ? fixedPath.TrimEnd('/') : fixedPath;
                    stringBuilder.Append(fixedPath);
                }
            }

            var result = stringBuilder.ToString();
            return result;
        }

        /// <summary>
        /// get trunk of Uri template.
        /// for example:
        /// input: apis/v2/records/search?recordId={0}
        /// output: /apis/v2/records/search/
        /// </summary>
        /// <param name="rawUriTemplate"></param>
        /// <returns></returns>
        public static string GetTrunkOfUriTemplate(string rawUriTemplate)
        {
            string result = String.Empty;

            if (!String.IsNullOrWhiteSpace(rawUriTemplate))
            {
                var questionMarkIndex = rawUriTemplate.IndexOf("?");
                var subStringLength = questionMarkIndex != -1 ? questionMarkIndex : rawUriTemplate.Length;
                result = rawUriTemplate.Substring(0, subStringLength);
                result = FormatUriTemplatePath(result);
            }

            return result;
        }

        public static NameValueCollection TrimValueSpaces(NameValueCollection collection, string[] exceptionKeys = null)
        {
            NameValueCollection result = null;
            if (collection != null)
            {
                result = HttpUtility.ParseQueryString(String.Empty);
                foreach (string key in collection.Keys)
                {
                    var value = collection[key];

                    if (exceptionKeys != null
                        && exceptionKeys.Length > 0
                        && exceptionKeys.Contains(key, StringComparer.OrdinalIgnoreCase))
                    {
                        result[key] = value;
                    }
                    else
                    {
                        result[key] = (value ?? String.Empty).Trim();
                    }
                }
            }
            return result;
        }

        public static string GetContent(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    HttpWebRequest request = null;
                    if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                    {
                        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => { return true; });
                        request = WebRequest.Create(url) as HttpWebRequest;
                        request.ProtocolVersion = HttpVersion.Version10;
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    request.Method = "GET";
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    int statusCode = (int)response.StatusCode;
                    if (statusCode >= 100 && statusCode < 400)
                    {
                        Stream responseStream = response.GetResponseStream();
                        StreamReader sReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        StringBuilder content = new StringBuilder();
                        Char[] sReaderBuffer = new Char[256];
                        int count = sReader.Read(sReaderBuffer, 0, 256);
                        while (count > 0)
                        {
                            String tempStr = new String(sReaderBuffer, 0, count);
                            content.Append(tempStr);
                            count = sReader.Read(sReaderBuffer, 0, 256);
                        }
                        sReader.Close();
                        return content.ToString();
                    }
                }
                catch { }
            }
            return string.Empty;
        }

        private static string FormatUriTemplatePath(string uriTemplatePath)
        {
            string result = uriTemplatePath;

            if (!String.IsNullOrWhiteSpace(result))
            {
                if (!result.StartsWith("/"))
                {
                    result = "/" + result;
                }

                if (!result.EndsWith("/"))
                {
                    result = result + "/";
                }
            }

            return result;
        }
    }
}
