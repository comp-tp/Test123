using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.OAuth2;
using Accela.Apps.Shared;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.OAuth.Token.RelyingParty;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.Utils;
using Accela.Infrastructure.Configurations;

using System.Web.Http;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("oauth2")]
    [APIControllerInfoAttribute(Name = "OAuth2", Group = "Auth", Order = 1, Description = "The following APIs are related to OAuth2.")]
    public class OAuth2Controller : ControllerBase
    {
        private readonly IConfigurationReader configurationReader;
		private readonly IAgencyAppContext agencyContext;
        public OAuth2Controller(IConfigurationReader configurationReader, IAgencyAppContext agencyContext)
        {
            this.configurationReader = configurationReader;
			this.agencyContext = agencyContext;
        }


        [HttpGet]
        [Route("tokenInfo")]
        [APIActionInfoAttribute(Name = "Get Access Token Info", Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Returns access token info.")]
        public HttpResponseMessage GetTokenInfo()
        {
            var result = new WSAccessTokenInfo();
            var responseStatus = HttpStatusCode.OK;
            AccelaAccessTokenModel parsedAccessTokenModel = null;
            Exception innerException = null;

            try
            {
                parsedAccessTokenModel = GetAccessToken();
            }
            catch (Exception ex)
            {
                if (!(ex is TokenException))
                {
                    throw new Exception("Internal server error.");
                }
            }

            if (parsedAccessTokenModel != null)
            {
                result.AgencyName = parsedAccessTokenModel.AgencyName;
                result.Environment = parsedAccessTokenModel.EnvironmentName;
                result.AppId = parsedAccessTokenModel.ClientId;
                result.UserId = parsedAccessTokenModel.CloudUserId;
                result.Scopes = parsedAccessTokenModel.Scope != null && parsedAccessTokenModel.Scope.Count > 0 ? parsedAccessTokenModel.Scope.ToList() : null;
                result.ExpiresIn = parsedAccessTokenModel.ExpiresIn;
            }
            else
            {
                throw new BadRequestException("Invalid token.", innerException, "invalid_token");
            }

            return Request.CreateResponse(responseStatus, result);
        }

        private AccelaAccessTokenModel GetAccessToken()
        {
            var accessTokenString = GetAccessTokenString();

            AccelaAccessTokenModel result = null;

            if (!String.IsNullOrWhiteSpace(accessTokenString))
            {
                var signingKey = configurationReader.Get("AccessTokenSigningKey");
                var encryptionKey = configurationReader.Get("ResourceServerEncryptionKey");
                result = RelyingPartyTokenHelper.ParseAndValidateToken(accessTokenString, signingKey, encryptionKey);
            }

            return result;
        }

        private string GetAccessTokenString()
        {
            string result = null;
            var authorization = Request.Headers.Authorization;
            var authorizationString = authorization != null ? authorization.ToString() : null;

            if (!String.IsNullOrWhiteSpace(authorizationString))
            {
                var authorizationParts = authorizationString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (authorizationParts.Length == 1)
                {
                    result = authorizationParts[0];
                }
                else if (authorizationParts.Length == 2
                    && authorizationParts[0].Equals("bearer", StringComparison.OrdinalIgnoreCase)
                    )
                {
                    result = authorizationParts[1];
                }
            }

            return result;
        }
    }
}
