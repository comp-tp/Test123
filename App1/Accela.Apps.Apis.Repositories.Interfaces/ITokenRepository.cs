using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    /// <summary>
    /// Token repository interface.
    /// </summary>
    public interface ITokenRepository
    {
        /// <summary>
        /// Add token.
        /// </summary>
        /// <param name="tokenModel">Token model.</param>
        /// <returns>Token.</returns>
        TokenModel Add(TokenModel tokenModel);

        /// <summary>
        /// Update cloud token.
        /// </summary>
        /// <param name="updatedToken">token model to be updated</param>
        /// <returns></returns>
        TokenModel UpdateCloudToken(TokenModel updatedToken);

        /// <summary>
        /// Get token by cloud user.
        /// </summary>
        /// <param name="cloudUserId">cloud user id.</param>
        /// <param name="appID">app id.</param>
        /// <param name="environment">environment name.</param>
        /// <returns>TokenModel.</returns>
        TokenModel GetToken(Guid cloudUserId, string appID, string environment);

        /// <summary>
        /// Get token.
        /// </summary>
        /// <param name="cloudToken">Cloud token.</param>
        /// <returns>Token model.</returns>
        TokenModel GetToken(string cloudToken);

        /// <summary>
        /// Get Social token by cloud token.
        /// </summary>
        /// <param name="cloudToken">cloud token.</param>
        /// <returns>Social Token, reurn null if the cloud token is not existed.</returns>
        List<LinkedSocialAccountModel> GetSocaialToken(Guid cloudUserID, string provider,string socialId = null);

        void UpdateSocialToken(Guid cloudUserID, string provider, string socialID, string newSocialToke, int expiredTimeInMins = 30);


        /// <summary>
        /// Get Token by Appid
        /// The logic as below:
        /// if the token didn't exist, then create one tokem, else return the token
        /// My concern: above logic should be move to businessEntities:(
        /// </summary>
        /// <param name="appId">app id</param>
        /// <returns>return token</returns>
        string GetAppTokenByAppId(string appId);

        /// <summary>
        /// Get Apptoken data model by token
        /// if the token object exist, then return the token, else return null
        /// </summary>
        /// <param name="Token">app token</param>
        /// <returns>if the token object exist, then return the token, else return null</returns>
        AppTokenModel GetAppTokenByToken(string Token);


        ///// <summary>
        ///// Get token according to social account and app.
        ///// </summary>
        ///// <returns>TokenModel</returns>
        //TokenModel GetToken(string socialID, string socialProvider, string appID, string environment);

        void DeleteToken(string token);
    }
}
