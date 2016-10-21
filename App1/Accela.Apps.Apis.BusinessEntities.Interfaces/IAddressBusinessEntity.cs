using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IAddressBusinessEntity : IBusinessEntity
    {
        AddressesResponse GetAddresses(AddressesRequest request);

        AddressResponse GetAddress(AddressRequest request);

        /// <summary>
        /// Retrieve Coodinate by address, then set X,Y to address.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <param name="forceSetCoordinatesByAddress">if set to <c>true</c> [force set coordinates by address].</param>
        void RetrieveAndSetCoodinateXY(List<AddressModel> addresses, bool forceSetCoordinatesByAddress = true);
    }
}
