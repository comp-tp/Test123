using System;
using System.Collections.Generic;
using System.Linq;

using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Dev.WSModels.V2;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Cache;
using Accela.Core.Utilities;
using Accela.Infrastructure.Caches;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Apis.Repositories.Agency.Admin
{
    public class AppRepository : RepositoryBase, IAppRepository
    {
        private readonly IConfigurationReader _configurationReader;
        private readonly CacheStoreProvider cacheProvider;
        private const string APP_CACHE_EXPIRATION_MINUTES = "AppCacheExpirationMinutes";

        /// <summary>
        /// Get App by row guid.
        /// </summary>
        /// <param name="id">row guid.</param>
        /// <returns></returns>

        public AppRepository(CacheStoreProvider cacheProvider, IConfigurationReader configurationReader)
            : base()
        {
            this.cacheProvider = cacheProvider;
            _configurationReader = configurationReader;
        }
    
        /// <summary>
        /// Get App by appId which is not a guid
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public AppModel GetAppByAppId(string appId)
        {
            Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(appId), "appId");
            string cacheKey = CacheKeys.APP_BY_APPID + appId;
            WSAppResponse appInfo = null;

            try
            {
                appInfo = cacheProvider.Instance.Get<WSAppResponse>(cacheKey);
            }
            catch(Exception ex)
            {
                Log.Critical(ex.Message, ex.ToString(), "GetAppByAppId");
            }

            // get from app subsystem then cache it
            if (appInfo == null)
            {
                InternalAPIClient client = new InternalAPIClient();

                string appInfoEndpoint = "/apps/" + appId;
                string appInfoURL = BuildUrlForDevSubsystem(appInfoEndpoint);

                appInfo = client.Execute<WSAppResponse>(appInfoURL);

                if (appInfo != null && appInfo.App != null)
                {
                    try
                    {
                        cacheProvider.Instance.Put<WSAppResponse>(cacheKey, appInfo, DateTime.UtcNow.Add(TimeSpan.FromMinutes(this._configurationReader.Get<double>(APP_CACHE_EXPIRATION_MINUTES, 15))));
                    }
                    catch (Exception ex)
                    {
                        Log.Critical(ex.Message, ex.ToString(), "GetAppByAppId");
                    }
                }
            }

            AppModel result = null;
            if (appInfo != null && appInfo.App != null)
            {
                result = ConvertWSAppToAppModel(appInfo.App);
            }

            return result;
        }

        /// <summary>
        /// Search Apps according to search condition. 
        /// </summary>
        /// <param name="searchConditions">search condition, if null means get all apps.</param>
        /// <returns>WSApp list.</returns>
        public List<WSApp> SearchApps(Dictionary<string, string> searchConditions)
        {
            WSDevSearchAndSortRequest request = new WSDevSearchAndSortRequest();
            request.SearchConditions = searchConditions == null ? new Dictionary<string, string>() : searchConditions;

            string appSearchEndpoint = "/apps/search?pageIndex=0&pageSize=" + int.MaxValue;
            string appSearchURL = BuildUrlForDevSubsystem(appSearchEndpoint);

            InternalAPIClient client = new InternalAPIClient();
            var appsResponse = client.Execute<WSAppsResponse>(appSearchURL, request);

            return appsResponse.Apps;
        }

        private List<WSApp> GetAllEnableApps()
        {
            WSDevSearchAndSortRequest request = new WSDevSearchAndSortRequest();
            request.SearchConditions = new Dictionary<string, string>();

            // 1-Enable,2-Disable
            request.SearchConditions.Add("Enable","1");

            string appSearchEndpoint = "/apps/search?pageIndex=0&pageSize=" + int.MaxValue;
            string appSearchURL = BuildUrlForDevSubsystem(appSearchEndpoint);

            InternalAPIClient client = new InternalAPIClient();
            var appsResponse = client.Execute<WSAppsResponse>(appSearchURL, request);

            return appsResponse.Apps;
        }

        /// <summary>
        /// Convert WSApp to AppModel.
        /// </summary>
        /// <param name="wsapp">an instance of WSApp.</param>
        /// <returns>AppModel</returns>
        private static AppModel ConvertWSAppToAppModel(WSApp wsapp)
        {
            if(wsapp == null)
            {
                return null;
            }

            var result = new AppModel();
            result.Id = wsapp.Id;
            result.DevId = wsapp.DevId;
            result.AppName = wsapp.AppName;
            result.AppType = wsapp.AppType;
            result.AppId = wsapp.AppId;
            result.Company = wsapp.Company;
            result.Description = wsapp.Description;
            result.Status = wsapp.Status;
            result.LastUpdatedBy = wsapp.LastUpdatedBy;
            result.LastUpdatedDate = wsapp.LastUpdatedDate;
            result.CreatedBy = wsapp.CreatedBy;
            result.CreatedDate = wsapp.CreatedDate;
            result.Stage = wsapp.Stage;
            result.SecretCode = wsapp.AppSecret;
            result.Keep1 = wsapp.Keep1;
            result.Keep2 = wsapp.Keep2;

            return result;
        }

        /// <summary>
        /// Convert WSApp list to AppModel list.
        /// </summary>
        /// <param name="wsapps">WSApp list.</param>
        /// <returns>AppModel list.</returns>
        private static List<AppModel> ConvertWSAppsToAppModels(List<WSApp> wsapps)
        {
            if(wsapps == null)
            {
                return null;
            }

            List<AppModel> result = new List<AppModel>();
            foreach(var item in wsapps)
            {
                result.Add(ConvertWSAppToAppModel(item));
            }

            return result;
        }
    }
}
