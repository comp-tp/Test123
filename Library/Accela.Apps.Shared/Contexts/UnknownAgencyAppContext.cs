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
    public class UnKownAgencyAppContext : IAgencyAppContext
    {

        private static readonly string UNKNOWN_AGENCY = "UNKNOWN-AGENCY";
        private static readonly string UNKNOWN_SERVICE_PRIVODER_CODE = "UNKNOWN-SERVICE-PROVIDER-CODE";
        private static readonly string UNKNOWN_ENVIRONMENT = "UNKNOWN-ENVIRONMENT";

        private static readonly string UNKNOWN_AGENCYUSERID = "UNKNOWN-AGENGCYUSERID";
        private static readonly string UNKNOWN_AGENCYUSERNAME = "UNKNOWN-AGENCYUSERNAME";

        private static readonly string UNKNOWN_APPID = "UNKNOWN-APPID";

        public UnKownAgencyAppContext()
        {
            this.Agency = UNKNOWN_AGENCY;
            this.ServProvCode = UNKNOWN_SERVICE_PRIVODER_CODE;
            this.EnvName = UNKNOWN_ENVIRONMENT;
            this.App = UNKNOWN_APPID;
            this.Token = string.Empty;
            this.Language = string.Empty;
            this.LoginName = UNKNOWN_AGENCYUSERNAME;
            this.ContextUser = new UnKownContextUser();
        }
        public string Agency { get; set; }

        public string App
        {
            get;
            set;
        }

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

        public AppType AppType
        {
            get;
            set;
        }

        public string AppVer
        {
            get;
            set;
        }

        public string ClientIP
        {
            get;
            set;
        }

        public int ContentLength
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public string EnvName
        {
            get;
            set;
        }

        public string HttpHeader
        {
            get;
            set;
        }

        public string HttpMethod
        {
            get;
            set;
        }

        public int Index
        {
            get;
            set;
        }

        public bool IsAuthed
        {
            get;
            set;
        }

        public IDictionary<string, object> Items
        {
            get;
            set;
        }

        public string Language
        {
            get;
            set;
        }

        public string LoginName
        {
            get;
            set;
        }

        /// <summary>
        /// Get civic id of current context.
        /// </summary>
        public string CivicId
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

        public string ServProvCode
        {
            get;
            set;
        }

        public string SocialToken
        {
            get;
            set;
        }

        public string SubSystemCaller
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public string TraceID
        {
            get;
            set;
        }

        public IAgencyAppContext Clone()
        {
            return new UnKownAgencyAppContext();
            //throw new NotImplementedException();
        }

        public IContextUser ContextUser
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Thread Context entity.
    /// </summary>
    [Serializable]
    public class UnKownContextUser : IContextUser
    {
        private static readonly string UNKNOWN_AGENCYUSERID = "UNKNOWN-AGENGCYUSERID";
        private static readonly string UNKNOWN_AGENCYUSERNAME = "UNKNOWN-AGENCYUSERNAME";
        public UnKownContextUser()
        {
            this.Id = Guid.Empty;
            this.LoginName = UNKNOWN_AGENCYUSERNAME;
        }
        public Guid Id { get; set; }

        /// <summary>
        /// agency display name.
        /// </summary>
        /// <remarks>
        /// e.g. Accela_Dev, Accela_Prod. After login, the value is set to servProvCode.
        /// in backend we always use servPorvCode as communication.
        /// </remarks>
        public string Agency { get; set; }
        public Guid AgencyID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public string Environment { get; set; }
        public string InspectorIdentifier { get; set; }

        public IContextUser Clone()
        {
            IContextUser user = new UnKownContextUser();
            user.Agency = this.Agency;
            user.AgencyID = this.AgencyID;
            user.Environment = this.Environment;
            user.Id = this.Id;
            user.InspectorIdentifier = this.InspectorIdentifier;
            user.Language = this.Language;
            user.Password = this.Password;
            user.LoginName = this.LoginName;

            return user;
        }

        /// <summary>
        /// Idicates whether the user has the claim. 
        /// </summary>
        /// <param name="claim">The claim to check.</param>
        /// <returns>true/false.</returns>
        public bool HasClaim(string claim)
        {
            return false;
        }
    }
}
