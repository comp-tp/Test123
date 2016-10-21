using Accela.Apps.Apis.BusinessEntities.GeoHelpers;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Core.Ioc;
using Accela.Apps.GeoServices;
using Accela.Apps.Shared;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Contexts;
using System;
using System.Collections.Generic;
using Accela.Apps.Admin.Agency.Client;
using Accela.Apps.Admin.Agency.Client.Models;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class AgencySpatialDataEntity : BusinessEntityBase, IAgencySpatialDataEntity
    {
        private readonly IConfigurationReader configurationReader;
        private readonly Admin.Agency.Client.IAgencySettingsService _agencyService;

        public AgencySpatialDataEntity(IConfigurationReader configurationReader, Admin.Agency.Client.IAgencySettingsService agencyService)
        {
            this.configurationReader = configurationReader;
            _agencyService = agencyService;
        }

        private IGeocodeRepository GeocodeRepository
        {
            get
            {
                var geocodeRepository = IocContainer.Resolve<IGeocodeRepository>();
                GeocodeHelper.InitGeocodeParameters(geocodeRepository, _context.Agency);
                return geocodeRepository;
            }
        }

        private IAgencyAppContext _context = new UnKownAgencyAppContext();

        public GeoSearchAgenciesResponse SearchAgencyByCoordinate(GeoSearchAgenciesRequest request)
        {
            var result = new GeoSearchAgenciesResponse();
            var tempResult = _agencyService.SearchAgencyByCoordinate(request.Longitude, request.Latitude);
            result.Agencies = new List<AgencyModel>();

            if (tempResult != null && tempResult.Count > 0)
            {
                foreach (var agency in tempResult)
                {
                    var agencyModel = _agencyService.GetAgency(agency.Name);

                    if (agencyModel != null) // && agencyModel.Enable && !agencyModel.IsForDemo)
                    {
                        result.Agencies.Add(agencyModel);
                    }
                }
            }
            else
            {
                var genericAgencyName = configurationReader.Get(Accela.Apps.Shared.Contants.ConfigurationConstant.GENERIC_AGENCY_NAME);
                var agencyModel = _agencyService.GetAgency(genericAgencyName);

                if (agencyModel != null)
                {
                    result.Agencies.Add(agencyModel);
                }
            }

            return result;
        }

        public GeoSearchAgenciesResponse SearchAgencyByAddress(GeoSearchAgenciesByAddressRequest request, IAgencyAppContext context)
        {
            _context = context;
            var result = new GeoSearchAgenciesResponse();
            var address = request != null ? request.Address : String.Empty;

            var coordinates = GeocodeRepository.GetCoordinateByAddresses(new string[] { address });

            if (coordinates != null && coordinates.Length > 0)
            {
                var geoSearchAgenciesRequest = new GeoSearchAgenciesRequest()
                {
                    Longitude = coordinates[0].LocationX,
                    Latitude = coordinates[0].LocationY
                };

                result = SearchAgencyByCoordinate(geoSearchAgenciesRequest);
            }

            return result;
        }
    }
}
