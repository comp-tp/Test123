using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Contexts;
using Accela.Core.Logging;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling;
using Microsoft.Practices.TransientFaultHandling;
using System;
using System.Collections.Generic;
using Accela.Infrastructure.Configurations;
using Accela.Core.Configurations;
using System.Runtime.Remoting.Messaging;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Admin.Agency.Client;
using Accela.Apps.Admin.Agency.Client.Models;

namespace Accela.Apps.Apis.Repositories
{
    /// <summary>
    /// Use this as RepositoryBase for all Repositories except CloudUserRepository
    /// </summary>
    public class RepositoryBase
    {
        #region Private Variables and Properties

        private static IConfigurationReader ConfigurationReader { get { return ConfigurationSettingsManager.Get(); } }

        private HostEnvironmentModel _environment;
        public HostEnvironmentModel Environment
        {
            get
            {
                if (_environment == null)
                {
                    SetupHostAndEnvironment();
                }

                return _environment;
            }
        }

        private CommonHelper _commonHelper;
        public CommonHelper CommonHelper
        {
            get
            {
                if (_commonHelper == null)
                {
                    _commonHelper = new CommonHelper(CurrentContext.Agency, CurrentContext.ContextUser.LoginName, CurrentContext.ServProvCode, CurrentContext.EnvName, CurrentContext.SocialToken, CurrentContext.Language, CurrentContext.TraceID);
                }

                return _commonHelper;
            }
        }

        public IAgencyAppContext CurrentContext
        {
            get;
            private set;
        }


        private void SetupHostAndEnvironment()
        {
            if (CurrentContext.Agency != UNKNOWN_AGENCY
                && CurrentContext.EnvName != UNKNOWN_ENVIRONMENT)
            {
                var agencyService = IocContainer.Resolve<IAgencySettingsService>();
                var envInfo = agencyService.GetEnvironment(CurrentContext.Agency, CurrentContext.EnvName);

                if (envInfo == null)
                {
                    string error = String.Format(MobileResources.GetString("environment_name_no_exist"), CurrentContext.EnvName);
                    throw new ArgumentException(error);
                }

                _environment = envInfo;
            }
        }
        
        #endregion

        #region Constructors

