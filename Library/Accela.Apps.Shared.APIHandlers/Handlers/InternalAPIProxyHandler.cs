using Accela.Core.Configurations;
using Accela.Apps.Shared.APIHandlers.Helpers;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.WSModels;
using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.APIHandlers.Handlers
{
    public class InternalAPIProxyHandler : DelegatingHandler
    {
        private static IDictionary<string, string> INTERNAL_RESOURCE_API_MAPPING = null;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }

        public InternalAPIProxyHandler()
        {
            LoadInternalAPISetting();
        }

        /// <summary>
        /// For internal test purpose
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> SendAsyncInternal(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string localPath = request.RequestUri.LocalPath;
            if (!string.IsNullOrWhiteSpace(localPath))
            {
                // Ex. /dev
                string[] paths = localPath.Substring(1).Split('/');
                if (paths != null && paths.Length > 1 && INTERNAL_RESOURCE_API_MAPPING.ContainsKey(paths[0]))
                {
                    request.RequestUri = new Uri(INTERNAL_RESOURCE_API_MAPPING[paths[0]] + localPath.Substring(paths[0].Length + 1));
                    return ReverseProxy(request);
                }
            }
            
            return base.SendAsync(request, cancellationToken);
        }

        private static void LoadInternalAPISetting()
        {
            if (INTERNAL_RESOURCE_API_MAPPING == null)
            {
                // Ex. developer,user
                string internalApiResources = ConfigurationSettings.Get("InternalAPI_Resources");
                INTERNAL_RESOURCE_API_MAPPING = new Dictionary<string, string>();
                if (!string.IsNullOrWhiteSpace(internalApiResources))
                {
                    var resources = internalApiResources.Split(',');
                    foreach (string resource in resources)
                    {
                        INTERNAL_RESOURCE_API_MAPPING[resource] = ConfigurationSettings.Get("Ref_InternalAPI_" + resource);
                    }

                }
            }

        }

        public async static Task<HttpResponseMessage> ReverseProxy(HttpRequestMessage request)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
            {
                return (true);
            };
            string internalAccessKey = ConfigurationSettings.Get("InternalAPI_AccessKey");
            request.Headers.Add(ResponseHeaderConstants.X_Accela_Header_SubSystem_AccessKey, internalAccessKey);
            if (request.Method == HttpMethod.Get || request.Method == HttpMethod.Trace) request.Content = null;
            
            var httpClient = HttpClientSingletonWrapper.Instance;

            var responseMessage = httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            return await responseMessage;
        }

    }
}
