using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Shared;

using System.Web.Http;
using System.Collections.Generic;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Shared.Utils;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/addresses")]
    [APIControllerInfoAttribute(Name = "Addresses", Group = "Entities", Order = 7, Description = "The following APIs are related to addresses.")]
    public class AddressesController : ControllerBase
    {
        //private IAddressBusinessEntity _addressBusinessEntity = null;
        private readonly IAddressBusinessEntity addressBusinessEntity;
        //{
        //    get
        //    {
        //        if (_addressBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _addressBusinessEntity = IocContainer.Resolve<IAddressBusinessEntity>(ctorParams);
        //        }

        //        return _addressBusinessEntity;
        //    }
        //}



        public AddressesController(IAddressBusinessEntity addressBusinessEntity)
        {
            this.addressBusinessEntity = addressBusinessEntity;
        }
        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

        //    //tmpParams.Add("appId", "com.accela.inspector");
        //    //tmpParams.Add("agencyName", "SOUTHLK-Name");
        //    //tmpParams.Add("serviceProvCode", "SOUTHLK");
        //    //tmpParams.Add("agencyUserId", "D832F47C-C10A-4354-885C-4C73D3E16CD3");
        //    //tmpParams.Add("agencyUsername", "admin");
        //    //tmpParams.Add("token", "12209498502521460855");
        //    //tmpParams.Add("environmentName", "TEST");
        //    //tmpParams.Add("language", "en-US");

        //    tmpParams.Add("appId", Context.App);
        //    tmpParams.Add("agencyName", Context.Agency);
        //    tmpParams.Add("serviceProvCode", Context.ServProvCode);
        //    tmpParams.Add("agencyUserId", Context.CurrentUser.Id.ToString());
        //    tmpParams.Add("agencyUsername", Context.LoginName);
        //    tmpParams.Add("token", Context.SocialToken);
        //    tmpParams.Add("environmentName", Context.EnvName);
        //    tmpParams.Add("language", Context.Language);

        //    return tmpParams;
        //}

        [Route("")]
        [APIActionInfoAttribute(Name = "Search Address", Scope = "get_addresses", Order=2, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns relevant addresses that match a specified query.")]
        public WSAddressesResponse GetAddresses(string lang = null, int offset = 0, int limit = 0, string houseNumber = null, string houseNumberFraction = null, string streetDirection = null, string streetName = null, string streetSuffixDirection = null, string streetSuffix = null, string unitStart = null, string unitEnd = null, string unitType = null, string city = null, string state = null, string zipCode = null, string includeDisabled = null)
        {
            AddressesRequest request = new AddressesRequest();

            SetPageRangeToRequest(request, offset, limit);

            request.Criteria = new AddressCriteria
            {
                HouseNumber = houseNumber,
                HouseNumberFraction = houseNumberFraction,
                StreetDirection = streetDirection,
                StreetName = streetName,
                StreetSuffix = streetSuffix,
                StreetSuffixDirection = streetSuffixDirection,
                Unit = unitStart,
                UnitEnd = unitEnd,
                UnitType = unitType,
                City = city,
                State = state,
                PostalCode = zipCode,
                IncludeDisabled = BoolHelper.IsTrueString(includeDisabled),
                IsPrimary = null
            };

            var entityResult = this.ExcuteV1_2<AddressesResponse, AddressesRequest>(
                                (o) =>
                                {
                                    return addressBusinessEntity.GetAddresses(o);
                                },
                                request);

            return WSAddressesResponse.FromEntityModel(entityResult);
        }

        [Route("{id}")]
        [APIActionInfoAttribute(Name = "Get Address", Scope = "get_address", Order=3, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves a single address matching the address ID.")]
        public WSAddressResponse GetAddress(string lang = null, string id = null)
        {

            var request = new AddressRequest();
            request.Criteria = new AddressCriteria();
            request.Criteria.Identifier = id;
            request.Criteria.IncludeDisabled = true;

            var addressResponse = this.ExcuteV1_2<AddressResponse, AddressRequest>(
                                (o) =>
                                {
                                    return addressBusinessEntity.GetAddress(o);
                                },
                                request);

            return WSAddressResponse.FromEntityModel(addressResponse);

        }
    }
}
