using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Accela.Apps.Shared.Utils
{
    public class NetHelper
    {
        /// <summary>
        /// Does the web request with get method.
        /// </summary>
        /// <param name="url">The web request get URL.</param>
        /// <returns>the web response</returns>
        public static string DoWebRequestGet(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string responseFromServer = streamReader.ReadToEnd();
            webResponse.Close();
            responseStream.Close();
            streamReader.Close();
            return responseFromServer;
        }

        /// <summary>
        /// Does the web request form post.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>the web response</returns>
        public static string DoWebRequestFormPost(string url, string queryString)
        {
            WebRequest webRequest = WebRequest.Create(url);
            
            webRequest.Method = WebRequestMethods.Http.Post;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            var contentData = !String.IsNullOrEmpty(queryString) ? Encoding.UTF8.GetBytes(queryString) : null;
            webRequest.ContentLength = contentData != null ? queryString.Length : 0;
            var requestStream = webRequest.GetRequestStream();
            requestStream.Write(contentData, 0, contentData.Length);
            requestStream.Close();

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string responseFromServer = streamReader.ReadToEnd();
            webResponse.Close();
            responseStream.Close();
            streamReader.Close();
            return responseFromServer;
        }
    }
}
