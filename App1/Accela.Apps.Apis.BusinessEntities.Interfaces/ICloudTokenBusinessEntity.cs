using System;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public enum LoginType
    {
        CivicAccount = 0,
        CivicAnonymous = 1,
        AutomationAccount = 2
    }

    /// <summary>
    /// Cloud token business entity interface.
    /// </summary>
    public interface ICloudTokenBusinessEntity
    {

        /// <summary>
        /// Generate agency auth token.
        /// </summary>
        /// <param name="loginName">Login name.</param>
        /// <param name="password">Password.</param>
        /// <param name="agency">Agency</param>
        /// <param name="authType">AuthType</param>        
        /// <returns>Token.</returns>
        string LinkAAorACAAuthecticate(string loginName, string password, string agency, string authType);

        /// <summary>
        /// Only citizen app is supported.
        /// </summary>
        /// <param name="socialLinkID">Civic id links to social id(FB,Twitter etc)</param>
        /// <param name="appID">app id</param>
        /// <param name="agency">agency name</param>
        /// <param name="environment">environment.</param>
        /// <returns></returns>
        AuthenticateUserResponse GenerateCivicAuthToken(Guid cloudUserID, string appID, string agency, string environment);
      
        /// <summary>
        /// Get token.
        /// </summary>
        /// <param name="socialLinkId">Social link id.</param>
        /// <param name="appId">App id.</param>
        /// <param name="environment">Environment</param>
        /// <returns>Token.</returns>
        //string GetToken(Guid socialLinkId, string appId, string environment = null);

        /// <summary>
        /// Get anonymous cloud user token.
        /// </summary>
        /// <param name="appID">app id.</param>
        /// <returns>AuthenticateUserResponse with token.</returns>
        AuthenticateUserResponse GenerateAnonymousToken(string appID);

        /// <summary>
        /// Logs in the user. Upon successful login; generates the Token string.
        /// </summary>
        /// <param name="authRequest">The object include all login information</param>
        /// <param name="isCivicIdLogin">Indicates whether uses civic id login.</param>
        /// <returns>Logs in the user. Upon successful login; return the Token string</returns>
        AuthenticateUserResponse GenerateAgencyAuthToken(AuthenticateUserRequest authRequest);

        /// <summary>
        /// Checks whether the token is valid or not.
        /// </summary>
        /// <param name="token">the token for mobile client and mobile server communication.</param>
        /// <returns>return user identity name if token is valid, otherwise return null.</returns>
        TokenModel ValidateToken(string token);

        /// <summary>
        /// Create cloud token.
        /// </summary>
        /// <param name="addTokenModel">Token model.</param>
        /// <returns>Token.</returns>
        string CreateToken(TokenModel addTokenModel);

        /// <summary>
        /// Generate App token
        /// The logic in the method as below:
        /// 1. The the app id is avaible
        /// 2. Get token by the app id
        /// 3. if the token not exist, generate app token
        /// here we may not process multiple thread case. it will may cause one app id response to two token. 
        /// according to analyze, it may not effect usage. 
        /// </summary>
        /// <param name="appId">Passed AppId</param>
        /// <returns>return generated token</returns>
        AuthenticateUserResponse GenerateAppToken(string appId);

        /// <summary>
        /// check whether the token is valid or not.
        /// </summary>
        /// <param name="token">the token for mobile client and mobile server communication.</param>
        /// <returns>true/false.</returns>
        bool ValidateAgencyToken(string token);

        /// <summary>
        /// The method logic as below:
        /// 1. Get app token by token from source. if the app token exist, then return true
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>if successful, return true, else return false</returns>
        bool ValidateAppToken(string token);

        ///// <summary>
        ///// Get Social token by cloud token.
        ///// </summary>
        ///// <param name="cloudToken">cloud token.</param>
        ///// <returns>Social Token.</returns>
        //string GetSocialTokenByCloudToken(string cloudToken);

        /// <summary>
        /// delete the token from DB
        /// </summary>
        /// <param name="token"></param>
        void DeleteToken(string token);
    }
}
