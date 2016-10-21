using Accela.Apps.Apis.Services.Handlers.Helpers;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Accela.Apps.Shared.RestClients;
using Accela.Infrastructure.Configurations;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Accela.Apps.Apis.Services.V4.PublicAPIs
{
    [RoutePrefix("v4/civicid")]
    public class CivicidController : ControllerBase
    {
        private readonly IConfigurationReader configurationReader;
        private readonly IAgencyAppContext agencyContext;
        private readonly IGatewayClient _gatewayClient;

        public CivicidController(IConfigurationReader configurationReader, IAgencyAppContext agencyContext, IGatewayClient gatewayClient)
        {
            this.configurationReader = configurationReader;
            this.agencyContext = agencyContext;
            this._gatewayClient = gatewayClient;
        }

        [Route("accounts/{id}")]
        public async Task<HttpResponseMessage> GetAccountById(string id, string lang = null)
        {
            if (AppType.Agency.Equals(this.agencyContext.AppType))
            {
                var bizTokenModel = BizTokenHelper.GetRegisteredAgencyUserToken(this.agencyContext.CivicId, this.agencyContext.Agency, null, this.agencyContext.EnvName, this.agencyContext);
                string requestUrlTemplate = "apis/v4/users/me?token={0}";
                string requestUrl = String.Format(requestUrlTemplate, bizTokenModel.Token);

                var response = await _gatewayClient.SendAsync(ApiTypes.NormalApi, requestUrl, HttpMethod.Get);
                return response;
            }
            else
            {
                string internalSubSystemBaseUrl = configurationReader.Get("Ref_InternalAPI_User");
                string subsystemBaseUrl = internalSubSystemBaseUrl.Split(new string[] { "/apis/" }, StringSplitOptions.None)[0];
                var internalRequestUrl = subsystemBaseUrl + "/apis" + Request.RequestUri.PathAndQuery;
                var internalApiClient = new InternalAPIClient(this.agencyContext);    // pass on context about agency, env.
                var response = await internalApiClient.SendAsync(internalRequestUrl, HttpMethod.Get, null, null, this.agencyContext.TraceID);
                return response;
            }
        }

    }
}
