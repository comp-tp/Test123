using Accela.Core.Configurations;

using Accela.Apps.Shared.Cache;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.Utils;
using Accela.Apps.User.WSModels.V2.Auth;
using Accela.Infrastructure.Configurations;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.User.WSModels.V4;
using System.Collections.Generic;
using Accela.Apps.Shared.Contants;

namespace Accela.Apps.Apis.Services.Handlers.Helpers
{
    /// <summary>
    /// Biz Token Type
    /// </summary>
    public enum BizTokenType
    {
        Unknown,
        Agency,
        CitizenRegisteredUser,
        CitizenAnonymous
    }

    /// <summary>
    /// Biz Token Cache Model
    /// </summary>
    [Serializable]
    [DataContract(Name = "bizTokenCacheModel")]
    public class BizTokenCacheModel
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "expiredDateTime")]
        public DateTime ExpiredDateTime { get; set; }
    }

    /// <summary>
    /// Biz Token Model
    /// </summary>
    [Serializable]
    [DataContract(Name = "bizTokenModel")]
    public class BizTokenModel
    {
        [DataMember(Name = "tokenType")]
        public BizTokenType TokenType { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "expiredDateTime")]
        public DateTime ExpiredDateTime { get; set; }
    }

    /// ToDo: All biz token related logic need to move to user client package later instead of bizTokenHelper here.
    /// <summary>
    /// biz token helper
    /// </summary>
    public static class BizTokenHelper
    {
        const int EXPIRES_IN_MINUTES_FOR_AGENCY_TOKEN = 120;
        const int EXPIRES_IN_MINUTES_FOR_CITIZEN_TOKEN = 120;
        const int EXPIRES_IN_MINUTES_FOR_ANONYMOUS_TOKEN = 120;

        private static IConfigurationReader ConfigurationReader { get { return ConfigurationSettingsManager.Get(); } }

        /// <summary>
        /// get register agency user token
        /// </summary>
        /// <returns>registered agency user token model</returns>
        public static BizTokenModel GetRegisteredAgencyUserToken(string cloudUserId, string agencyName, string userName, string environment, IAgencyAppContext context)
        {
            if (String.IsNullOrWhiteSpace(cloudUserId))
            {
                throw new ArgumentException("cloudUserId cannot be empty.");
            }

            if (String.IsNullOrWhiteSpace(agencyName))
            {
                throw new ArgumentException("agencyName cannot be empty.");
            }

            if (String.IsNullOrWhiteSpace(environment))
            {
                throw new ArgumentException("environment cannot be empty.");
            }

            if(string.IsNullOrEmpty(userName))
            {
                userName = GetAAorACAUserName(context);
            }

            var bizTokenCacheModel = GetRegisteredAgencyUserTokenByCacheOrApi(cloudUserId, agencyName, userName, environment, context);

            var result = bizTokenCacheModel != null ? new BizTokenModel()
            {
                TokenType = BizTokenType.Agency,
                Token = bizTokenCacheModel.Token,
                ExpiredDateTime = bizTokenCacheModel.ExpiredDateTime
            } : null;

            return result;
        }

        /// <summary>
        /// get registered citizen user token
        /// </summary>
        /// <param name="cloudUserId">cloud user id</param>
        /// <param name="agencyName">agency name</param>
        /// <param name="environment">environment name</param>
        /// <param name="autoRegister">auto-register flag, true: auto-register, otherwise not to auto-register citizen user.</param>
        /// <param name="context"></param>
        /// <returns>registered citizen user token model</returns>
        public static BizTokenModel GetRegisteredCitizenUserToken(string cloudUserId, string agencyName, string userName, string environment, bool autoRegister, IAgencyAppContext context)
        {
            if (String.IsNullOrWhiteSpace(cloudUserId))
            {
                throw new ArgumentException("cloudUserId cannot be empty.");
            }

            if (String.IsNullOrWhiteSpace(agencyName))
            {
                throw new ArgumentException("agencyName cannot be empty.");
            }

            if (String.IsNullOrWhiteSpace(environment))
            {
                throw new ArgumentException("environment cannot be empty.");
            }

            BizTokenModel result = null;

            if (string.IsNullOrEmpty(userName))
            {
                userName = GetAAorACAUserName(context);
            }

            // if failed to auto-create ACA account, then return ACA anonymous token when flag autoRegister is true
            try
            {
                var bizTokenCacheModel = GetRegisteredCitizenUserTokenByCacheOrApi(cloudUserId, agencyName, userName, environment, autoRegister, context);

                result = bizTokenCacheModel != null ? new BizTokenModel()
                {
                    TokenType = BizTokenType.CitizenRegisteredUser,
                    Token = bizTokenCacheModel.Token,
                    ExpiredDateTime = bizTokenCacheModel.ExpiredDateTime
                } : null;
            }
            catch (MobileException ex)
            {
                var failedToAutoCreateACAAccount = ex.ErrorCode == ErrorCodes.unauthorized_401
                    || ex.ErrorCode == ErrorCodes.create_aca_user_failed_500
                    || ex.ErrorCode == ErrorCodes.require_mannual_link_account_401;
                var noReturnedToken = result == null || String.IsNullOrWhiteSpace(result.Token);

                if (autoRegister && failedToAutoCreateACAAccount && noReturnedToken)
                {
                    var bizTokenCacheModel = GetAnonymousUserTokenByCacheOrApi(agencyName, environment, autoRegister, context);
                    result = bizTokenCacheModel != null ? new BizTokenModel()
                    {
                        TokenType = BizTokenType.CitizenAnonymous,
                        Token = bizTokenCacheModel.Token,
                        ExpiredDateTime = bizTokenCacheModel.ExpiredDateTime
                    } : null;
                }
                else
                {
                    throw ex;
                }
            }

            return result;
        }

        /// <summary>
        /// get anonymous user token
        /// </summary>
        /// <param name="agencyName">agency name</param>
        /// <param name="environment">environment name</param>
        /// <param name="forceToRefresh">force to refresh</param>
        /// <param name="context"></param>
        /// <returns>anonymous user token</returns>
        public static BizTokenModel GetAnonymousUserToken(string agencyName, string environment, bool forceToRefresh, IAgencyAppContext context)
        {
            if (String.IsNullOrWhiteSpace(agencyName))
            {
                throw new ArgumentException("agencyName cannot be empty.");
            }

            if (String.IsNullOrWhiteSpace(environment))
            {
                throw new ArgumentException("environment cannot be empty.");
            }

            var bizTokenCacheModel = GetAnonymousUserTokenByCacheOrApi(agencyName, environment, forceToRefresh, context);

            var result = bizTokenCacheModel != null ? new BizTokenModel()
            {
                TokenType = BizTokenType.CitizenAnonymous,
                Token = bizTokenCacheModel.Token,
                ExpiredDateTime = bizTokenCacheModel.ExpiredDateTime
            } : null;

            return result;
        }

        private static BizTokenCacheModel GetRegisteredAgencyUserTokenByCacheOrApi(string cloudUserId, string agencyName, string userName, string environment, IAgencyAppContext context)
        {
            var cacheKey = BuildCacheKey(AccountType.AA.ToString(), agencyName, environment, cloudUserId, userName);

            var result = CacheHelper.GetCache<BizTokenCacheModel>(cacheKey, false);

            if (result == null || String.IsNullOrWhiteSpace(result.Token) || result.ExpiredDateTime < DateTime.UtcNow)
            {
                result = GetRegisteredAgencyUserTokenByApi(cloudUserId, agencyName, userName, environment, context);
                CacheHelper.InsertCache<BizTokenCacheModel>(cacheKey, result, EXPIRES_IN_MINUTES_FOR_AGENCY_TOKEN);
            }

            return result;
        }

        private static BizTokenCacheModel GetRegisteredAgencyUserTokenByApi(string cloudUserId, string agencyName, string userName, string environement, IAgencyAppContext context)
        {
            var client = new InternalAPIClient(context);
            var apiUrl = ConfigurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = UrlHelper.CombinePath(apiUrl, "aaauth/aausertoken");
            var request = new WSAATokenRequest()
            {
                CloudUserId = cloudUserId,
                AgencyName = agencyName,
                UserName = userName,
                Environment = environement
            };

            var tempResult = client.Execute<WSAATokenResponse>(requestUrl, request, RestSharp.Method.POST);
            var result = tempResult == null ? null : new BizTokenCacheModel()
            {
                Token = tempResult.Token,
                ExpiredDateTime = tempResult.ExpiresIn == 0 ? DateTime.UtcNow.AddYears(1) : DateTime.UtcNow.AddSeconds(tempResult.ExpiresIn)
            };
            return result;
        }

        private static BizTokenCacheModel GetRegisteredCitizenUserTokenByCacheOrApi(string cloudUserId, string agencyName, string userName, string environment, bool autoRegister, IAgencyAppContext context)
        {
            var cacheKey = BuildCacheKey(AccountType.ACA.ToString(), agencyName, environment, cloudUserId, userName);
            var result = CacheHelper.GetCache<BizTokenCacheModel>(cacheKey, false);

            if (result == null || String.IsNullOrWhiteSpace(result.Token) || result.ExpiredDateTime < DateTime.UtcNow)
            {
                result = GetRegisteredCitizenUserTokenByApi(cloudUserId, agencyName, userName, environment, autoRegister, context);
                CacheHelper.InsertCache<BizTokenCacheModel>(cacheKey, result, EXPIRES_IN_MINUTES_FOR_CITIZEN_TOKEN);
            }

            return result;
        }

        private static BizTokenCacheModel GetRegisteredCitizenUserTokenByApi(string cloudUserId, string agencyName, string userName, string environement, bool autoRegister, IAgencyAppContext context)
        {
            var client = new InternalAPIClient(context);
            var apiUrl = ConfigurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = UrlHelper.CombinePath(apiUrl, "aaauth/acausertoken");
            var request = new WSAATokenRequest()
            {
                CloudUserId = cloudUserId,
                AgencyName = agencyName,
                UserName = userName,
                Environment = environement,
                AutoRegister = autoRegister
            };

            var tempResult = client.Execute<WSAATokenResponse>(requestUrl, request, RestSharp.Method.POST);
            var result = tempResult == null ? null : new BizTokenCacheModel()
            {
                Token = tempResult.Token,
                ExpiredDateTime = tempResult.ExpiresIn == 0 ? DateTime.UtcNow.AddYears(1) : DateTime.UtcNow.AddSeconds(tempResult.ExpiresIn)
            };
            return result;
        }

        private static BizTokenCacheModel GetAnonymousUserTokenByCacheOrApi(string agencyName, string environment, bool forceToRefresh, IAgencyAppContext context)
        {
            var cacheKey = BuildCacheKey(AccountType.ACA.ToString(), agencyName, environment, Guid.Empty.ToString(), Constant.ACA_ANONYMOUS);
            //CacheKeys.BuildCacheKey(CacheKeys.BIZ_ANONYMOUS_TOKEN_BY_AGENCY_ENV_CLOUDUSER, agencyName, environment);
            var result = !forceToRefresh ? CacheHelper.GetCache<BizTokenCacheModel>(cacheKey) : null;

            if (result == null || String.IsNullOrWhiteSpace(result.Token) || result.ExpiredDateTime < DateTime.UtcNow)
            {
                result = GetAnonymousUserTokenByApi(agencyName, environment, forceToRefresh, context);
                CacheHelper.InsertCache<BizTokenCacheModel>(cacheKey, result, EXPIRES_IN_MINUTES_FOR_ANONYMOUS_TOKEN);
            }

            return result;
        }

        private static BizTokenCacheModel GetAnonymousUserTokenByApi(string agencyName, string environment, bool forceToRefresh, IAgencyAppContext context)
        {
            var client = new InternalAPIClient(context);
            var apiUrl = ConfigurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = UrlHelper.CombinePath(apiUrl, "/aaauth/acaanonymoustoken");

            var request = new WSACAAnonymousTokenRequest();
            request.AgencyName = agencyName;
            request.EnvironmentName = environment;
            request.ForceToRefresh = forceToRefresh;
            var tempResult = client.Execute<WSAATokenResponse>(requestUrl, request, RestSharp.Method.POST);
            var result = tempResult == null ? null : new BizTokenCacheModel()
            {
                Token = tempResult.Token,
                ExpiredDateTime = tempResult.ExpiresIn == 0 ? DateTime.UtcNow.AddYears(1) : DateTime.UtcNow.AddSeconds(tempResult.ExpiresIn)
            };
            return result;
        }

        /// <summary>
        /// This is not final solution to take the first user as default (production exists same problem) , just a quick workaround for construct 3.5.0 release.
        /// we need to think this more and get a correct solution later.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string GetAAorACAUserName(IAgencyAppContext context)
        {
            string AAorACA = context.AppType == AppType.Agency ? AccountType.AA.ToString() : AccountType.ACA.ToString();
            string subsystemBaseUrl = ConfigurationReader.Get("Ref_InternalAPI_User").Split(new string[] { "/apis/" }, StringSplitOptions.None)[0];
            var resourceUri = UrlHelper.CombinePath(subsystemBaseUrl,
                string.Format("/apis/v4/civicId/accounts/{0}/{1}/userNames/first", AAorACA, context.Agency));

            var cacheKey = BuildCacheKey(AAorACA, context.Agency, context.EnvName, context.CivicId);

            var result = CacheHelper.GetCache<string>(cacheKey, true);

            if (string.IsNullOrEmpty(result))
            {
                var client = new InternalAPIClient(context);
                var response = client.Execute<GenericResultResponse<string>>(resourceUri);

                if (response != null && !string.IsNullOrEmpty(response.Result))
                {
                    result = response.Result;
                    CacheHelper.InsertCache<string>(cacheKey, response.Result, EXPIRES_IN_MINUTES_FOR_AGENCY_TOKEN);
                }
            }

            return result;
        }

        private static string BuildCacheKey(string AAorACA, string agencyName, string envName, string cloudUserId, string userName = null)
        {
            if(string.IsNullOrEmpty(userName))
            {
                return "civicid_username_" + CacheKeys.BuildCacheKey(String.Format("{0}&{1}&{2}", AAorACA, agencyName, envName), cloudUserId);
            }
            else
            {
                return "biztoken_" + CacheKeys.BuildCacheKey(String.Format("{0}&{1}&{2}", AAorACA, agencyName, envName), cloudUserId, userName);
            }
            
        }
    }
}
