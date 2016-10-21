using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ScopeRequests;
using Accela.Apps.Apis.Services;
using Accela.Apps.Apis.Services.Handlers.Helpers;
using Accela.Core.Ioc;
using Accela.Core.Configurations;
using Accela.Apps.Dev.WSModels.V2;
using Accela.Apps.Shared.APIHandlers;

using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Exceptions;
using Accela.Core.Logging;
using Accela.Apps.Shared.OAuth.Token.RelyingParty;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Shared.WSModels;
using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using Accela.Apps.Admin.Agency.Client;

namespace Accela.Apps.Apis.APIHandlers
{
    public class SecurityAccessHandler : DelegatingHandler
    {
        private const string MESSAGE_NO_MATCHED_SCOPE_IN_TOKEN = "You are not authorized to access the resource. The API scope is not allowed.";
        private const string MESSAGE_MORE_NO_MATCHED_SCOPE_IN_TOKEN = "Scope '{0}' or related group should be allowed by CivicID.";
        private string[] IgnoredScopes = new string[] { "get_oauth2_token", "get_oauth2_token_info" };

        private static IConfigurationReader ConfigurationReader { get { return ConfigurationSettingsManager.Get(); } }

        public SecurityAccessHandler()
        {
        }

        /// <summary>
        /// Get Log
        /// </summary>
        private ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //request.GetDependencyScope();
            var resourceBusinessEntity = IocContainer.Resolve<IResourceBusinessEntity>();
            var scopeBusinessEntity = IocContainer.Resolve<IScopeBusinessEntity>();
            var appBiz = IocContainer.Resolve<IAppBusinessEntity>();
            var agenyBiz = IocContainer.Resolve<IAgencySettingsService>();

