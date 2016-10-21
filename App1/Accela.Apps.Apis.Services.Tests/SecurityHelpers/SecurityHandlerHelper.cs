using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.ScopeRequests;
using Accela.Apps.Dev.WSModels.V2;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.OAuth.Token.RelyingParty;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.User.WSModels.V2.Auth;
using Accela.Core.Ioc;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Exceptions;
using System;
using System.Linq;
using System.Net;


namespace Accela.Apps.Apis.Services.Tests.SecurityHelpers
{
    public class SecurityHandlerHelper
    {
        private IScopeBusinessEntity _scopeBusinessEntity
        {
            get
            {
                return IocContainer.Resolve<IScopeBusinessEntity>();
            }
        }

        private IResourceBusinessEntity _resourceBusinessEntity
        {
            get
            {
                return IocContainer.Resolve<IResourceBusinessEntity>();
            }
        }


        private IConfigurationReader ConfigurationReader { get { return new AppConfigurationReader(); } }

        public  IAgencyAppContext GetAuthenticatedAgencyContext(string requestAbsoluteUrl, string httpMethod)
        {
            WSErrorResponse unauthedResponse = new WSErrorResponse();
            var resourceModel = _resourceBusinessEntity.GetResource(requestAbsoluteUrl, httpMethod);
            var civicIdOauthToken = ConfigurationReader.Get("CivicIdOauthToken");
            var accessTokenModel = ParseTokenAndValidataScope(resourceModel.Name, civicIdOauthToken, ref unauthedResponse);

            APIAuthenticationType credentialType = (APIAuthenticationType)resourceModel.AuthenticationType;


            var appId = accessTokenModel != null ? accessTokenModel.ClientId : null;
            var appModel = GetAppById(appId);


            var agencyName = "Jackie-BPTDEV";//accessTokenModel.AgencyName;
            var agencyModel = GetAgencyModel(agencyName);

            var servProvCode = agencyModel != null ? agencyModel.ServiceProviderCode : null;

            var aaOrAcaTokenResponse = GetAAToken(accessTokenModel, agencyName, credentialType, false);

            var context = new AgencyAppContext();
            context.Agency = agencyName;
            context.ServProvCode = servProvCode;
            context.LoginName = accessTokenModel.LoginName;
            context.SocialToken = aaOrAcaTokenResponse.Token;
            context.App = accessTokenModel.ClientId;
            context.AppName = appModel != null ? appModel.AppName : String.Empty;
            context.AppType = accessTokenModel.ClientType;
            context.EnvName = accessTokenModel.EnvironmentName;
            context.Token = aaOrAcaTokenResponse.Token;
            context.IsAuthed = true;
            if (agencyModel == null)
            {
                agencyModel = GetAgencyModel(agencyName);
            }
            context.ContextUser = new ContextUser()
            {
                Id = new Guid(accessTokenModel.CloudUserId),
                Agency = agencyName,
                Environment = accessTokenModel.EnvironmentName,
                LoginName = accessTokenModel.LoginName,
                AgencyID = agencyModel != null && agencyModel.AgencyId != null ? agencyModel.AgencyId.Value : Guid.Empty
            };

            return context;

        }


