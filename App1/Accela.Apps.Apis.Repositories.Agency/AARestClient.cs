using System.IO;
using Accela.Apps.Apis.Repositories.Agency.AARESTModels;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Core.Logging;
using Accela.Automation.CitizenServices.Client;
using RestSharp;
using System;
using System.Net;
using System.Text;

namespace Accela.Apps.Apis.Repositories.Agency
{
    [Obsolete]
    public class AARestClient
    {
        private const string APPLICATION_JSON = "application/json";
        private const string APPLICATION_OCTETSTREAM = "application/octet-stream";
        private string _agencyName;
        private string _environmentName;

        public AARestClient(string agencyName, string environmentName)
        {
            _agencyName = agencyName;
            _environmentName = environmentName;
        }

        public string Execute(string resource,bool resourceIncludeUriRoot = false)
        {
            string restUri = null;
            APIRestClient client = CreateClientInstance(resource, out restUri, resourceIncludeUriRoot);
            var result = client.Execute(restUri);
            return result;
        }

        public Stream DownloadStream(string resource)
        {
            string restUri = null;
            var client = CreateClientInstance(resource, out restUri, true);
            return client.DownloadStream(restUri);
        }

        public T Execute<T>(string resource) where T : class, new()
        {
            string restUri = null;
            APIRestClient client = CreateClientInstance(resource, out restUri);
            T result = client.Execute<T>(restUri);

            CheckError(result);

            return result;
        }

        public T ExecuteV4<T>(string resource) where T : class, new()
        {
            string restUri = null;
            var client = CreateClientInstance(resource, out restUri, true);
            var result = client.Execute<T>(restUri);
            CheckError(result);
            return result;
        }