            IAgencyAppContext _context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
            try
            {
                #region ResourceModel check

                WSErrorResponse unauthedResponse = null;
                HttpMessage message = new HttpMessage(request);
                string httpMethod = message.GetHttpMethod();
                string traceId = _context.TraceID;
                // CORS request will use OPTIONS http method to check if current server supports CORS or not.
                // for the request, just simply return and handle over the request to the CORS component.
                if ("OPTIONS".Equals(httpMethod, StringComparison.OrdinalIgnoreCase))
                {
                    return await base.SendAsync(request, cancellationToken);
                }

                ResourceModel resourceModel = ResourceHelper.GetResourceModelFromRequestOrCache(request);

                //resourceModel.AuthenticationType
                if (resourceModel == null)
                {
                    unauthedResponse = ErrorResponses.GetAPINotFoundResponse(request, _context.TraceID);
                    unauthedResponse.TraceId = traceId;
                    WriteLog(unauthedResponse);
                    return HttpResponseHelper.BuildErrorResponse(request, unauthedResponse, _context.TraceID);
                }

                
                if (IgnoredScopes != null && IgnoredScopes.Contains(resourceModel.Name))
                {
                    // call next handler
                    return await base.SendAsync(request, cancellationToken);
                }

                #endregion

                // get credential type
                // -1: api is not existed.
                // 0-None authentication required. -- e.g: get access token api
                // 1-USER_IDENTITY -- Civic ID login required, Don't require api to pass any agency.
                // 2-App Identity -- AppId & AppSecret  -- e.g: app data and app setting apis
                // 3-Access Key for internal api
                // 4-USER_IDENTITY_WITH_ACA_ANONYMOUS - access token with aca anonymous, 
                //                                      requires api MUST pass agency name either from http header or token includs the agence name.
                // 5-USER_IDENTITY_WITH_LINKED_AUTOMATION_ACCOUNT - 
                //                                      access token with linked ACA registered account/access token with Linked AA account
                //                                      requires api MUST pass agency name either from http header or token includs the agence name.
                APIAuthenticationType credentialType = (APIAuthenticationType)resourceModel.AuthenticationType;

                string appId = message.GetAppID();

                var isProxyAPI = resourceModel.IsProxy == 1;

                AppModel appModel = null;
                Admin.Agency.Client.Models.AgencyModel agencyModel = null;
                BizTokenModel bizTokenModel = null;

                bool isAcrossAgencies = !String.IsNullOrWhiteSpace(message.GetHeaderValue("x-accela-agencies"));

                // restore context from request.Properties
                if (request.Properties.ContainsKey(Constants.PROPERTIES_KEY_CONTEXT) && request.Properties[Constants.PROPERTIES_KEY_CONTEXT] != null)
                {
                    IAgencyAppContext context = request.Properties[Constants.PROPERTIES_KEY_CONTEXT] as IAgencyAppContext;
                    _context = context;
                }

                if (_context.Items == null)
                {
                    _context.Items = new Dictionary<string, object>();
                }

                switch (credentialType)
                {
                    /*
                        0-None required, api like below:
                        /oauth2/token
                        /v3/search/records/coordinates
                        /v3/civicheroapp/search/records
                        /v3/a311civicapp/search/records
                        /v3/a311civicapp/records/{id}
                     
                     * The following APIs can be used by both Agency App and Citizen App.
                        /v4/agencies
                        /v4/agencies/{name}
                        /v4/agencies/{name}/logo
                     */
                    case APIAuthenticationType.NONE: // 0-None required.
                        #region get validated access token and App model
                        var requestedScope = resourceModel != null ? resourceModel.Name : null;
                        var accessToken = message.GetToken();
                        var accessTokenModel = !String.IsNullOrWhiteSpace(accessToken) ? ParseToken(accessToken) : null;
                        appId = accessTokenModel != null ? accessTokenModel.ClientId : appId;
                        var accessTokenModel4NoneType = GetValidatedToken(requestedScope, accessTokenModel);
  
                        if (String.IsNullOrWhiteSpace(appId))
                        {
                            unauthedResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, "App ID or access token is required.", "Please set App ID to request HTTP header 'x-accela-appid' for anonymous access, or set access token to request HTTP header 'Authorization' for authenticated access.", traceId);
                            break;
                        }

                        appModel = appBiz.GetAppByAppId(appId);

                        ValidateAppStatus(appModel);
                        _context.CivicId = accessTokenModel != null ? accessTokenModel.CloudUserId : null;

                        var appType = (AppType)appModel.AppType;

                        #endregion

                        #region set context for agency, environment, appId, appType

                        _context.App = appId;
                        _context.AppName = appModel.AppName;
                        _context.AppType = appType;

                        _context.Agency = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency);
                        _context.EnvName = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Environment);

                        if (String.IsNullOrWhiteSpace(_context.Agency)
                                && accessTokenModel != null
                                && !String.IsNullOrWhiteSpace(accessTokenModel.AgencyName)
                                )
                        {
                            _context.Agency = accessTokenModel.AgencyName;
                        }

                        if (String.IsNullOrWhiteSpace(_context.EnvName)
                            && accessTokenModel != null
                            && !String.IsNullOrWhiteSpace(accessTokenModel.EnvironmentName)
                            )
                        {
                            _context.EnvName = accessTokenModel.EnvironmentName;
                        }

                        if (accessTokenModel != null && !String.IsNullOrWhiteSpace(accessTokenModel.LoginName))
                        {
                            _context.LoginName = accessTokenModel.LoginName;
                        }

                        #endregion

                        #region set context AA anonymous token, agency and environment

