using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Shared.Contants;

namespace Accela.Apps.Shared.OAuth.Token.RelyingParty
{
    public class AccelaAccessTokenModel
    {
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

        public AppType ClientType { get; set; }

        private string _clientId;
        public string ClientId
        {
            get
            {
                return _clientId;
            }

            set
            {
                _clientId = value != null ? value.Trim() : null;
            }
        }

        public HashSet<string> Scope { get; set; }

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

        private string _aAToken;
        public string AAToken
        {
            get
            {
                return _aAToken;
            }

            set
            {
                _aAToken = value != null ? value.Trim() : null;
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

        private ulong _expiresIn;
        public ulong ExpiresIn
        {
            get
            {
                return _expiresIn;
            }

            set
            {
                _expiresIn = value;
            }
        }
    }
}
