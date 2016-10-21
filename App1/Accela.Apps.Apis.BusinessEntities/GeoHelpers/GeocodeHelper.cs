using Accela.Core.Ioc;
using Accela.Apps.GeoServices;
using Accela.Apps.Shared.Exceptions;
using System;
using Accela.Apps.Apis.Repositories.Interfaces;

namespace Accela.Apps.Apis.BusinessEntities.GeoHelpers
{
    public static class GeocodeHelper
    {
        public static void InitGeocodeParameters(IGeocodeRepository geocodeRepository, string agencyName)
        {
            var gisSettingRepo = IocContainer.Resolve<IGISSettingsRepository>();
            var geocodesettings = gisSettingRepo.GetGeocodeServiceSettings(agencyName);

            if (geocodesettings == null
                || String.IsNullOrWhiteSpace(geocodesettings.GeocodeServerUrl)
                )
            {
                throw new MobileException("Geocode service is unavailable.", "Can't find Geocode service settings.", ErrorCodes.internal_server_error_500);
            }

            geocodeRepository.GeocodeServerUrl = geocodesettings.GeocodeServerUrl;
            geocodeRepository.Token = geocodesettings.Token;
            geocodeRepository.TokenServiceUrl = geocodesettings.TokenServiceUrl;
            geocodeRepository.TokenPassword = geocodesettings.TokenPassword;
            geocodeRepository.TokenUsername = geocodesettings.TokenUserName;
            geocodeRepository.Referer = geocodesettings.Referer;
            geocodeRepository.IsCustomService = geocodesettings.IsCustomService;
        }

   
    }
}
