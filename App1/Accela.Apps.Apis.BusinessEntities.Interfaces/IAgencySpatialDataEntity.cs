using System;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IAgencySpatialDataEntity : IBusinessEntity
    {
        GeoSearchAgenciesResponse SearchAgencyByCoordinate(GeoSearchAgenciesRequest request);

        GeoSearchAgenciesResponse SearchAgencyByAddress(GeoSearchAgenciesByAddressRequest request, IAgencyAppContext context);
    }
}
