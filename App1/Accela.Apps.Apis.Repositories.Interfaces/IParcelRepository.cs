using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IParcelRepository : IRepository
    {
        /// <summary>
        /// Query parcels according request's criteria
        /// </summary>
        /// <param name="request">Parcels Request Object, include criteria and related system parameter</param>
        /// <returns>return matched parcel list</returns>
        ParcelsResponse GetParcels(ParcelsRequest request);
    }
}
