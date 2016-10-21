using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IAddressRepository : IRepository
    {
        AddressesResponse GetAddresses(AddressesRequest request);

        AddressResponse GetAddress(AddressRequest request);
    }
}