        private WSAATokenResponse GetAAToken(AccelaAccessTokenModel accessTokenModel, string agencyName, APIAuthenticationType credentialType, bool autoRegister = false)
        {
            WSAATokenResponse aaTokenResponse = null;
            if (accessTokenModel.ClientType == AppType.Agency)
            {
                aaTokenResponse = GetAAAgencyToken(accessTokenModel.CloudUserId, agencyName, accessTokenModel.EnvironmentName);
            }
            else if (accessTokenModel.ClientType == AppType.Citizen)
            {
                if (credentialType == APIAuthenticationType.USER_IDENTITY_WITH_LINKED_AUTOMATION_ACCOUNT)
                {
                    // if failed to auto-create ACA account, then return ACA anonymous token when flag autoRegister is true
                    try
                    {
                        aaTokenResponse = GetACAToken(accessTokenModel.CloudUserId, agencyName, accessTokenModel.EnvironmentName, autoRegister);
                    }
                    catch (MobileException ex)
                    {
                        var failedToAutoCreateACAAccount = ex.ErrorCode == ErrorCodes.unauthorized_401
                            || ex.ErrorCode == ErrorCodes.create_aca_user_failed_500
                            || ex.ErrorCode == ErrorCodes.require_mannual_link_account_401;
                        var noReturnedToken = aaTokenResponse == null || String.IsNullOrWhiteSpace(aaTokenResponse.Token);

                        if (autoRegister && failedToAutoCreateACAAccount && noReturnedToken)
                        {
                            aaTokenResponse = GetAAAnonymousToken(agencyName, accessTokenModel.EnvironmentName);
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }
                else
                {
                    aaTokenResponse = GetAAAnonymousToken(agencyName, accessTokenModel.EnvironmentName);
                }
            }

            return aaTokenResponse;
        }

        private WSAATokenResponse GetACAToken(string cloudUserId, string agencyName, string environement, bool autoRegister = false)
        {
            if (String.IsNullOrWhiteSpace(cloudUserId))
            {
                throw new TokenException("Invalid access token.", "Can't found Cloud UserId", ErrorCodes.unauthorized_401);
            }

            var client = new InternalAPIClient();
            var apiUrl = ConfigurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = UrlHelper.CombinePath(apiUrl, "aaauth/acausertoken");
            WSAATokenRequest request = new WSAATokenRequest()
            {
                CloudUserId = cloudUserId,
                AgencyName = agencyName,
                Environment = environement,
                AutoRegister = autoRegister
            };

            var response = client.Execute<WSAATokenResponse>(requestUrl, request, RestSharp.Method.POST);

            return response;
        }

        private WSAATokenResponse GetAAAgencyToken(string cloudUserId, string agencyName, string environement)
        {
            if (String.IsNullOrWhiteSpace(cloudUserId))
            {
                throw new TokenException("Invalid access token.", "Can't found Cloud UserId", ErrorCodes.unauthorized_401);
            }

            var client = new InternalAPIClient();
            var apiUrl = ConfigurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = UrlHelper.CombinePath(apiUrl, "aaauth/aausertoken");
            WSAATokenRequest request = new WSAATokenRequest()
            {
                CloudUserId = cloudUserId,
                AgencyName = agencyName,
                Environment = environement
            };

            var response = client.Execute<WSAATokenResponse>(requestUrl, request, RestSharp.Method.POST);

            return response;
        }


        private WSAATokenResponse GetAAAnonymousToken(string agencyName, string environment)
        {
            var client = new InternalAPIClient();
            var apiUrl = ConfigurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = UrlHelper.CombinePath(apiUrl, "/aaauth/acaanonymoustoken");

            WSACAAnonymousTokenRequest request = new WSACAAnonymousTokenRequest();
            request.AgencyName = agencyName;
            request.EnvironmentName = environment;
            request.ForceToRefresh = false;
            var response = client.Execute<WSAATokenResponse>(requestUrl, request, RestSharp.Method.POST);

            return response;
        }

        private Admin.Agency.Client.Models.AgencyModel GetAgencyModel(string agencyName)
        {
            var agencyService = IocContainer.Resolve<Admin.Agency.Client.IAgencySettingsService>();
            return agencyService.GetAgency(agencyName);
        }

        private WSApp GetAppById(string appId)
        {
            WSApp result = null;

            if (!String.IsNullOrWhiteSpace(appId))
            {

                string baseUri = ConfigurationReader.Get("Ref_InternalAPI_Dev");
                    string resourceUri = UrlHelper.CombinePath(baseUri, "/apps/", appId);
                    var client = new InternalAPIClient();
                    var tempResult = client.Execute<WSAppResponse>(resourceUri);

                    if (tempResult != null && tempResult.App != null && tempResult.App.AppId == appId)
                    {
                        result = tempResult.App;
                    }
                    else
                    {
                        throw new Exception("The app does not exist.");
                    }
               
            }

            return result;
        }

        private AccelaAccessTokenModel ParseTokenAndValidataScope(string currentRequestedScope, string accessTokenString, ref WSErrorResponse unauthedResponse)
        {
            if (string.IsNullOrEmpty(accessTokenString))
            {
                //LogFactory.GetLog().Error("Token is required", "parameter token is null.", "SecurityAccessHandler.ValidateToken()");
                unauthedResponse = new WSErrorResponse(HttpStatusCode.Unauthorized, ErrorCodes.no_token_401, "Token is required.", null, Guid.NewGuid().ToString());  //Context.TraceID);
                return null;
            }

            var accessTokenModel = GetValidatedToken(currentRequestedScope, accessTokenString);

            //check scope
            if (accessTokenModel == null)
            {
                var errorMessage = "Invalid token";
                var errorMessageMore = String.Format("No matched scope", currentRequestedScope);
                unauthedResponse = new WSErrorResponse(HttpStatusCode.Forbidden, ErrorCodes.forbidden_403, errorMessage, errorMessageMore, Guid.NewGuid().ToString()); //Context.TraceID);
            }

            return accessTokenModel;
        }

        private AccelaAccessTokenModel GetValidatedToken(string currentRequestedScope, AccelaAccessTokenModel accessTokenModel)
        {
            AccelaAccessTokenModel result = null;

            if (!String.IsNullOrWhiteSpace(currentRequestedScope) && accessTokenModel != null)
            {
                var scopesInToken = accessTokenModel != null && accessTokenModel.Scope != null ? accessTokenModel.Scope.ToArray() : null;
                scopesInToken = scopesInToken.Union(new string[] { "settngs" }).ToArray();
                var scopeValidationRequest = scopesInToken != null && scopesInToken.Length > 0 ?
                        new IsValidScopeRequest()
                        {
                            RequestScope = currentRequestedScope,
                            ScopesInToken = scopesInToken
                        } : null;
                bool isScopeAuthed = scopeValidationRequest != null ? _scopeBusinessEntity.IsValidScope(scopeValidationRequest) : false;
                result = isScopeAuthed ? accessTokenModel : null;
            }

            return result;
        }

        private AccelaAccessTokenModel GetValidatedToken(string currentRequestedScope, string accessTokenString)
        {
            AccelaAccessTokenModel result = null;

            if (!String.IsNullOrWhiteSpace(currentRequestedScope) && !String.IsNullOrWhiteSpace(accessTokenString))
            {
                var accessTokenModel = ParseToken(accessTokenString);
                result = GetValidatedToken(currentRequestedScope, accessTokenModel);
            }

            return result;
        }

        private AccelaAccessTokenModel ParseToken(string token)
        {
            var signingKey = ConfigurationReader.Get("AccessTokenSigningKey");
            var encryptionKey = ConfigurationReader.Get("ResourceServerEncryptionKey");
            AccelaAccessTokenModel accessTokenModel = RelyingPartyTokenHelper.ParseAndValidateToken(token, signingKey, encryptionKey);

            return accessTokenModel;
        }

        private bool IsValidAccessKey(string accessKey)
        {
            bool isValid = false;
            // get access key from configuration file.
            string internalAccessKey = ConfigurationReader.Get("InternalAPI_AccessKey");

            if (internalAccessKey == accessKey)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
