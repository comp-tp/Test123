using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Exceptions;
using Accela.Core.Ioc;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Admin.Models;
using System.Configuration;
using Accela.Apps.Admin.Agency.Client;

namespace Accela.Apps.Apis.BusinessEntities
{
    /// <summary>
    /// App logic class.
    /// </summary>
    public class AppBusinessEntity : BusinessEntityBase, IAppBusinessEntity
    {
        private const string RESTRICTEDAPIS = "RestrictedApis";
        private const int APP_STATUS_ENABLED = 1;
        //private const int APP_STATUS_DISABLED = 2;

        private IAppRepository _appRepository;
        private Admin.Agency.Client.IAgencySettingsService _agencyService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AppBusinessEntity(IAppRepository appRepository, Admin.Agency.Client.IAgencySettingsService agencyService)
        {
            _appRepository = appRepository;
            _agencyService = agencyService;
        }

        private string[] RetristictedAPIs
        {
            get
            {
                return ConfigurationManager.AppSettings[RESTRICTEDAPIS].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        ///// <summary>
        ///// Get App by App Id
        ///// </summary>
        ///// <param name="id">App Id(primary Key)</param>
        ///// <returns>return App that according Id</returns>
        //public AppModel GetAppByID(Guid id)
        //{
        //    return _appRepository.GetAppByID(id);
        //}

        /// <summary>
        /// Get settings by App id.
        /// </summary>
        /// <param name="appId">App Id</param>
        /// <returns></returns>
        public AppModel GetAppByAppId(string appId)
        {
            return _appRepository.GetAppByAppId(appId);
        }

        public bool IsAppEnable(AppModel app)
        {
            if (app == null)
            {
                return false;
            }
            else
            {
                return app.Status.HasValue ? app.Status.Value == APP_STATUS_ENABLED : false;
            }
        }

        /// <summary>
        /// validate whether the app is enabled by agency.
        /// Exception if app is not allowed by agency:
        /// ForbiddenException
        /// </summary>
        /// <param name="appGuid">app guid.</param>
        /// <param name="agencyName">agency name.</param>
        /// <param name="currentAPI">current api includes httpmethod and api, like 'get /v4/paments'</param>
        public void ValidateAppPermissionByAgency(Guid appGuid, string agencyName, string currentAPI = null)
        {
            var apps = _agencyService.GetAgencyApps(agencyName);
            AgencyAppModel agencyApp = null;

            if (apps != null && apps.Count > 0)
            {
                agencyApp = apps.Where(a => a.AppId == appGuid).FirstOrDefault();
            }

            if (agencyApp == null && String.IsNullOrWhiteSpace(currentAPI))
            {
                return;
            }

            bool isRestrictedAPI = false;
            // check whether current api is restricted api
            if (!String.IsNullOrWhiteSpace(currentAPI))
            {
                if (RetristictedAPIs != null && RetristictedAPIs.Count(s => s.Equals(currentAPI, StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    isRestrictedAPI = true;
                }
            }

            // by default, all apps is enable 
            if(agencyApp == null )
            {
                // by default, the restricted api is not turned on by agency
                if(!String.IsNullOrWhiteSpace(currentAPI) && isRestrictedAPI)
                {
                    throw new ForbiddenException("Permission denied by agency.");
                }
            }
            else
            {
                if (!agencyApp.AppEnabledForAgency)
                {
                    throw new ForbiddenException("The app is disabled by admin.");
                }
                else
                {
                    if (isRestrictedAPI && !agencyApp.PaymentEnabledForApp)
                    {
                        throw new ForbiddenException("Permission denied by agency.");
                    }
                }
            }
        }
    }
}