        public RepositoryBase(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        {
            if (String.IsNullOrEmpty(agencyName))
            {
                throw new ArgumentNullException("agencyName cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(serviceProvCode))
            {
                throw new ArgumentNullException("serviceProvCode cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(environmentName))
            {
                throw new ArgumentNullException("environmentName cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(agencyUserId))
            {
                throw new ArgumentNullException("agencyUserId cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(agencyUsername))
            {
                throw new ArgumentNullException("agencyUesrname cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException("appId cannot be null or empty.");
            }

            var context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
            this.CurrentContext = context != null ? context : new UnKownAgencyAppContext();
        }

        public RepositoryBase(IAgencyAppContext contextEntity)
        {
            if (String.IsNullOrEmpty(contextEntity.App))
            {
                throw new ArgumentNullException("appId cannot be null or empty.");
            }

            this.CurrentContext = contextEntity;
        }

        public RepositoryBase()
            : this(UNKNOWN_APPID, UNKNOWN_AGENCY, UNKNOWN_SERVICE_PRIVODER_CODE, UNKNOWN_AGENCYUSERID, UNKNOWN_AGENCYUSERNAME, String.Empty, UNKNOWN_ENVIRONMENT, String.Empty)
        {

        }

        private static readonly string UNKNOWN_AGENCY = "UNKNOWN-AGENCY";
        private static readonly string UNKNOWN_SERVICE_PRIVODER_CODE = "UNKNOWN-SERVICE-PROVIDER-CODE";
        private static readonly string UNKNOWN_ENVIRONMENT = "UNKNOWN-ENVIRONMENT";

        private static readonly string UNKNOWN_AGENCYUSERID = "UNKNOWN-AGENGCYUSERID";
        private static readonly string UNKNOWN_AGENCYUSERNAME = "UNKNOWN-AGENCYUSERNAME";

        private static readonly string UNKNOWN_APPID = "UNKNOWN-APPID";

        #endregion

        #region Logging

        protected ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        #endregion

        #region DB Retry Policy

        private RetryPolicy _retryPolicy;
        protected RetryPolicy SqlRetryPolicy
        {
            get
            {
                if (_retryPolicy == null)
                {
                    _retryPolicy = RetryPolicyFactory.GetDefaultSqlCommandRetryPolicy();
                    _retryPolicy.Retrying += new EventHandler<Microsoft.Practices.TransientFaultHandling.RetryingEventArgs>(RetryPolicy_Retrying);
                }

                return _retryPolicy;
            }
        }

        /// <summary>
        /// Handles the Retrying event of the RetryPolicy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Practices.TransientFaultHandling.RetryingEventArgs"/> instance containing the event data.</param>
        void RetryPolicy_Retrying(object sender, Microsoft.Practices.TransientFaultHandling.RetryingEventArgs e)
        {
            System.Diagnostics.Trace.TraceWarning(e.LastException.TraceInformation());
        }

        #endregion

        #region Url Builder
        public string BuildUrlForAdminSubsystem(string endpoint)
        {
            if (String.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentNullException("endpoint cannot be null or empty.");
            }

            if (!endpoint.StartsWith("/"))
            {
                throw new ArgumentException("endpoint should start with slash(\"/\").");
            }

            string baseUrl = ConfigurationReader.Get("Ref_InternalAPI_Admin");

            if (String.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("Missing Ref_InternalAPI_Admin setting in web.config file.");
            }

            if (baseUrl.EndsWith("/"))
            {
                throw new ArgumentException("The value of Ref_InternalAPI_Admin setting should not end with slash(\"/\").");
            }

            return String.Format("{0}{1}", baseUrl, endpoint);
        }

        public string BuildUrlForDevSubsystem(string endpoint)
        {
            if (String.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentNullException("endpoint cannot be null or empty.");
            }

            if (!endpoint.StartsWith("/"))
            {
                throw new ArgumentException("endpoint should start with slash(\"/\").");
            }

            string baseUrl = ConfigurationReader.Get("Ref_InternalAPI_Dev");

            if (String.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("Missing Ref_InternalAPI_Dev setting in web.config file.");
            }

            if (baseUrl.EndsWith("/"))
            {
                throw new ArgumentException("The value of Ref_InternalAPI_Dev setting should not end with slash(\"/\").");
            }

            return String.Format("{0}{1}", baseUrl, endpoint);
        }

        public string BuildUrlForUserSubsystem(string endpoint)
        {
            if (String.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentNullException("endpoint cannot be null or empty.");
            }

            if (!endpoint.StartsWith("/"))
            {
                throw new ArgumentException("endpoint should start with slash(\"/\").");
            }

            string baseUrl = ConfigurationReader.Get("Ref_InternalAPI_User");

            if (String.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("Missing Ref_InternalAPI_User setting in web.config file.");
            }

            if (baseUrl.EndsWith("/"))
            {
                throw new ArgumentException("The value of Ref_InternalAPI_User setting should not end with slash(\"/\").");
            }

            return String.Format("{0}{1}", baseUrl, endpoint);
        }

#endregion

        protected bool ShouldAutoCorrectCoordinate
        {
            get
            {
                // This kind of special geo-coding logic only applies to Accela mobile Apps.
                return IsAccelaMobileApps;
            }
        }

        private static readonly List<string> AccelaMobileAppIds = new List<string>
        {
            "com.accela.inspector",  // Accela Inspector
            "634787061125751953",    // Accela Code Officer
            "634787042277734375",    // Accela Work Crew
            "635042531515887177"     // Accela Analytics
        };

        private bool IsAccelaMobileApps
        {
            get { return AccelaMobileAppIds.Contains(CurrentContext.App); }
        }
    }
}