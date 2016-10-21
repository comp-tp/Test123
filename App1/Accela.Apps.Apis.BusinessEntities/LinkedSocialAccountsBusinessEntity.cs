using System;
using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.OAuth;
using Accela.Apps.Shared.Toolkits.Encrypt;

namespace Accela.Apps.Apis.BusinessEntities
{
    /// <summary>
    /// Linked social accounts business entity class.
    /// </summary>
    public class LinkedSocialAccountsBusinessEntity : BusinessEntityBase, ILinkedSocialAccountsBusinessEntity
    {
        private ILinkedSocialAccountsRepository _socialLinkRepository = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public LinkedSocialAccountsBusinessEntity()
        {
            _socialLinkRepository = IocContainer.Resolve<ILinkedSocialAccountsRepository>();
        }

        /// <summary>
        /// Gets the account by social id.
        /// </summary>
        /// <param name="socialId">The social id.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// LinkedSocialAccountModel
        /// </returns>
        public LinkedSocialAccountModel GetAccountBySocialId(string socialId, string provider)
        {
            return _socialLinkRepository.GetAccountBySocialId(socialId, provider);
        }

        /// <summary>
        /// Gets the account by social email.
        /// </summary>
        /// <param name="socialEmail">The social email.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>the account by social email.</returns>
        public LinkedSocialAccountModel GetAccountBySocialEmail(string socialEmail, string provider)
        {
            return _socialLinkRepository.GetAccountBySocialEmail(socialEmail, provider);
        }

        /// <summary>
        /// Get linked social account.
        /// </summary>
        /// <param name="cloudUserId">Cloud user id.</param>
        /// <param name="socialProvider">Social provider.</param>
        /// <returns>Linked social account model.</returns>
        public LinkedSocialAccountModel GetLinkedSocialAccount(Guid cloudUserId, string socialProvider)
        {
            LinkedSocialAccountModel result = null;
            var socialAccounts = _socialLinkRepository.GetSocialAccounts(cloudUserId, socialProvider);
            if (socialAccounts != null && socialAccounts.Count > 0)
            {
                result = socialAccounts[0];
            }

            return result;
        }

        /// <summary>
        /// Tries linking social account.
        /// </summary>
        /// <param name="currentUserModel">The current user model.</param>
        /// <param name="oAuthUserProfileModel">The o auth user profile model.</param>
        /// <returns>
        /// LinkedSocialAccountModel
        /// </returns>
        public LinkedSocialAccountModel TryLinkSocialAccount(CloudUserModel currentUserModel, OAuthUserProfile oAuthUserProfileModel)
        {
            if (oAuthUserProfileModel == null || String.IsNullOrWhiteSpace(oAuthUserProfileModel.Id))
            {
                throw new Exception("Invalid Parameter for linking social account.");
            }

            var currentUserId = currentUserModel != null ? currentUserModel.Id : Guid.Empty;

            //check existing social account
            var existingSocialAccount = CheckAndGetExistingSocialAccount(currentUserId, oAuthUserProfileModel.Id, oAuthUserProfileModel.Email, oAuthUserProfileModel.OAuthProvider.ToString());

            //check if social emial belongs to another Civic ID

            CloudUserModel cloudUserByEmail = null;

            if (!String.IsNullOrWhiteSpace(oAuthUserProfileModel.Email))
            {
                var cloudUserBusinessEntity = IocContainer.Resolve<ICloudUserBusinessEntity>();
                cloudUserByEmail = cloudUserBusinessEntity.GetCloudUserByLoginName(oAuthUserProfileModel.Email);
            }

            if (cloudUserByEmail != null && currentUserId == Guid.Empty)
            {
                currentUserId = cloudUserByEmail != null ? cloudUserByEmail.Id : currentUserId;
            }

            var hasLinkedSocialAccount = existingSocialAccount != null && existingSocialAccount.Id != Guid.Empty;

            //if has linked social account, return it.
            if (hasLinkedSocialAccount)
            {
                return existingSocialAccount;
            }

            if (currentUserId == Guid.Empty && String.IsNullOrWhiteSpace(oAuthUserProfileModel.Email))
            {
                return null;
            }

            if (currentUserId == Guid.Empty)
            {
                //add new cloud user
                var newCloudUserModel = CreateCloudUserForSocialAccount(oAuthUserProfileModel.FirstName, oAuthUserProfileModel.LastName, oAuthUserProfileModel.ScreenName, oAuthUserProfileModel.Email);
                currentUserId = newCloudUserModel != null ? newCloudUserModel.Id : currentUserId;
            }

            //create new social account
            var newSocialAccount = CreateSocialAccount(currentUserId, oAuthUserProfileModel.ScreenName, oAuthUserProfileModel.Email, oAuthUserProfileModel.Id, oAuthUserProfileModel.OAuthProvider.ToString());
            return newSocialAccount;
        }

