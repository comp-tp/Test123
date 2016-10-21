using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IParcelBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Query parcel according request's parcelId
        /// </summary>
        /// <param name="request">Parcel Request Object, include parcelId field</param>
        /// <returns>return matched parcel</returns>
        ParcelResponse GetParcel(ParcelRequest request);

        /// <summary>
        /// Gets the parcel owners.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the parcel owners.</returns>
        ParcelOwnersResponse GetParcelOwners(ParcelOwnersRequest request);

        /// <summary>
        /// Query parcels according request's criteria
        /// </summary>
        /// <param name="request">Parcels Request Object, include criteria and related system parameter</param>
        /// <returns>return matched parcel list</returns>
        ParcelsResponse GetParcels(ParcelsRequest request);

        AddressesResponse GetParcelAddresses(ParcelAddressesRequest request);
    }
}
