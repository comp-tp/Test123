using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Web;
using Accela.Core.Logging;
using System.ServiceModel.Channels;

namespace Accela.Apps.Shared.APIHandlers
{
    public class HttpMessage
    {
        private HttpRequestMessage _message;

        public HttpMessage(HttpRequestMessage request)
        {
            _message = request;
        }

        public string GetHeaderValue(string headerKey)
        {
            string result = String.Empty;
            if (_message.Headers.Contains(headerKey))
            {
                result = _message.Headers.GetValues(headerKey).ToArray()[0];
            }

            return result;
        }

        public string GetQueryString(string key)
        {
            var queryStrings = _message.RequestUri.ParseQueryString();
            return queryStrings[key];
        }
        string _traceId = null;

        public string GetTraceId()
        {
            if (String.IsNullOrEmpty(_traceId))
            {
                _traceId = GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_TraceId);
                if (String.IsNullOrWhiteSpace(_traceId) && !_message.Headers.Contains(ResponseHeaderConstants.X_Accela_Header_TraceId))
                {
                    _traceId = LogUtil.NewTraceID();
                    _message.Headers.Add(ResponseHeaderConstants.X_Accela_Header_TraceId, _traceId);
                }
            }

            return _traceId;
        }

        public string GetClientIP()
        {
            var httpContext = GetHttpContext();

            if(httpContext != null && httpContext.Request != null)
            {
                return httpContext.Request.UserHostAddress;
            }

            if (_message.Properties != null && _message.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)_message.Properties[RemoteEndpointMessageProperty.Name];
                if(prop != null)
                {
                    return prop.Address;
                }
            }

            return null;
        }

        public string GetClientLanguate()
        {
            var httpContext = GetHttpContext();

            if (httpContext != null && httpContext.Request != null && httpContext.Request.UserLanguages != null)
            {
                return httpContext.Request.UserLanguages.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string GetRequestUri()
        {
            return _message.RequestUri.ToString();
        }

        public string GetRequestUriTemplate()
        {
            return _message.GetRouteData().Route.RouteTemplate;
        }

        public string GetHttpMethod()
        {
            return _message.Method.ToString();
        }

        public string GetHttpHeader()
        {
            return _message.Headers.ToString().Replace("\r\n", "  ");
        }

        public string GetContentType()
        {
            var httpContext = GetHttpContext();

            if (httpContext != null && httpContext.Request != null)
            {
                return httpContext.Request.ContentType;
            }
            else
            {
                return null;
            } 
        }

        public int GetContentLength()
        {
            var httpContext = GetHttpContext();

            if (httpContext != null && httpContext.Request != null)
            {
                return httpContext.Request.ContentLength;
            }
            else
            {
                return 0;
            }   
        }
        public string GetLanguage()
        {
            return GetQueryString("lang");
        }

        public string GetAppID()
        {
            return GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_AppId);
        }

        public string GetAppSecretCode()
        {
            return GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_AppSecret);
        }

        public string GetEnvironment()
        {
            return GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Environment);
        }
		
        public string GetAppVer()
        {
            return GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_AppVersion);
        }

        public string GetToken()
        {
            return GetHeaderValue(ResponseHeaderConstants.X_Standard_Header_Authorization);
        }

        public string GetSubSystemCaller()
        {
            return GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_SubSystem_Caller);
        }

        protected string ApplicationVirtualPath { get; set; }
        /// <summary>
        /// Get application root url, like http://localhost/myapp.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationRootUrl()
        {
            var virturalPath = ApplicationVirtualPath == null ? System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath : ApplicationVirtualPath;

            if (virturalPath == null) return string.Empty;

            if (virturalPath.EndsWith("/"))
            {
                virturalPath = virturalPath.Remove(virturalPath.Length - 1);
            }

            if (virturalPath.StartsWith("/"))
            {
                virturalPath = virturalPath.Remove(0,1);
            }

            if(virturalPath == string.Empty)
            {
                return String.Format("{0}://{1}", _message.RequestUri.Scheme, _message.RequestUri.Authority);
            }
            else
            {
                return String.Format("{0}://{1}/{2}", _message.RequestUri.Scheme, _message.RequestUri.Authority, virturalPath);
            }
        }

        /// <summary>
        /// Get API relative path with query string, like /v4/records/{id}?filter=address
        /// </summary>
        /// <returns></returns>
        public string GetAPIRelativePath()
        {
            return _message.RequestUri == null ? String.Empty : _message.RequestUri.ToString().Remove(0, GetApplicationRootUrl().Length);
        }

        /// <summary>
        /// Get API relative path without query string, like /v4/records/{id}
        /// </summary>
        /// <returns></returns>
        public string GetAPIRelativePathWithoutQueryString()
        {
            var url = GetAPIRelativePath();

            if(String.IsNullOrEmpty(url))
            {
                return url;
            }

            int questionMarkPosition = url.IndexOf("?");

            if (questionMarkPosition > -1)
            {
                url = url.Substring(0, questionMarkPosition);
            }

            if (url.EndsWith("/"))
            {
                url = url.Remove(url.Length - 1);
            }

            return url;
        }

        private HttpContextBase GetHttpContext()
        {
            if(_message.Properties.ContainsKey("MS_HttpContext"))
            {
                return (HttpContextBase)_message.Properties["MS_HttpContext"];
            }
            else
            {
                return null;
            }
        }
    }
}
