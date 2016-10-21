using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Accela.Apps.Shared;
using System.Net;
using System.Net.Http.Formatting;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.Shared.Exceptions;
using Accela.Core.Configurations;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Shared.APIHandlers
{
    public class InternalAPISecurityHandler : DelegatingHandler
    {
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }
        private static string _internalApiKey; 

        public InternalAPISecurityHandler(string internalApiKey)
        {
            _internalApiKey = internalApiKey;
        }

        public InternalAPISecurityHandler()
        {
            _internalApiKey = "";
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpMessage message = new HttpMessage(request);
            string accessKey = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_SubSystem_AccessKey);
            string traceId = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_TraceId);
            if (IsValidAccessKey(accessKey))
            {
                return base.SendAsync(request, cancellationToken);
            }
            else // invalid access key 
            {
                WSErrorResponse response = new WSErrorResponse(HttpStatusCode.Unauthorized, null, "Invalid internal access key", ErrorCodes.invalid_access_key_401, traceId);
                return HttpResponseHelper.SendAsync(request, response, traceId);
            }
        }

        private bool IsValidAccessKey(string accessKey)
        {
            if (string.IsNullOrEmpty(_internalApiKey))
            {
                _internalApiKey = ConfigurationSettings.Get("InternalAPI_AccessKey");
            }
            bool isValid = false;
            // get access key from configuration file.
            //string internalAccessKey = this._internalApiKey; //AzureConfiguration.GetConfigurationSetting("InternalAPI_AccessKey");

            if (!String.IsNullOrWhiteSpace(_internalApiKey) && _internalApiKey == accessKey)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
