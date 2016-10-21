using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Automation.GovXmlClient.Model;


namespace Accela.Apps.Apis.Repositories.Agency
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        //public AddressRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //}

        public AddressRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {

        }

        public Models.DTOs.Responses.AddressResponses.AddressesResponse GetAddresses(Models.DTOs.Requests.AddressRequests.AddressesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getAddresses = new GetAddress();
            govXmlIn.getAddresses.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getAddresses.addresses = AddressHelper.ToDetailAddress(request.Criteria);

            GovXML response = CommonHelper.Post(govXmlIn, 
                                                govXmlIn.getAddresses.system,
                                                (o) => o.getAddressesResponse == null ? null : o.getAddressesResponse.system);

            Models.DTOs.Responses.AddressResponses.AddressesResponse results = AddressHelper.GetClientAddresses(response.getAddressesResponse);

            return results;
        }

        /// <summary>
        /// Get address by id.
        /// </summary>
        /// <param name="addressRequest">AddressRequest.</param>
        /// <returns>AddressResponse.</returns>
        public Models.DTOs.Responses.AddressResponses.AddressResponse GetAddress(Models.DTOs.Requests.AddressRequests.AddressRequest addressRequest)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getAddresses = new GetAddress();
            govXmlIn.getAddresses.system = CommonHelper.GetSystem(addressRequest, this.CurrentContext);
            govXmlIn.getAddresses.addresses = AddressHelper.ToDetailAddress(addressRequest.Criteria);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.getAddresses.system,
                                                (o) => o.getAddressesResponse == null ? null : o.getAddressesResponse.system);
            
            var results = AddressHelper.GetClientAddresses(response.getAddressesResponse);
            if (results != null && results.Addresses != null && results.Addresses.Count > 0)
            {
                return new Models.DTOs.Responses.AddressResponses.AddressResponse()
                {
                    Address = results.Addresses[0],
                    Error = results.Error,
                    Events = results.Events
                }; 
            }
            
            return null;
        }
    }
}
