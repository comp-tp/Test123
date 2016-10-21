using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared.OAuth;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface ILinkedSocialAccountsBusinessEntity
    {
        /// <summary>
        /// Gets the account by social id.
        /// </summary>
        /// <param name="socialId">The social id.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>LinkedSocialAccountModel</returns>
        LinkedSocialAccountModel GetAccountBySocialId(string socialId, string provider);

        /// <summary>
        /// Gets the account by social email.
        /// </summary>
        /// <param name="socialEmail">The social email.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>the account by social email.</returns>
        LinkedSocialAccountModel GetAccountBySocialEmail(string socialEmail, string provider);

        /// <summary>
        /// Get linked social account.
        /// </summary>
        /// <param name="cloudUserId">Cloud user id.</param>
        /// <param name="socialProvider">Social provider.</param>
        /// <returns>Linked social account model.</returns>
        LinkedSocialAccountModel GetLinkedSocialAccount(Guid cloudUserId, string socialProvider);

        /// <summary>
        /// Tries linking social account.
        /// </summary>
        /// <param name="currentUserModel">The current user model.</param>
        /// <param name="oAuthUserProfileModel">The o auth user profile model.</param>
        /// <returns>LinkedSocialAccountModel</returns>
        LinkedSocialAccountModel TryLinkSocialAccount(CloudUserModel currentUserModel, OAuthUserProfile oAuthUserProfileModel);

        /// <summary>
        /// Add linked social account.
        /// </summary>
        /// <param name="linkedSocialAccountModel">Linked social account model.</param>
        /// <returns>LinkedSocialAccountModel.</returns>
        LinkedSocialAccountModel Add(LinkedSocialAccountModel linkedSocialAccountModel);

        /// <summary>
        /// Link AA account with cloud user.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="socialToken">AA token.</param>
        /// <param name="logonModel">logonModel for relogin.</param>
        void LinkToAAAccount(Guid cloudUserID, string socialToken, AALogonModel logonModel);

        /// <summary>
        /// Link ACA account with cloud user.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="socialToken">ACA token.</param>
        /// <param name="logonModel">logonModel for relogin.</param>
        void LinkToACAAccount(Guid cloudUserID, string socialToken, AALogonModel logonModel);

        /// <summary>
        /// Remove AA Social Link.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="agency">agency name.</param>
        void RemoveAASocialLink(Guid cloudUserID, string agency);

        /// <summary>
        /// Remove ACA Social Link.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="agency">agency name.</param>
        void RemoveACASocialLink(Guid cloudUserID, string agency);

        /// <summary>
        /// Get all linked to AA accounts.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <returns>AALogonModel list.</returns>
        IList<AALogonModel> GetAALinkedAccounts(Guid cloudUserID);

        /// <summary>
        /// Get all linked to AA accounts.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <returns>AALogonModel list.</returns>
        IList<AALogonModel> GetACALinkedAccounts(Guid cloudUserID);
    }
}
