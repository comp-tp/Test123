using System;
using System.Linq;
using Accela.Apps.Shared.OAuth.Token;
using DotNetOpenAuth.OAuth2;

namespace Accela.Apps.Shared.OAuth.Token
{
    public class AccelaAccessToken : AuthorizationServerAccessToken
    {
        public const string CLIENT_ID = "client_id";
        public const string CLIENT_TYPE = "client_type";
        public const string AGENCY_NAME = "agency_name";
        public const string AA_TOKEN = "aa_token";
        public const string LOGIN_NAME = "login_name";
        public const string ENVIRONMENT_NAME = "environment";
        public const string SCOPE = "scope";
        public const string CLOUD_USER_ID = "cloud_user_id";
        public const string ACCOUNT_UID = "account_uid";
        public const string Expires_On = "ExpiresOn";

        private string _clientType;
        public string ClientType
        {
            get
            {
                return _clientType;
            }

            set
            {
                _clientType = value != null ? value.Trim() : null;
            }
        }

        private string _cloudUserId;
        public string CloudUserId
        {
            get
            {
                return _cloudUserId;
            }

            set
            {
                _cloudUserId = value != null ? value.Trim() : null;
            }
        }

        private string _accountUid;
        public string AccountUid
        {
            get
            {
                return _accountUid;
            }

            set
            {
                _accountUid = value != null ? value.Trim() : null;
            }
        }

        private string _agencyName;
        public string AgencyName
        {
            get
            {
                return _agencyName;
            }

            set
            {
                _agencyName = value != null ? value.Trim() : null;
            }
        }

        private string _loginName;
        public string LoginName
        {
            get
            {
                return _loginName;
            }

            set
            {
                _loginName = value != null ? value.Trim() : null;
            }
        }

        private string _environmentName;
        public string EnvironmentName
        {
            get
            {
                return _environmentName;
            }

            set
            {
                _environmentName = value != null ? value.Trim() : null;
            }
        }

        private string _xAccessTokenSigningKey;
        public string XAccessTokenSigningKey
        {
            get
            {
                return _xAccessTokenSigningKey;
            }

            set
            {
                _xAccessTokenSigningKey = value != null ? value.Trim() : null;
            }
        }

        private string _xResourceServerEncryptionKey;
        public string XResourceServerEncryptionKey
        {
            get
            {
                return _xResourceServerEncryptionKey;
            }

            set
            {
                _xResourceServerEncryptionKey = value != null ? value.Trim() : null;
            }
        }

        /// <summary>
        /// Serializes this instance to a simple string for transmission to the client.
        /// </summary>
        /// <returns>A non-empty string.</returns>
        protected override string Serialize()
        {
            var tokenModel = new SimpleWebTokenModel();
            //tokenModel.Issuer = "www.accela.com";
            tokenModel.SetExpiresOnFromNowUtcOn(this.Lifetime.HasValue ? this.Lifetime.Value : new TimeSpan(2, 0, 0));
            //tokenModel.Audience = this.ClientIdentifier;

            if (!String.IsNullOrWhiteSpace(this.ClientIdentifier))
            {
                tokenModel.AddClaim(CLIENT_ID, this.ClientIdentifier);
            }

            if (!String.IsNullOrWhiteSpace(this.ClientType))
            {
                tokenModel.AddClaim(CLIENT_TYPE, this.ClientType);
            }

            //var form = System.Web.HttpContext.Current.Request.Form;

            if (!String.IsNullOrWhiteSpace(this.AgencyName))
            {
                tokenModel.AddClaim(AGENCY_NAME, this.AgencyName);
            }

            if (!String.IsNullOrWhiteSpace(this.LoginName))
            {
                tokenModel.AddClaim(LOGIN_NAME, this.LoginName);
            }

            if (!String.IsNullOrWhiteSpace(this.EnvironmentName))
            {
                tokenModel.AddClaim(ENVIRONMENT_NAME, this.EnvironmentName);
            }

            if (this.ExtraData != null && this.ExtraData.Count > 0)
            {

            }

            if (this.Scope != null && this.Scope.Count > 0)
            {
                tokenModel.AddClaim(SCOPE, String.Join(" ", this.Scope.ToArray()));
            }

            var cloudUserId = !String.IsNullOrWhiteSpace(this.CloudUserId) ? this.CloudUserId : this.User;

            if (!String.IsNullOrWhiteSpace(cloudUserId))
            {
                tokenModel.AddClaim(CLOUD_USER_ID, cloudUserId);
            }

            if (!String.IsNullOrWhiteSpace(this.AccountUid))
            {
                tokenModel.AddClaim(ACCOUNT_UID, this.AccountUid);
            }

            //tokenModel.AddClaim("utc_issued", this.UtcIssued.Ticks.ToString(CultureInfo.InvariantCulture));

            var sealedAccessToken = SimpleWebTokenFactory.CreateToken(tokenModel, XAccessTokenSigningKey, XResourceServerEncryptionKey);
            return sealedAccessToken;
        }
    }
}