        /// <summary>
        /// Add linked social account.
        /// </summary>
        /// <param name="linkedSocialAccountModel">Linked social account model.</param>
        /// <returns>LinkedSocialAccountModel.</returns>
        public LinkedSocialAccountModel Add(LinkedSocialAccountModel linkedSocialAccountModel)
        {
            return _socialLinkRepository.Save(linkedSocialAccountModel);
        }

        /// <summary>
        /// Link AA account with cloud user.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="socialToken">AA token.</param>
        /// <param name="logonModel">logonModel for relogin.</param>
        public void LinkToAAAccount(Guid cloudUserID, string socialToken, AALogonModel logonModel)
        {
            if (String.IsNullOrWhiteSpace(socialToken)
                || logonModel == null
                || String.IsNullOrWhiteSpace(logonModel.Agency)
                || String.IsNullOrWhiteSpace(logonModel.LoginName)
                || String.IsNullOrWhiteSpace(logonModel.Password))
            {
                throw new MobileException("Parameter can't be null");
            }

            string provider = String.Format("{0}-{1}", OAuthProvider.AA.ToString(), logonModel.Agency);

            LinkToAAorACAAccount(cloudUserID, socialToken, logonModel,provider);
        }

        /// <summary>
        /// Link ACA account with cloud user.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="socialToken">ACA token.</param>
        /// <param name="logonModel">logonModel for relogin.</param>
        public void LinkToACAAccount(Guid cloudUserID, string socialToken, AALogonModel logonModel)
        {
            if (String.IsNullOrWhiteSpace(socialToken)
                || logonModel == null
                || String.IsNullOrWhiteSpace(logonModel.Agency)
                || String.IsNullOrWhiteSpace(logonModel.LoginName)
                || String.IsNullOrWhiteSpace(logonModel.Password))
            {
                throw new MobileException("Parameter can't be null");
            }

            string provider = String.Format("{0}-{1}", OAuthProvider.ACA.ToString(), logonModel.Agency);

            LinkToAAorACAAccount(cloudUserID, socialToken, logonModel, provider);
        }

        /// <summary>
        /// Remove AA Social Link.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="userName">AA user name.</param>
        /// <param name="agency">agency name.</param>
        public void RemoveAASocialLink(Guid cloudUserID, string agency)
        {
            if (String.IsNullOrWhiteSpace(agency))
            {
                throw new MobileException("agency can't be null.");
            }

            string provider = String.Format("{0}-{1}", OAuthProvider.AA.ToString(), agency);
            _socialLinkRepository.Unlink(cloudUserID, agency);
        }

        /// <summary>
        /// Remove ACA Social Link.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="userName">ACA user name.</param>
        /// <param name="agency">agency name.</param>
        public void RemoveACASocialLink(Guid cloudUserID, string agency)
        {
            if (String.IsNullOrWhiteSpace(agency))
            {
                throw new MobileException("agency can't be null.");
            }

            string provider = String.Format("{0}-{1}", OAuthProvider.ACA.ToString(), agency);
            _socialLinkRepository.Unlink(cloudUserID, agency);
        }

        /// <summary>
        /// Get all linked to AA accounts.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <returns>AALogonModel list.</returns>
        public IList<AALogonModel> GetAALinkedAccounts(Guid cloudUserID)
        {
            return GetAAorACALinkedAccounts(cloudUserID, OAuthProvider.AA);
        }

        /// <summary>
        /// Get all linked to ACA accounts.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <returns>AALogonModel list.</returns>
        public IList<AALogonModel> GetACALinkedAccounts(Guid cloudUserID)
        {
            return GetAAorACALinkedAccounts(cloudUserID, OAuthProvider.ACA);
        }

        /// <summary>
        /// Get all linked to ACA accounts.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <returns>AALogonModel list.</returns>
        private IList<AALogonModel> GetAAorACALinkedAccounts(Guid cloudUserID, OAuthProvider AAorACA)
        {
            var socialAccounts = _socialLinkRepository.GetAAorACASocialAccounts(cloudUserID, AAorACA.ToString());
            IList<AALogonModel> result = new List<AALogonModel>();

            if (socialAccounts != null)
            {
                foreach (var item in socialAccounts)
                {
                    var tmp = new AALogonModel()
                    {
                        Agency = GetAgencyFromSocialProvider(item.SocialProvider),
                        LoginName = item.SocialId
                    };
                }
            }

            return result;
        }

