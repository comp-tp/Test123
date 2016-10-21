using System.Collections.Generic;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Parcels;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/search/parcels")]
    [APIControllerInfoAttribute(Name = "Parcels", Group = "Entities", Order = 8, Description = "")]
    public class ParcelsSearchController : ControllerBase
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

        public ParcelsSearchController(IParcelBusinessEntity parcelBusinessEntity)
        {
            this.parcelBusinessEntity = parcelBusinessEntity;
        }

        [HttpPost]
        [Route("")]
        [APIActionInfoAttribute(Name = "Search Parcels", Scope = "search_parcels", Order=1, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Return relevant parcels by specific queries. In this API. For Ids, The Ids should be &quot;id,id&quot;. Each id will use &quot;,&quot; as separator.")]
        public WSParcelsResponse GetParcels(WSParcelsSearchRequest wsParcelsSearchRequest, string expand = null, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            ParcelsRequest request = SetParcelsQueryRequest(offset, limit, wsParcelsSearchRequest);
            request.Elements = this.GetReturnElements(expand);
            var parcelsResponse = this.ExcuteV1_2<ParcelsResponse, ParcelsRequest>(
                                    (o) =>
                                    {
                                        return parcelBusinessEntity.GetParcels(o);
                                    },
                                    request);

            return WSParcelsResponse.FromEntityModel(parcelsResponse);


        }

        private ParcelsRequest SetParcelsQueryRequest(int offset, int limit, WSParcelsSearchRequest wsParcelsSearchRequest)
        {
            ParcelsRequest request = new ParcelsRequest();
            request.Criteria = new ParcelCriteria();
            SetPageRangeToRequest(request, offset, limit);
            if (wsParcelsSearchRequest != null)
            {
                if (wsParcelsSearchRequest.ParcelFilter != null)
                {
                    request.Criteria.ParcelIds = wsParcelsSearchRequest.ParcelFilter.ParcelIds;
                    request.Criteria.AddressNumber = wsParcelsSearchRequest.ParcelFilter.Number;
                    request.Criteria.AddressFraction = wsParcelsSearchRequest.ParcelFilter.Fraction;
                    request.Criteria.AddressPrefix = wsParcelsSearchRequest.ParcelFilter.Prefix;
                    request.Criteria.AddressStreet = wsParcelsSearchRequest.ParcelFilter.Street;
                    request.Criteria.AddressType = wsParcelsSearchRequest.ParcelFilter.Type;
                    request.Criteria.AddressSuffix = wsParcelsSearchRequest.ParcelFilter.Suffix;
                    request.Criteria.AddressUnit = wsParcelsSearchRequest.ParcelFilter.Unit;
                    request.Criteria.AddressUnitType = wsParcelsSearchRequest.ParcelFilter.UnitType;
                    request.Criteria.City = wsParcelsSearchRequest.ParcelFilter.City;
                    request.Criteria.State = wsParcelsSearchRequest.ParcelFilter.State;
                    request.Criteria.Zip = wsParcelsSearchRequest.ParcelFilter.ZipCode;
                    if (wsParcelsSearchRequest.ParcelFilter.GisObjects != null &&
                       wsParcelsSearchRequest.ParcelFilter.GisObjects.Count > 0)
                    {
                        request.Criteria.GisObjects = new List<Accela.Apps.Apis.Models.DTOs.GisObject>();
                        foreach (var gisObject in wsParcelsSearchRequest.ParcelFilter.GisObjects)
                        {
                            var gisObj = new Accela.Apps.Apis.Models.DTOs.GisObject();
                            gisObj.ID = gisObject.ID;
                            gisObj.MapService = gisObject.MapService;
                            gisObj.LayerId = gisObject.LayerId;
                            request.Criteria.GisObjects.Add(gisObj);
                        }
                    }
                }
            }

            return request;
        }
    }
}
