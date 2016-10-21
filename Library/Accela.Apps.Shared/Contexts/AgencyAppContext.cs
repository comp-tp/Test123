using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.Contexts
{
    /// <summary>
    /// Thread Context entity.
    /// </summary>
    [Serializable]
    public class AgencyAppContext : MarshalByRefObject, IAgencyAppContext
    {
        public int Index
        {
            get;
            set;
        }

        private string _token;
        /// <summary>
        /// Get token of current context.
        /// </summary>
        public string Token
        {
            get
            {
                return _token;
            }

            set
            {
                _token = value != null ? value.Trim() : null;
            }
        }

        private string _socialToken;
        /// <summary>
        /// Get token of current context.
        /// </summary>
        public string SocialToken
        {
            get
            {
                return _socialToken;
            }

            set
            {
                _socialToken = value != null ? value.Trim() : null;
            }
        }

        private string _language;
        /// <summary>
        /// Get language of current context.
        /// </summary>
        public string Language
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value != null ? value.Trim() : null;
            }
        }

        /// <summary>
        /// Gets or sets a value indicates whether current user is authed.
        /// </summary>
        public bool IsAuthed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set current context user.
        /// </summary>
        public IContextUser ContextUser
        {
            get;
            set;
        }

        /// <summary>
        /// Get trace id of current context.
        /// </summary>
        public string TraceID
        {
            get;
            set;
        }

        private string _loginName;
        /// <summary>
        /// Get login name of current context.
        /// </summary>
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

        private string _civicId;
        /// <summary>
        /// Get civic id of current context.
        /// </summary>
        public string CivicId
        {
            get
            {
                return _civicId;
            }

            set
            {
                _civicId = value != null ? value.Trim() : null;
            }
        }

        private string _envName;
        /// <summary>
        /// Get environment name of current context.
        /// </summary>
        public string EnvName
        {
            get
            {
                return _envName;
            }

            set
            {
                _envName = value != null ? value.Trim() : null;
            }
        }

        private string _agency;
        /// <summary>
        /// Get agency name of current context.
        /// </summary>
        public string Agency
        {
            get
            {
                return _agency;
            }

            set
            {
                _agency = value != null ? value.Trim() : null;
            }
        }

        private string _servProvCode;
        /// <summary>
        /// Get Service Provider Code of current context.
        /// </summary>
        public string ServProvCode
        {
            get
            {
                return _servProvCode;
            }

            set
            {
                _servProvCode = value != null ? value.Trim() : null;
            }
        }

        /// <summary>
        /// Get app id of current context.
        /// </summary>
        public string App
        {
            get;
            set;
        }

        /// <summary>
        /// Get app name of current context.
        /// </summary>
        public string AppName
        {
            get;
            set;
        }

        public string AppSecret
        {
            get;
            set;
        }

        /// <summary>
        /// Get app version of current context.
        /// </summary>
        public string AppVer
        {
            get;
            set;
        }

        public AppType AppType
        {
            get;
            set;
        }

        public string SubSystemCaller
        {
            get;
            set;
        }
        public string ClientIP
        {
            get;
            set;
        }

        public string RequestUri
        {
            get;
            set;
        }

        public string RequestUriTemplate
        {
            get;
            set;
        }

        public string HttpMethod
        {
            get;
            set;
        }

        public string HttpHeader
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public int ContentLength
        {
            get;
            set;
        }
        private IDictionary<string, object> _items;
        public IDictionary<string, object> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new Dictionary<string, object>();
                }

                return _items;
            }
            set
            {
                _items = value;
            }
        }
        /// <summary>
        /// Clone a ContextEntity object.
        /// </summary>
        /// <returns></returns>
        public IAgencyAppContext Clone()
        {
            IAgencyAppContext cloned = new AgencyAppContext();
            try
            {
                cloned.Agency = this.Agency;
                cloned.ServProvCode = this.ServProvCode;
                cloned.App = this.App;
                cloned.AppVer = this.AppVer;
                cloned.AppSecret = this.AppSecret;
                cloned.AppType = this.AppType;
                cloned.SubSystemCaller = this.SubSystemCaller;
                cloned.ClientIP = this.ClientIP;
                cloned.RequestUri = this.RequestUri;
                cloned.RequestUriTemplate = this.RequestUriTemplate;
                cloned.HttpMethod = this.HttpMethod;
                cloned.HttpHeader = this.HttpHeader;
                cloned.ContentType = this.ContentType;
                cloned.ContentLength = this.ContentLength;
                cloned.EnvName = this.EnvName;
                cloned.IsAuthed = this.IsAuthed;
                cloned.Language = this.Language;
                cloned.Token = this.Token;
                cloned.SocialToken = this.SocialToken;
                cloned.TraceID = this.TraceID;
                cloned.LoginName = this.LoginName;

                if (this.ContextUser != null)
                {
                    cloned.ContextUser = this.ContextUser.Clone();
                }

                // just support simple type for items
                foreach (KeyValuePair<string, object> kvp in this.Items)
                {
                    cloned.Items.Add(kvp.Key, kvp.Value);
                }
            }
            catch (Exception ex)
            { }

            return cloned;
        }
    }

}
