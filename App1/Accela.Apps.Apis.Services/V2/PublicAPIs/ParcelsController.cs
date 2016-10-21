using System.Collections.Generic;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.WSModels.Parcels;
using Accela.Apps.Shared;

using System.Web.Http;


namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/parcels")]
    [APIControllerInfoAttribute(Name = "Parcels", Group = "Entities", Order=8, Description = "The following APIs are exposed to parcel.")]
    public class ParcelsController : ControllerBase
    {
        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

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

        //private IParcelBusinessEntity _parcelBusinessEntity = null;
        private readonly IParcelBusinessEntity parcelBusinessEntity;
        //{
        //    get
        //    {
        //        if (_parcelBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _parcelBusinessEntity = IocContainer.Resolve<IParcelBusinessEntity>(ctorParams);
        //        }

        //        return _parcelBusinessEntity;
        //    }
        //}


        public ParcelsController(IParcelBusinessEntity parcelBusinessEntity)
        {
            this.parcelBusinessEntity = parcelBusinessEntity;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Simple Search Parcels", Scope = "get_parcels", Order=2, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves parcels meeting the query parameters. The parcel IDs should be comma separated.")]
        public WSParcelsResponse GetParcels([FromUri]string parcelIds = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            ParcelsRequest request = new ParcelsRequest();

            request.Criteria = new ParcelCriteria();
            this.SetPageRangeToRequest(request, offset, limit);

            request.Criteria.ParcelIds = this.SpliteIdsToList(parcelIds);

            var parcelsResponse = this.ExcuteV1_2<ParcelsResponse, ParcelsRequest>(
                (o) =>
                {
                    return parcelBusinessEntity.GetParcels(o);
                },
                request);

            return WSParcelsResponse.FromEntityModel(parcelsResponse);

        }

        [Route("{ids}")]
        [APIActionInfoAttribute(Name = "Get Parcels By Ids", Scope = "get_parcel", Order=3, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Return parcels by specific queries. The Ids should be &quot;id,id&quot;. Each id will use &quot;,&quot; as separator.")]
        public WSParcelsResponseNoPaging GetParcelsByIds(string ids)
        {
            ParcelsRequest request = new ParcelsRequest();

            request.Criteria = new ParcelCriteria();

            request.Criteria.ParcelIds = this.SpliteIdsToList(ids);

            var parcelsResponse = this.ExcuteV1_2<ParcelsResponse, ParcelsRequest>(
                (o) =>
                {
                    return parcelBusinessEntity.GetParcels(o);
                },
                request);

            return WSParcelsResponseNoPaging.FromEntityModel(parcelsResponse);

        }

        [Route("{id}/owners")]
        [APIActionInfoAttribute(Name = "Get Parcel's Owners", Scope = "get_parcel_owners", Order=4, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves owners for the specific parcel.")]
        public WSParcelOwnersResponse GetParcelOwners(string id)
        {

            var request = new ParcelOwnersRequest();
            request.ParcelId = id;

            var tempResult = this.ExcuteV1_2<ParcelOwnersResponse, ParcelOwnersRequest>(
                (o) =>
                {
                    return parcelBusinessEntity.GetParcelOwners(o);
                },
                request);

            var result = WSParcelOwnersResponse.FromEntityModel(tempResult);
            return result;

        }

        [Route("{id}/addresses")]
        [APIActionInfoAttribute(Name = "Get Parcel's Addresses", Order = 5, Scope = "get_parcel_addresses", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves addresses for the specific parcel.")]
        public WSAddressesResponse GetParcelAddresses(string id)
        {

            ParcelAddressesRequest request = new ParcelAddressesRequest();

            request.ParcelId = id;

            var entityResponse = this.ExcuteV1_2<AddressesResponse, ParcelAddressesRequest>(
                                    (o) =>
                                    {
                                        return parcelBusinessEntity.GetParcelAddresses(o);
                                    },
                                    request);

            return WSAddressesResponse.FromEntityModel(entityResponse);

        }
    }
}
