
using System;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Core.Logging;
using Accela.Automation.CitizenServices.Client;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.Utils;
using Accela.Apps.User.WSModels.V2.Auth;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using System.Text;
using Accela.Infrastructure.Configurations;
using Accela.Core.Configurations;

namespace Accela.Apps.Apis.Repositories.Citizen
{
    public class RestClient
    {
        private string _agencyName;
        private string _environmentName;

        private IConfigurationReader configurationReader;


        public RestClient(string agencyName, string environmentName)
        {
            _agencyName = agencyName;
            _environmentName = environmentName;
            this.configurationReader = ConfigurationSettingsManager.Get();
        }

        public RestClient(string agencyName, string environmentName, IConfigurationReader configurationReader)
        {
            _agencyName = agencyName;
            _environmentName = environmentName;
            this.configurationReader = configurationReader;
        }

        /// <summary>
        /// Get resource thru http GET method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">relative url(etc 'users/search?name=abc'),not include base url.</param>
        /// <returns></returns>
        public T Execute<T>(string resource) where T : class, new()
        {
            string restUri = null;
            APIRestClient client = CreateClientInstance(resource, out restUri);
            T result = default(T);

            try
            {
                result = client.Execute<T>(restUri);
            }
            catch (UnauthorizedException ex)
            {
                Log.Error(ex.Message, ex.Detail, "Execute<T>(string resource)()");

                // try get token again.
                var newACAAnonymousToken = GetNewACAAnonymousToken();

                //update token in uri
                var restUriWithNewToken = UrlHelper.UpdateQueryStringParameterInUrl(restUri, "token", newACAAnonymousToken);

                // get result again (throw execption with no catching exception if exception occurs).
                result = client.Execute<T>(restUriWithNewToken);
            }

            return result;
        }

        /// <summary>
        /// PUT/UPDATE/DELETE resource.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">relative url(etc 'users/search?name=abc'),not include base url.</param>
        /// <param name="requestPostBody"></param>
        /// <returns></returns>
        public T Execute<T>(string resource, object requestPostBody, Method method = Method.POST) where T : class, new()
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

            T result = default(T);

            try
            {
                result = client.Execute<T>(restUri, requestPostBody, requestMethod);
            }
            catch (UnauthorizedException ex)
            {
                Log.Error(ex.Message, ex.Detail, "Execute<T>(string resource)()");

                // try get token again.
                var newACAAnonymousToken = GetNewACAAnonymousToken();

                //update token in uri
                var restUriWithNewToken = UrlHelper.UpdateQueryStringParameterInUrl(restUri, "token", newACAAnonymousToken);

                // get result again (throw execption with no catching exception if exception occurs).
                result = client.Execute<T>(restUriWithNewToken, requestPostBody, requestMethod);
            }

            return result;
        }

        /// <summary>
        /// Create a APIRestClient instance.
        /// </summary>
        /// <param name="resource">relative url(etc 'users/search?name=abc'),not include base url.</param>
        /// <returns></returns>
        private APIRestClient CreateClientInstance(string resource, out string restUri)
        {
            if (String.IsNullOrWhiteSpace(resource))
            {
                string error = "Invalid resource uri,resource is empty.";
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
                    gatewayApi = "apis";
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
                restClient.GatewayUrl = String.Format("{0}rest/{1}", restClient.GatewayUrl, resource);
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

                restUri = String.Format("{0}rest/{1}", restUri, resource);
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

        private string BuildRestUri(string bizUrl, string resource)
        {
            if (bizUrl.EndsWith("/"))
            {
                bizUrl = bizUrl.Substring(0, bizUrl.Length - 1);
            }

            if (resource.EndsWith("/"))
            {
                resource = resource.Substring(0, resource.Length - 1);
            }

            string restUrl = string.Format("{0}/rest/{1}", bizUrl, resource);
            return restUrl;
        }

        private string GetNewACAAnonymousToken()
        {
            var client = new InternalAPIClient();
            var apiUrl = configurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = UrlHelper.CombinePath(apiUrl, "/aaauth/acaanonymoustoken");

            var request = new WSACAAnonymousTokenRequest();
            request.AgencyName = this._agencyName;
            request.EnvironmentName = this._environmentName;
            request.ForceToRefresh = true;

            var result = client.Execute<WSAATokenResponse>(requestUrl, request, RestSharp.Method.POST);
            return result != null ? result.Token : String.Empty;
        }

        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        private static ILog Log
        {
            get
            {
                //return ObjectFactory.GetLog();

                // TODO:
                // Removes the above code later.
                // Uses the new DLL.

                return LogFactory.GetLog();
            }
        }

        public enum Method
        {
            GET = 0,
            POST = 1,
            PUT = 2,
            DELETE = 3
            //HEAD = 4,
            //OPTIONS = 5,
            //PATCH = 6,
        }
    }
}
