using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ParcelBusinessEntity : IParcelBusinessEntity
    {

        public ParcelBusinessEntity(IParcelRepository parcelRepository)
        {
            ParcelRepository = parcelRepository;
        }

        //private IParcelRepository _parcelRepository = null;
        private readonly IParcelRepository ParcelRepository;
        

        public ParcelResponse GetParcel(ParcelRequest request)
        {
            ParcelsRequest parcelsRequest = new ParcelsRequest();
            parcelsRequest.Offset = 0;
            parcelsRequest.Limit = 0;
            parcelsRequest.Criteria = new ParcelCriteria();
            parcelsRequest.Criteria.ParcelIds = new List<string>() { request.ParcelId };
            parcelsRequest.Elements = new List<string>() { "Basic" };
            ParcelsResponse response = ParcelRepository.GetParcels(parcelsRequest);
            if (response == null || response.Parcels == null || response.Parcels.Count == 0)
            {
                throw new NotFoundException("The parcel didn't exist");
            }

            ParcelResponse result = new ParcelResponse();
            result.Parcel = response.Parcels[0];

            return result;
        }

        public ParcelOwnersResponse GetParcelOwners(ParcelOwnersRequest request)
        {
            var parcelsRequest = new ParcelsRequest();
            parcelsRequest.Offset = 0;
            parcelsRequest.Limit = 0;
            parcelsRequest.Criteria = new ParcelCriteria();
            parcelsRequest.Criteria.ParcelIds = new List<string>() { request.ParcelId };
            parcelsRequest.Elements = new List<string>() { "Contacts" };
            var response = ParcelRepository.GetParcels(parcelsRequest);

            var result = new ParcelOwnersResponse();

            if (response != null)
            {
                result.Error = response.Error;
                result.Events = response.Events;

                if (response.Parcels != null && response.Parcels.Count > 0)
                {
                    result.Owners = response.Parcels[0].Owners;
                }
            }

            return result;
        }

        public ParcelsResponse GetParcels(ParcelsRequest request)
        {
            //Defined returnElement of Parcel in AA: ConditionTemplate?Contacts?CAPs?Addresses?CompactAddresses
            request.Elements = new List<string>() { "Basic" };

            ParcelsResponse response = ParcelRepository.GetParcels(request);
            return response;
        }

        public AddressesResponse GetParcelAddresses(ParcelAddressesRequest request)
        {
            var parcelsRequest = new ParcelsRequest();

            parcelsRequest.Criteria = new ParcelCriteria();
            parcelsRequest.Criteria.ParcelIds = new List<string>() { request.ParcelId };

            parcelsRequest.Elements = new List<string>() { "Addresses" };

            var response = ParcelRepository.GetParcels(parcelsRequest);

            var result = new AddressesResponse();

            if (response == null || response.Parcels == null || response.Parcels.Count == 0)
            {
                throw new NotFoundException("The parcel didn't exist");
            }

            result.Error = response.Error;
            result.Events = response.Events;

            result.Addresses = response.Parcels[0].Addresses;

            return result;
        }
    }
}