                        if (isProxyAPI
                            && !String.IsNullOrWhiteSpace(_context.Agency)
                            && !String.IsNullOrWhiteSpace(_context.EnvName)
                            && String.IsNullOrWhiteSpace(_context.SocialToken)
                            )
                        {
                            if (accessTokenModel4NoneType != null && !String.IsNullOrWhiteSpace(accessTokenModel4NoneType.CloudUserId))
                            {
                                _context.Items["CloudUserId"] = accessTokenModel4NoneType.CloudUserId;
                            }

                            if (accessTokenModel4NoneType != null && accessTokenModel4NoneType.ClientType == AppType.Agency)
                            {
                                bizTokenModel = BizTokenHelper.GetRegisteredAgencyUserToken(accessTokenModel4NoneType.CloudUserId, _context.Agency, null, _context.EnvName, _context);
                            }
                            else if (accessTokenModel4NoneType != null && accessTokenModel4NoneType.ClientType == AppType.Citizen)
                            {
                                bizTokenModel = BizTokenHelper.GetRegisteredCitizenUserToken(accessTokenModel4NoneType.CloudUserId, _context.Agency, null, _context.EnvName, true, _context);
                            }
                            else
                            {
                                bizTokenModel = BizTokenHelper.GetAnonymousUserToken(_context.Agency, _context.EnvName,false, _context);
                            }

                            _context.Items["tokenType"] = bizTokenModel != null ? bizTokenModel.TokenType : BizTokenType.Unknown;
                            _context.Items["autoRegister"] = true;
                            _context.SocialToken = bizTokenModel != null ? bizTokenModel.Token : null;
                        }

                        if (isProxyAPI && !String.IsNullOrWhiteSpace(_context.Agency))
                        {
                            agencyModel = agenyBiz.GetAgency(_context.Agency);

                            _context.ServProvCode = agencyModel != null ? agencyModel.ServiceProviderCode : null;

                            if (String.IsNullOrEmpty(_context.ServProvCode))
                            {
                                unauthedResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Failed to retrive agency code.", null, _context.TraceID);
                                break;
                            }

                            appBiz.ValidateAppPermissionByAgency(appModel.Id, agencyModel.Name);
                        }

                        if (accessTokenModel4NoneType != null)
                        {
                            _context.ContextUser = new ContextUser()
                            {
                                Id = new Guid(accessTokenModel4NoneType.CloudUserId)
                            };
                        }

                        #endregion

                        break;

                    /*
                        1 - Only need civic id login, don't need connect to any agency hosted ACA/AA, 
                            Only access cloud resources and tables etc.
                        api like below:
                        /v3/civicheroapp/records/mine
                        /v3/a311civicapp/records/{id}/usercomments
                        /v3/a311civicapp/records/{id}/unfollow
                        /v3/a311civicapp/records
                     */
                    case APIAuthenticationType.USER_IDENTITY:

                        #region 1. ParseTokenAndValidataScope

                        accessTokenModel = ParseTokenAndValidataScope(resourceModel.Name, message.GetToken(), ref unauthedResponse);
                        if (unauthedResponse != null)
                        {
                            unauthedResponse.TraceId = traceId;
                            break;
                        }

                        #endregion

                        appId = accessTokenModel != null ? accessTokenModel.ClientId : null;
                        appModel = appBiz.GetAppByAppId(appId);
                        ValidateAppStatus(appModel);

                        _context.CivicId = accessTokenModel != null ? accessTokenModel.CloudUserId : null;

                        #region 2.Get Agency name & Env name

