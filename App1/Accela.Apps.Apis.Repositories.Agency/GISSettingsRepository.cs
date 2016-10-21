using Accela.Apps.Admin.Agency.Client;
using Accela.Apps.Apis.Models.Common;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class GISSettingsRepository : RepositoryBase, IGISSettingsRepository
    {
        private readonly IAgencySettingsService _agencyService;
        private readonly IConfigurationReader _configurationReader;
        public GISSettingsRepository(IAgencySettingsService agencyService, IConfigurationReader configurationReader)
            : base()
        {
            _agencyService = agencyService;
            _configurationReader = configurationReader;
        }

        public GeocodeSettingsModel GetGeocodeServiceSettings(string agency)
        {
            GeocodeSettingsModel result = null;

            //get agency configuration
            if (!string.IsNullOrEmpty(agency))
            {
                var response = _agencyService.GetGISSettings(agency);
                if (response != null && response.GeocodeRoutingSetting != null && response.GeocodeRoutingSetting.GeocodeService != null)
                {
                    var geocodeService = response.GeocodeRoutingSetting.GeocodeService;
                    if (geocodeService != null
                        && !string.IsNullOrWhiteSpace(geocodeService.GeocodeServiceUrl)
                        )
                    {
                        result = new GeocodeSettingsModel()
                        {
                            GeocodeServerUrl = geocodeService.GeocodeServiceUrl,
                            Token = geocodeService.SecuritySettings.Token,
                            TokenServiceUrl = geocodeService.SecuritySettings.TokenUrl,
                            TokenUserName = geocodeService.SecuritySettings.UserName,
                            TokenPassword = geocodeService.SecuritySettings.Password,
                            Referer = geocodeService.SecuritySettings.Referrer,
                            IsCustomService = true
                        };
                    }
                }
            }

            // get default configuration
            if (result == null)
            {
                result = new GeocodeSettingsModel()
                {
                    GeocodeServerUrl = _configurationReader.Get(GeocodeConstants.Settings_Key_ArcGISServerUrl),
                    TokenServiceUrl = _configurationReader.Get(GeocodeConstants.Settings_Key_ArcGISTokenServiceUrl),
                    TokenUserName = _configurationReader.Get(GeocodeConstants.Settings_Key_ArcGISTokenUserName),
                    TokenPassword = _configurationReader.Get(GeocodeConstants.Settings_Key_ArcGISTokenPassword),
                    Referer = _configurationReader.Get(GeocodeConstants.Settings_Key_ArcGISReferer),
                    IsCustomService = false
                };
            }

            return result;
        }
    }
}
