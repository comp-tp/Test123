using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IMapBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Get address by coordinate
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        GetAddressByCoordinateResponse GetAddressByCoordinate(GetAddressByCoordinateRequest request, IAgencyAppContext agencyContext);

        GeoGetCoordinatesByAddressesResponse GetCoordinates(GeoGetCoordinatesByAddressesRequest request);
    }
}
