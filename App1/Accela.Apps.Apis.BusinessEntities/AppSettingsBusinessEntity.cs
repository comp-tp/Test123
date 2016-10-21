using System.Collections.Generic;
using System.Text;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using System;
using Accela.Apps.Apis.Resources;
using Accela.Apps.Admin.Agency.Client;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class AppSettingsBusinessEntity : BusinessEntityBase, IAppSettingsBusinessEntity
    {
        //private IAppSettingsRepository _appSettingsRepository = null;
        private IAppSettingsRepository AppSettingsRepository;
        private Admin.Agency.Client.IAgencySettingsService _agencySettingService;


        public AppSettingsBusinessEntity(IAppSettingsRepository appSettingsRepository, Admin.Agency.Client.IAgencySettingsService agencySettingService)
        {
            this.AppSettingsRepository = appSettingsRepository;
            this._agencySettingService = agencySettingService;
        }
        /// <summary>
        /// Get AppSetting by key
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AppSettingResponse GetAppSetting(AppSettingRequest request)
        {
            List<string> lstKey = new List<string>() { request.SettingKey };

            var appSettings = GetAppSettingByRequest(request.AppId, request.Agency, null, lstKey);

            AppSettingResponse response = new AppSettingResponse();

            var settingValue = string.Empty;
            if (appSettings == null || appSettings.Count == 0)
            {
                var unCreatedKeys = GetCommaString(lstKey);
                throw new MobileException(string.Format(MobileResources.GetString("appsetting_key_no_set"), unCreatedKeys));
            }

            GetAppSettingValue(appSettings);

            response.SettingValue = appSettings[0].SettingsValue;

            return response;
        }

        /// <summary>
        /// Get AppSettings by keys
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AppSettingsResponse GetAppSettings(AppSettingsRequest request)
        {
            AppSettingsResponse response = new AppSettingsResponse();

            if (!String.IsNullOrEmpty(request.Agency))
            {
                var agency = _agencySettingService.GetAgency(request.Agency);

                if (agency == null)
                {
                    throw new MobileException(MobileResources.GetString("agency_no_exist"));
                }

                request.Agency = agency.AgencyId.Value.ToString();

                if (agency.ParentAgencyId.HasValue)
                {
                    request.Host = agency.ParentAgencyId.Value.ToString();
                }
            }

            var appSettings = GetAppSettingByRequest(request.AppId, request.Agency, request.Host, request.SettingKeys);

            if (appSettings != null)
            {
                response.SettingValues = new Dictionary<string, string>();

                GetAppSettingValue(appSettings);
                
                foreach (AppSettings appSetting in appSettings)
                {
                    response.SettingValues.Add(appSetting.Name, appSetting.SettingsValue);
                }
            }

            return response;
        }

        /// <summary>
        /// Convert list string to string contact by comma.
        /// </summary>
        /// <param name="settingKeys">Setting keys.</param>
        /// <returns>Keys seperated by comma.</returns>
        private string GetCommaString(List<string> settingKeys)
        {
            var keys = new StringBuilder();
            if (settingKeys != null && settingKeys.Count > 0)
            {
                for (int i = 0; i < settingKeys.Count; i++)
                {
                    if (i == 0)
                    {
                        keys.Append(settingKeys[i]);
                    }
                    else
                    {
                        keys.Append("," + settingKeys[i]);
                    }
                }
            }
            return keys.ToString();
        }

        private IList<AppSettings> GetAppSettingByRequest(string appId, string agency, string host, IList<string> settingKeys)
        {
            var appSettings = AppSettingsRepository.GetAppSettings(appId, agency, host) as List<AppSettings>;

            if (appSettings != null
                && settingKeys != null)
            {
                appSettings.RemoveAll(item => !settingKeys.Contains(item.Name));
            }

            return appSettings;
        }

        private void GetAppSettingValue(IList<AppSettings> appSettings)
        {
            /*
             * There are 3 kinds of values, host-related value, agency-related value, and developer-related value.
             * Here is the priority of them:
             * agency-related value > host-related value > developer-related value
             * 
            //*/
            foreach (var setting in appSettings)
            {
                if (String.IsNullOrEmpty(setting.SettingsValue))
                {
                    if (!String.IsNullOrEmpty(setting.HostSettingValue))
                    {
                        setting.SettingsValue = setting.HostSettingValue;
                    }
                    else
                    {
                        setting.SettingsValue = setting.DefaultValue;
                    }
                }
            }
        }
    }
}
