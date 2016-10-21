using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Dev.WSModels;
using Accela.Apps.Shared;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Dev.WSModels.V2;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.Repositories.Agency.Admin
{
    /// <summary>
    /// Settings repository class.
    /// </summary>
    public class AppSettingsRepository :RepositoryBase, IAppSettingsRepository
    {
        public AppSettingsRepository()
            : base() { }

        public IList<AppSettings> GetAppSettings(string appId, string agency, string host)
        {
            List<AppSettings> results = new List<AppSettings>();

            InternalAPIClient client = new InternalAPIClient();

            IAppRepository appRepository = IocContainer.Resolve<IAppRepository>();

            var appInfo = appRepository.GetAppByAppId(appId);

            if (appInfo != null)
            {
                string appSettingInfoEndpoint = string.Format("/apps/{0}/appsettings", appInfo.Id);

                if (!string.IsNullOrEmpty(agency))
                {
                    appSettingInfoEndpoint = appSettingInfoEndpoint + "?agency=" + agency;
                }

                if (!string.IsNullOrEmpty(host))
                {
                    appSettingInfoEndpoint = appSettingInfoEndpoint + "&host=" + host;
                }

                string appSettingInfoURL = BuildUrlForDevSubsystem(appSettingInfoEndpoint);

                var settings = client.Execute<WSAppSettingsResponse>(appSettingInfoURL);

                if (settings != null
                    && settings.AppSettings != null)
                {
                    settings.AppSettings.ForEach(setting =>
                        {
                            results.Add(new AppSettings
                                {
                                    ID = setting.ID,
                                    AppKey = setting.AppKey,
                                    Name = setting.Name,
                                    Description = setting.Description,
                                    DefaultValue = setting.DefaultValue,
                                    SettingsValue = setting.SettingsValue,
                                    HostSettingValue = setting.HostSettingValue
                                });
                        });
                }
            }

            return results;
        }
    }
}