                        _context.Agency = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency);
                        //_context.EnvName = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Environment);

                        if (String.IsNullOrWhiteSpace(_context.Agency)
                                && accessTokenModel != null
                                && !String.IsNullOrWhiteSpace(accessTokenModel.AgencyName)
                                )
                        {
                            _context.Agency = accessTokenModel.AgencyName;
                        }

                        //if (String.IsNullOrWhiteSpace(_context.EnvName)
                        //    && accessTokenModel != null
                        //    && !String.IsNullOrWhiteSpace(accessTokenModel.EnvironmentName)
                        //    )
                        //{
                            _context.EnvName = accessTokenModel.EnvironmentName;
                        //}

                        #endregion

                        #region 3.Set Context

                        _context.IsAuthed = true;
                        _context.LoginName = accessTokenModel.LoginName;
                        _context.App = accessTokenModel.ClientId;
                        _context.AppName = appModel != null ? appModel.AppName : String.Empty;
                        _context.AppType = accessTokenModel.ClientType;

                        //User may not be sending agency name in the header, which is not required. 
                        //hot fix: CF-206 - Concord Civic Hero - Cannot Login/Sign Up
                        if (!String.IsNullOrWhiteSpace(_context.Agency) && agencyModel == null)
                        {
                            agencyModel = agenyBiz.GetAgency(_context.Agency);  
                        }
                        _context.ContextUser = new ContextUser()
                        {
                            Id = new Guid(accessTokenModel.CloudUserId),
                            Agency = _context.Agency,
                            Environment = _context.EnvName,
                            LoginName = accessTokenModel.LoginName,
                            AgencyID = agencyModel != null && agencyModel.AgencyId != null ? agencyModel.AgencyId.Value : Guid.Empty
                        };

                        _context.SocialToken = "DUMMY_TOKEN";
                        _context.ServProvCode = agencyModel != null ? agencyModel.ServiceProviderCode : null;

                        if(agencyModel != null)
                        {
                            appBiz.ValidateAppPermissionByAgency(appModel.Id, agencyModel.Name);
                        }

                        #endregion

                        break;

                    /*
                     This Autentication type is usually as Citize App.
                     need civic id login and ACA anonymous account.
                     Agency Name is required either from token or header.
                     
                     Support dynamic agency concept
                     */
                    case APIAuthenticationType.USER_IDENTITY_WITH_ACA_ANONYMOUS:

                        #region 1. ParseTokenAndValidataScope

                        accessTokenModel = ParseTokenAndValidataScope(resourceModel.Name, message.GetToken(), ref unauthedResponse);
                        if (unauthedResponse != null)
                        {
                            unauthedResponse.TraceId = traceId;
                            break;
                        }

                        #endregion

                        appId = accessTokenModel != null ? accessTokenModel.ClientId : null;
                        appModel = appBiz.GetAppByAppId(appId);
                        ValidateAppStatus(appModel);

                        _context.CivicId = accessTokenModel != null ? accessTokenModel.CloudUserId : null;

                        #region 2. AgencyName and ServProvCode validation

                        _context.IsAuthed = true;

                        _context.Agency = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency);
                        _context.EnvName = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Environment);

                        if (String.IsNullOrWhiteSpace(_context.Agency)
                                && accessTokenModel != null
                                && !String.IsNullOrWhiteSpace(accessTokenModel.AgencyName)
                                )
                        {
                            _context.Agency = accessTokenModel.AgencyName;
                        }

                        if (String.IsNullOrWhiteSpace(_context.EnvName)
                            && accessTokenModel != null
                            && !String.IsNullOrWhiteSpace(accessTokenModel.EnvironmentName)
                            )
                        {
                            _context.EnvName = accessTokenModel.EnvironmentName;
                        }

                        string servProvCode = null;

                        // v2 private api doesn't need to check agency name --e.g. A311 create record api, agency is decided by server
                        // only public api need the agency check
                        if (String.IsNullOrWhiteSpace(_context.Agency) && !isAcrossAgencies)
                        {
                            unauthedResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, "agency is required.", null, _context.TraceID);
                            break;
                        }

                        if (!String.IsNullOrWhiteSpace(_context.Agency))
                        {
                            if (agencyModel == null)
                            {
                                agencyModel = agenyBiz.GetAgency(_context.Agency);
                            }
                            servProvCode = agencyModel != null ? agencyModel.ServiceProviderCode : null;
                            // only public api need the servprovcode check
                            if (String.IsNullOrEmpty(servProvCode))
                            {
                                unauthedResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Failed to retrive agency code.", null, _context.TraceID);
                                break;
                            }

                            appBiz.ValidateAppPermissionByAgency(appModel.Id, agencyModel.Name);
                        }

                        #endregion

                        #region 3. Get aa/aca token according to App Type(Citzien or Agency)

                        if (!String.IsNullOrWhiteSpace(_context.Agency))
                        {
                            bizTokenModel = BizTokenHelper.GetAnonymousUserToken(_context.Agency, accessTokenModel.EnvironmentName,false, _context);
                        }

                        #endregion

                        #region 4. Set Context

                        _context.SocialToken = bizTokenModel != null ? bizTokenModel.Token : null;
                        _context.ServProvCode = servProvCode;
                        _context.LoginName = accessTokenModel.LoginName;
                        _context.App = accessTokenModel.ClientId;
                        _context.AppName = appModel != null ? appModel.AppName : String.Empty;
                        _context.AppType = accessTokenModel.ClientType;
                     
                        _context.ContextUser = new ContextUser()
                        {
                            Id = new Guid(accessTokenModel.CloudUserId),
                            Agency = _context.Agency,
                            Environment = _context.EnvName,
                            LoginName = accessTokenModel.LoginName,
                            AgencyID = agencyModel != null && agencyModel.AgencyId != null ? agencyModel.AgencyId.Value : Guid.Empty
                        };

                        #endregion

                        break;

                    /*
                     5 - It requires MUST use ACA or AA register Accounts to access resources.
                     * For citizen App, requires ACA register account, support dynamic agency concept
                     * For agency App, requires AA register account
                     * 
                     */
                    case APIAuthenticationType.USER_IDENTITY_WITH_LINKED_AUTOMATION_ACCOUNT:

                        #region 1. ParseTokenAndValidataScope

                        accessTokenModel = ParseTokenAndValidataScope(resourceModel.Name, message.GetToken(), ref unauthedResponse);

                        if (unauthedResponse != null)
                        {
                            unauthedResponse.TraceId = traceId;
                            break;
                        }

                        #endregion

                        appId = accessTokenModel != null ? accessTokenModel.ClientId : null;
                        appModel = appBiz.GetAppByAppId(appId);
                        ValidateAppStatus(appModel);
                        _context.CivicId = accessTokenModel != null ? accessTokenModel.CloudUserId : null;

                        #region 2. AgencyName and ServProvCode validation

                        _context.IsAuthed = true;
                        _context.Agency = accessTokenModel.AgencyName;
                        _context.EnvName = accessTokenModel.EnvironmentName;
                        _context.App = accessTokenModel.ClientId;
                        _context.AppName = appModel != null ? appModel.AppName : String.Empty;
                        _context.AppType = accessTokenModel.ClientType;
                        //check agency, if current app type is citizen, get agency from http header at first.
                        if (accessTokenModel.ClientType == AppType.Citizen)
                        {
                            var agencyNameFromHeader = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency);
                            _context.Agency = !String.IsNullOrWhiteSpace(agencyNameFromHeader) ? agencyNameFromHeader : _context.Agency;
                        }

                        _context.Agency = _context.Agency != null ? _context.Agency.Trim() : null;

                        if (String.IsNullOrEmpty(_context.Agency) && !isAcrossAgencies)
                        {
                            unauthedResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, "agency is required.", null, _context.TraceID);
                            break;
                        }

                        if (agencyModel == null && !String.IsNullOrWhiteSpace(_context.Agency))
                        {
                            agencyModel = agenyBiz.GetAgency(_context.Agency);
                        }
                        servProvCode = agencyModel != null ? agencyModel.ServiceProviderCode : null;
                        if (string.IsNullOrEmpty(servProvCode) && !isAcrossAgencies)
                        {
                            unauthedResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Failed to retrive agency code.", null, _context.TraceID);
                            break;
                        }

                        if(!isAcrossAgencies && agencyModel != null && !String.IsNullOrWhiteSpace(agencyModel.Name))
                        {
                            string currentAPI = String.Format("{0} {1}", resourceModel.HttpVerb, resourceModel.Api).ToLower();
                            appBiz.ValidateAppPermissionByAgency(appModel.Id, agencyModel.Name, currentAPI);
                        }

                        #endregion

                        #region 3. Get aa/aca token according to App Type(Citzien or Agency)

                        // for civic hero App, auto-register/link aca account.
                        var autoRegister = appModel != null
                            && (AppType)appModel.AppType == AppType.Citizen
                            && appModel.AppName != null
                            && appModel.AppName.IndexOf("civic hero", StringComparison.OrdinalIgnoreCase) != -1
                            ? true : false;

                        // temporarily set autoRegister = true for pre-release.
                        autoRegister = true;

                        if (!isAcrossAgencies)
                        {

                            if (String.IsNullOrEmpty(_context.Agency))
                            {
                                unauthedResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.bad_request_400, "agency is required.", null, traceId);
                                break;
                            }

                            if (accessTokenModel.ClientType == AppType.Agency)
                            {
                                bizTokenModel = BizTokenHelper.GetRegisteredAgencyUserToken(accessTokenModel.CloudUserId, _context.Agency, null, accessTokenModel.EnvironmentName, _context);
                            }
                            else
                            {
                                bizTokenModel = BizTokenHelper.GetRegisteredCitizenUserToken(accessTokenModel.CloudUserId, _context.Agency, null, accessTokenModel.EnvironmentName, autoRegister, _context);
                            }

                            if (bizTokenModel != null && String.IsNullOrWhiteSpace(bizTokenModel.Token))
                            {
                                if (autoRegister)
                                {
                                    unauthedResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Failded to connect to backend server.", null, _context.TraceID);
                                }
                                else
                                {
                                    unauthedResponse = new WSErrorResponse(HttpStatusCode.Forbidden, "no_linked_aca_account", "No linked ACA account.", null, _context.TraceID);
                                }

                                break;
                            }
                        }

                        #endregion

                        #region 4. Set Context
                        _context.ServProvCode = servProvCode;
                        _context.LoginName = accessTokenModel.LoginName;
                        _context.Items["CloudUserId"] = accessTokenModel.CloudUserId;
                        _context.Items["tokenType"] = bizTokenModel != null ? bizTokenModel.TokenType : BizTokenType.Unknown;
                        _context.Items["autoRegister"] = autoRegister;
                        _context.SocialToken = bizTokenModel != null ? bizTokenModel.Token : null;
                        
                        if (agencyModel == null && !isAcrossAgencies)
                        {
                            agencyModel = agenyBiz.GetAgency(_context.Agency);
                        }
                        _context.ContextUser = new ContextUser()
                        {
                            Id = new Guid(accessTokenModel.CloudUserId),
                            Agency = _context.Agency,
                            Environment = _context.EnvName,
                            LoginName = accessTokenModel.LoginName,
                            AgencyID = agencyModel != null && agencyModel.AgencyId != null ? agencyModel.AgencyId.Value : Guid.Empty
                        };

                        #endregion

                        break;

                    case APIAuthenticationType.APP_IDENTITY: //appid and appsecret required

                        if (isProxyAPI)
                        {
                            var agency = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency);
                            var environmentName = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Environment);

                            if (!String.IsNullOrWhiteSpace(agency) && !String.IsNullOrWhiteSpace(environmentName))
                            {
                            _context.Agency = agency;
                            _context.EnvName = environmentName;
                            bizTokenModel = BizTokenHelper.GetAnonymousUserToken(agency, environmentName, false, _context);
                            _context.Items["tokenType"] = bizTokenModel != null ? bizTokenModel.TokenType : BizTokenType.Unknown;
                            _context.Items["autoRegister"] = true;
                            _context.SocialToken = bizTokenModel != null ? bizTokenModel.Token : null;
                            }
                        }

                        if (string.IsNullOrWhiteSpace(appId))
                        {
                            unauthedResponse = new WSErrorResponse(HttpStatusCode.Unauthorized, ErrorCodes.no_app_credential_401, "appId and appSecret are required.", null, _context.TraceID);
                            break;
                        }

                        appModel = appBiz.GetAppByAppId(appId);

                        #region

                        string appSecret = message.GetAppSecretCode();

                        // if not passed appId and appSecret from header
                        // get it from url
                        if (String.IsNullOrWhiteSpace(appId) || String.IsNullOrWhiteSpace(appSecret))
                        {
                            appId = request.RequestUri.ParseQueryString()["appId"];
                            appSecret = request.RequestUri.ParseQueryString()["appSecret"];
                        }

                        if (!String.IsNullOrWhiteSpace(appId) && !String.IsNullOrWhiteSpace(appSecret))
                        {
                            _context.App = appId;
                            //check appId and appSecret
                            string baseUri = ConfigurationReader.Get("Ref_InternalAPI_Dev");
                            if (String.IsNullOrWhiteSpace(baseUri))
                            {
                                unauthedResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Can't get configuration item to access developer system.", null, _context.TraceID);
                            }
                            else
                            {
                                string resourceUri = UrlHelper.CombinePath(baseUri, "/apps/", appId);
                                var client = new InternalAPIClient();
                                var result = client.Execute<WSAppResponse>(resourceUri);
                                if (result == null || result.App == null)
                                {
                                    unauthedResponse = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, "Can't access developer system.", null, _context.TraceID);
                                }
                                else if (result.App.AppId != appId || result.App.AppSecret != appSecret)
                                {
                                    unauthedResponse = new WSErrorResponse(HttpStatusCode.Unauthorized, ErrorCodes.unauthorized_app_401, "The app credential is invalid.", null, _context.TraceID);
                                }
                            }
                        }
                        else
                        {
                            unauthedResponse = new WSErrorResponse(HttpStatusCode.Unauthorized, ErrorCodes.no_app_credential_401, "appId and appSecret are required.", null, _context.TraceID);
                        }

                        #endregion

                        break;
                    case APIAuthenticationType.ACCESS_KEY: //3-accesskey for internal api

                        #region Internal Access Key validation

                        string accessKey = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_SubSystem_AccessKey);
                        if (!IsValidAccessKey(accessKey))
                        {
                            unauthedResponse = new WSErrorResponse(HttpStatusCode.Unauthorized, ErrorCodes.invalid_access_key_401, "Invalid internal access key.", null, _context.TraceID);
                        }

                        #endregion

                        _context.Agency = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Agency);
                        _context.EnvName = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_Environment);

                        break;

                    default: // -1 
                        unauthedResponse = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.invalid_uri_400, "invalide uri or the uri can't be recognized by server.", null, _context.TraceID);
                        break;
                }

                CallContext.LogicalSetData("ContextEntity", _context);

                if (unauthedResponse != null)
                {
                    WriteLog(unauthedResponse);
                    return HttpResponseHelper.BuildErrorResponse(request, unauthedResponse, _context.TraceID);
                }
                else
                {
                    // call next handler
                    return await base.SendAsync(request, cancellationToken);
                }
            }
            catch (TokenException ex)
            {
                string errorCode = String.IsNullOrWhiteSpace(ex.ErrorCode) ? ErrorCodes.unauthorized_401 : ex.ErrorCode;
                var error = new WSErrorResponse(HttpStatusCode.Unauthorized, errorCode, ex.Message, null, _context.TraceID);
                WriteLog(error);
                return HttpResponseHelper.BuildErrorResponse(request, error, _context.TraceID);
            }
            catch(MobileException ex)
            {
                if(ErrorCodes.app_not_found_404 == ex.ErrorCode)
                {
                    // convert internal 404 error to 400 bad request
                    ex = new BadRequestException(ex.Message, ex.Detail, ex.ErrorCode);
                }
                var error = new WSErrorResponse(ex.HttpStatus, ex.ErrorCode, ex.Message, null, _context.TraceID);
                WriteLog(error);
                return HttpResponseHelper.BuildErrorResponse(request, error, _context.TraceID);
            }
            catch (Exception ex)
            {
                var error = new WSErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.internal_server_error_500, ex.Message, null, _context.TraceID);
                WriteLog(error);
                return HttpResponseHelper.BuildErrorResponse(request, error, _context.TraceID);
            }
        }

        private AccelaAccessTokenModel ParseToken(string token)
        {
            var signingKey = ConfigurationReader.Get("AccessTokenSigningKey");
            var encryptionKey = ConfigurationReader.Get("ResourceServerEncryptionKey");
            AccelaAccessTokenModel accessTokenModel = RelyingPartyTokenHelper.ParseAndValidateToken(token, signingKey, encryptionKey);

            return accessTokenModel;
        }

        private void ValidateAppStatus(AppModel appModel)
        {
            if (appModel == null)
            {
                throw new BadRequestException("Invalid App ID");
            }

            var appBiz = IocContainer.Resolve<IAppBusinessEntity>();
            // Check app status
            if (!appBiz.IsAppEnable(appModel))
            {
                throw new ForbiddenException("App is disabled.");
            }
        }

     
        /// <summary>
        /// Check whether the inernal Access key is valid.
        /// </summary>
        /// <param name="accessKey">The access key for validation.</param>
        /// <returns>return true if valid, return false if invalid.</returns>
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

        private AccelaAccessTokenModel GetValidatedToken(string currentRequestedScope, AccelaAccessTokenModel accessTokenModel)
        {
            AccelaAccessTokenModel result = null;

            if (!String.IsNullOrWhiteSpace(currentRequestedScope) && accessTokenModel != null)
            {
                var scopesInToken = accessTokenModel != null && accessTokenModel.Scope != null ? accessTokenModel.Scope.ToArray() : null;
                var scopeValidationRequest = scopesInToken != null && scopesInToken.Length > 0 ?
                        new IsValidScopeRequest()
                        {
                            RequestScope = currentRequestedScope,
                            ScopesInToken = scopesInToken
                        } : null;
                var scopeBusinessEntity = IocContainer.Resolve<IScopeBusinessEntity>();
                bool isScopeAuthed = scopeValidationRequest != null ? scopeBusinessEntity.IsValidScope(scopeValidationRequest) : false;
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

        private AccelaAccessTokenModel ParseTokenAndValidataScope(string currentRequestedScope, string accessTokenString, ref WSErrorResponse unauthedResponse)
        {
            if (string.IsNullOrEmpty(accessTokenString))
            {
                var logData = new LogEntity
                {
                    Message = "Token is required",
                    Detail = "parameter token is null.",
                    MethodName = "SecurityAccessHandler.ValidateToken()"
                };
                Log.Error(logData);
                unauthedResponse = new WSErrorResponse(HttpStatusCode.Unauthorized, ErrorCodes.no_token_401, "Token is required.", null, null);
                return null;
            }

            var accessTokenModel = GetValidatedToken(currentRequestedScope, accessTokenString);

            //check scope
            if (accessTokenModel == null)
            {
                var errorMessage = MESSAGE_NO_MATCHED_SCOPE_IN_TOKEN;
                var errorMessageMore = String.Format(MESSAGE_MORE_NO_MATCHED_SCOPE_IN_TOKEN, currentRequestedScope);
                unauthedResponse = new WSErrorResponse(HttpStatusCode.Forbidden, ErrorCodes.forbidden_403, errorMessage, errorMessageMore, null);
            }

            return accessTokenModel;
        }

        private void WriteLog(WSErrorResponse error)
        {
            if (error != null)
            {
                string more = null;
                try
                {
                    more = Accela.Apps.Shared.JsonConverter.ToJson(error);
                }
                catch (Exception ex)
                {
                    more = error.More;
                }

                var logData = new LogEntity
                {
                    TraceId = error.TraceId,
                    Message = error.Message,
                    Detail = error.More,
                    MethodName = "SecurityAccessHandler"
                };

                if(error.Status == (int)HttpStatusCode.InternalServerError)
                {
                    Log.Error(logData);
                }
                else
                {
                    Log.Warn(logData);
                }
            }
        }
    }
}