        private static void CheckError<T>(T result)
        {
            AAResponseBase error = result as AAResponseBase;
            
            if (error != null)
            {
                if (error.status > 300)
                {
                    if (error.status == 403)
                    {
                        throw new ForbiddenException(error.message, String.Empty, error.code.ToString());
                    }
                    else
                    {
                        throw new MobileException(error.message, String.Empty, error.code.ToString());
                    }
                }
            }
            else
            {
                RestResponse tmpContent = result as RestResponse;
                if (tmpContent == null) return;
                /*
                 * Prior to AA 731, 
                 * (1) AA REST API will return 200 OK even though there is any error.
                 * (2) Content-Type will be set to application/octet-stream even though it is of type JSON.
                 * (3) If the report is generated successfully, Content-Type will be the correct format string.
                //*/
                if (String.IsNullOrEmpty(tmpContent.Content)) return;
                if (! APPLICATION_JSON.Equals(tmpContent.ContentType, StringComparison.InvariantCultureIgnoreCase)
                    && !APPLICATION_OCTETSTREAM.Equals(tmpContent.ContentType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
                V4BizResponseBase tmpResult = JsonConverter.FromJsonTo<V4BizResponseBase>(tmpContent.Content);
                if (tmpResult == null) return;
                if (tmpResult.status > 300)
                {
                    if (tmpResult.status == 403)
                    {
                        throw new ForbiddenException(tmpResult.message, String.Empty, tmpResult.code.ToString());
                    }
                    else
                    {
                        throw new MobileException(tmpResult.message, String.Empty, tmpResult.code.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// PUT/UPDATE/DELETE resource.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">relative url(etc 'users/search?name=abc'),not include base url.</param>
        /// <param name="requestPostBody"></param>
        /// <returns></returns>
        public T Execute<T>(string resource, object requestPostBody, Method method = Method.POST, string httpHeaderContentType = APPLICATION_JSON, string httpHeaderAccept = "") where T : class, new()
        {
            RestSharp.Method requestMethod = RestSharp.Method.POST;
            if (method == Method.POST)
            {
                requestMethod = RestSharp.Method.POST;
            }
            else if (method == Method.PUT)
            {
                requestMethod = RestSharp.Method.PUT;
            }
            else if (method == Method.DELETE)
            {
                requestMethod = RestSharp.Method.DELETE;
            }
            else
            {
                throw new Exception(MobileResources.GetString("http_request_method_invalid"));
            }
            string restUri = null;
            APIRestClient client = CreateClientInstance(resource, out restUri);

            T result = client.Execute<T>(restUri, requestPostBody, requestMethod, httpHeaderContentType, httpHeaderAccept);

            CheckError(result);

            return result;
        }

        /// <summary>
        /// Create a APIRestClient instance.
        /// </summary>
        /// <param name="resource">relative url(etc 'users/search?name=abc'),to include base url or not, please set resourceIncludeUriRoot.</param>
        /// <param name="resourceIncludeUriRoot">indicate if resource includes Uri root, by default is false.</param>
        /// <returns></returns>
        private APIRestClient CreateClientInstance(string resource, out string restUri, bool resourceIncludeUriRoot = false)
        {
            if (String.IsNullOrWhiteSpace(resource))
            {
                string error = MobileResources.GetString("invalid_resource_uri");
                Log.Error(error, "", "CreateClientInstance()");

                throw new MobileException(error);
            }

            APIRestClient restClient = new APIRestClient();

            IAgencyRepository agencyRepository = IocContainer.Resolve<IAgencyRepository>();
            var hostInfo = agencyRepository.GetHost(_agencyName);

            if (hostInfo == null)
            {
                string error = String.Format(MobileResources.GetString("agency_no_exist"), _agencyName);
                throw new MobileException(error);
            }

            if (hostInfo.Environments == null)
            {
                string error = String.Format(MobileResources.GetString("environment_name_no_exist"), _environmentName);
                throw new MobileException(error);
            }

            var hostEnvironment = hostInfo.Environments.Find(item => !String.IsNullOrWhiteSpace(item.Name) && item.Name.Equals(_environmentName, StringComparison.OrdinalIgnoreCase));

            if (hostEnvironment == null)
            {
                string error = String.Format(MobileResources.GetString("environment_name_no_exist"), _environmentName);
                throw new MobileException(error);
            }

            var isEnviromentEnabled = hostEnvironment.Status;
            if (!isEnviromentEnabled)
            {
                string error = String.Format(MobileResources.GetString("environment_name_no_exist"), _environmentName);
                Log.Error(error, "", "CreateClientInstance()");
                throw new MobileException(error);
            }

            // Automatically append 'proxy.aspx' to GatewayUrl(real url for proxy)
            if (!String.IsNullOrEmpty(hostEnvironment.GatewayUrl))
            {
                var gatewayVersion = string.IsNullOrEmpty(hostEnvironment.GatewayVersion) ? new Version() : new Version(hostEnvironment.GatewayVersion);
                string gatewayApi = "proxy.aspx";
                if (gatewayVersion >= new Version(3, 2, 0))
                {
                    if (resource.StartsWith("apis"))
                    {
                        gatewayApi = "";
                    }
                    else
                    {
                        gatewayApi = "apis";
                    }
                }

                if (!hostEnvironment.GatewayUrl.EndsWith(gatewayApi, StringComparison.InvariantCultureIgnoreCase))
                {
                    StringBuilder sb = new StringBuilder(hostEnvironment.GatewayUrl);
                    if (!hostEnvironment.GatewayUrl.EndsWith("/"))
                    {
                        hostEnvironment.GatewayUrl = sb.Append("/").ToString();
                    }
                    sb = new StringBuilder(hostEnvironment.GatewayUrl);
                    hostEnvironment.GatewayUrl = sb.Append(gatewayApi).ToString();
                }
            }

            restClient.GatewayUrl = hostEnvironment.GatewayUrl;
            restClient.AccessKey = hostEnvironment.GatewayKey;

            restClient.Environment = hostEnvironment.Name;
            restClient.Agency = this._agencyName;

            //restUri = hostEnvironment.BizServerURL;

            restUri = String.Empty;

            if (hostEnvironment.BizServers != null
                && hostEnvironment.BizServers.Count > 0)
            {
                if (hostEnvironment.BizServers.Count > 1)
                {
                    int selectedUrlIndex = GetRandomNumber(100) % hostEnvironment.BizServers.Count;

                    restUri = hostEnvironment.BizServers[selectedUrlIndex].Url;
                }
                else
                {
                    restUri = hostEnvironment.BizServers[0].Url;
                }
            }

            if (String.IsNullOrWhiteSpace(restUri))
            {
                //throw new MobileException(MobileResources.GetString("gateway_not_set"));
                if (!restClient.GatewayUrl.EndsWith("/"))
                {
                    restClient.GatewayUrl += "/";
                }

                if (resource.StartsWith("/"))
                {
                    resource = resource.Remove(0, 1);
                }

                if (resourceIncludeUriRoot)
                {
                    restClient.GatewayUrl = String.Format("{0}{1}", restClient.GatewayUrl, resource);
                }
                else
                {
                    restClient.GatewayUrl = String.Format("{0}v1/{1}", restClient.GatewayUrl, resource);
                }

            }
            else
            {

                if (!restUri.EndsWith("/"))
                {
                    restUri += "/";
                }

                if (resource.StartsWith("/"))
                {
                    resource = resource.Remove(0, 1);
                }

                if (resourceIncludeUriRoot)
                {
                    restUri = String.Format("{0}{1}", restUri, resource);
                }
                else
                {
                    restUri = String.Format("{0}apis/v1/{1}", restUri, resource);
                }
            }

            return restClient;
        }

        private int GetRandomNumber(int maxNumber)
        {
            if (maxNumber < 1)
                throw new System.Exception(MobileResources.GetString("get_randomnumber_parameter_value_range"));

            byte[] b = new byte[4];

            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);

            int seed = (b[0] & 0x7f) << 24 | b[1] << 16 | b[2] << 8 | b[3];

            System.Random r = new System.Random(seed);

            return r.Next(0, maxNumber);
        }

        //private string BuildRestUri(string bizUrl, string resource)
        //{
        //    if (bizUrl.EndsWith("/"))
        //    {
        //        bizUrl = bizUrl.Substring(0, bizUrl.Length - 1);
        //    }

        //    if (resource.EndsWith("/"))
        //    {
        //        resource = resource.Substring(0, resource.Length - 1);
        //    }

        //    string restUrl = string.Format("{0}/rest/{1}", bizUrl, resource);
        //    return restUrl;
        //}

        private static ILog Log
        {
            get
            {
                return LogFactory.GetLog();
            }
        }

        public enum Method
        {
            GET = 0,
            POST = 1,
            PUT = 2,
            DELETE = 3
        }
    }
}
