using System;
using Accela.Apps.Shared;
using Accela.Core.Logging;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling;
using Microsoft.Practices.TransientFaultHandling;
using Accela.Apps.Shared.Contexts;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Apis.Repositories
{
    /// <summary>
    /// Use this as RepositoryBase for all Repositories except CloudUserRepository
    /// </summary>
    public class RepositoryBase
    {
        #region Private Variables and Properties

        public IAgencyAppContext CurrentContext
        {
            get; private set;
        }

        #endregion

        #region Constructors


        public RepositoryBase(IAgencyAppContext contextEntity)
        {
            if (String.IsNullOrEmpty(contextEntity.App))
            {
                throw new ArgumentNullException("appId cannot be null or empty.");
            }

            this.CurrentContext = contextEntity;

        }

        
        public RepositoryBase()
        {

            this.CurrentContext = new UnKownAgencyAppContext();
            //_agencyName = UNKNOWN_AGENCY;
            //_serviceProvCode = UNKNOWN_SERVICE_PRIVODER_CODE;
            //_environmentName = UNKNOWN_ENVIRONMENT;

            //_agencyUserId = UNKNOWN_AGENCYUSERID;
            //_agencyUsername = UNKNOWN_AGENCYUSERNAME;
            //_token = string.Empty;
            //_language = string.Empty;

            //_appId = UNKNOWN_APPID;

        }

        #endregion

        //public string AgencyName { get; private set; }

        //public string EnvironmentName { get; private set; }

        //public string Language { get; private set; }

        //public string Token { get; private set; }

        //public RepositoryBase(string agencyName, string environmentName, string language, string token)
        //{
        //    this.AgencyName = agencyName;
        //    this.EnvironmentName = environmentName;
        //    this.Language = language;
        //    this.Token = token;
        //}

        //public RepositoryBase()
        //    : this(String.Empty, String.Empty, String.Empty, String.Empty)
        //{
        //}

        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        protected ILog Log
        {
            get
            {
                //return ObjectFactory.GetLog();

                // TODO:
                // Uses the new DLL

                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        private RetryPolicy _retryPolicy;

        /// <summary>
        /// Get Sql Retry Policy.
        /// </summary>
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
    }
}