        /// <summary>
        /// Get agency from social provider name.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        private string GetAgencyFromSocialProvider(string provider)
        {
            return provider.Substring(provider.IndexOf("-") + 1);
        }
        /// <summary>
        /// Link AA account with cloud user.
        /// </summary>
        /// <param name="cloudUserID">cloud user id.</param>
        /// <param name="socialToken">AA token.</param>
        /// <param name="logonModel">logonModel for relogin.</param>
        private void LinkToAAorACAAccount(Guid cloudUserID, string socialToken, AALogonModel logonModel,string provider)
        {
            LinkedSocialAccountModel addedModel = new LinkedSocialAccountModel()
            {
                CloudUserId = cloudUserID,
                SocialProvider = provider,
                SocialId = logonModel.LoginName,
                SocialToken = socialToken,
                Data = GetTokenData(logonModel),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = cloudUserID.ToString(),
                LastUpdatedDate = DateTime.UtcNow,
                LastUpdatedBy = cloudUserID.ToString(),
                SocialAccountOrder = 0,
                TokenExpired = DateTime.UtcNow.AddMinutes(30)
            };

            _socialLinkRepository.Save(addedModel);
        }

        /// <summary>
        /// Get token data.
        /// </summary>
        /// <param name="logonModel">AALogonModel.</param>
        /// <returns>Social Token Data.</returns>
        private string GetTokenData(AALogonModel logonModel)
        {
            AALogonModel reloginData = new AALogonModel()
            {
                Agency = logonModel.Agency,
                LoginName = logonModel.LoginName,
                Password = DESHelper.Encrypt(logonModel.Password)
            };
            string tokenData = JsonConverter.ToJson(reloginData);

            return tokenData;
        }

        private LinkedSocialAccountModel CreateSocialAccount(Guid userId, string fullName, string socialEmail, string socialId, string oAuthProvider)
        {
            if (userId == Guid.Empty || String.IsNullOrWhiteSpace(socialEmail) || String.IsNullOrWhiteSpace(socialId) || String.IsNullOrWhiteSpace(oAuthProvider))
            {
                throw new Exception("Invalid Parameter for creating social account.");
            }

            var linkedSocialAccountModel = new LinkedSocialAccountModel()
            {
                CloudUserId = userId,
                CreatedBy = fullName,
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = fullName,
                LastUpdatedDate = DateTime.UtcNow,
                SocialEmail = socialEmail,
                SocialId = socialId,
                SocialProvider = oAuthProvider
            };

            var result = Add(linkedSocialAccountModel);
            return result;
        }

        private CloudUserModel CreateCloudUserForSocialAccount(string firstName, string lastName, string fullName, string userEmail)
        {
            if (String.IsNullOrWhiteSpace(userEmail))
            {
                throw new Exception("Invalid Parameter for creating cloud user for social account.");
            }

            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName) && !String.IsNullOrWhiteSpace(fullName))
            {
                var nameArray = fullName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                firstName = nameArray != null && nameArray.Length >= 2 ? nameArray[0] : fullName;
                lastName = nameArray != null && nameArray.Length >= 2 ? nameArray[nameArray.Length - 1] : String.Empty;
            }

            var userModel = new CloudUserModel()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = userEmail,
                Password = MD5Helper.GetMd5Hash(Guid.NewGuid().ToString()),
                CreatedBy = userEmail,
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = userEmail,
                LastUpdatedDate = DateTime.UtcNow
            };

            var cloudUserBusinessEntity = IocContainer.Resolve<ICloudUserBusinessEntity>();
            cloudUserBusinessEntity.Add(userModel);
            var result = cloudUserBusinessEntity.GetCloudUserByLoginName(userEmail);
            return result;
        }

        private LinkedSocialAccountModel CheckAndGetExistingSocialAccount(Guid cloudUserId, string socialId, string socialEmail, string oauthProvider)
        {
            if (String.IsNullOrWhiteSpace(socialId) || String.IsNullOrWhiteSpace(oauthProvider))
            {
                throw new Exception("Invalid Parameter for linking social account.");
            }

            LinkedSocialAccountModel result = null;

            var linkedSocialAccountModel = this.GetAccountBySocialId(socialId, oauthProvider);

            if (linkedSocialAccountModel == null && !String.IsNullOrWhiteSpace(socialEmail))
            {
                linkedSocialAccountModel = this.GetAccountBySocialEmail(socialEmail, oauthProvider);
            }

            if (linkedSocialAccountModel != null)
            {
                var linkedByAnother = cloudUserId != Guid.Empty && linkedSocialAccountModel.CloudUserId != Guid.Empty && linkedSocialAccountModel.CloudUserId != cloudUserId;
                linkedByAnother = linkedByAnother || (!String.IsNullOrWhiteSpace(socialEmail) && !String.IsNullOrWhiteSpace(linkedSocialAccountModel.SocialEmail) && linkedSocialAccountModel.SocialEmail != socialEmail);
                linkedByAnother = linkedByAnother || (!String.IsNullOrWhiteSpace(linkedSocialAccountModel.SocialId) && linkedSocialAccountModel.SocialId != socialId);

                if (linkedByAnother)
                {
                    throw new Exception("The social account has been linked by another cloud user.");
                }
            }

            result = linkedSocialAccountModel;

            return result;
        }
    }
}
