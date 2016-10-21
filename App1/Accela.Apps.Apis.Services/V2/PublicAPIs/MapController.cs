using System;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Apis.WSModels.Geo;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using System.Web.Script.Serialization;
using Accela.Apps.Shared.Exceptions;
using System.Web;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/geo")]
    [APIControllerInfoAttribute(Name = "Geocoding", Group = "Geo", Order = 5, Description = "")]
    public class MapController : ControllerBase
    {
        private readonly IMapBusinessEntity mapBusinessEntity;
        
        private readonly IAgencyAppContext agencyContext;
        public MapController(IMapBusinessEntity mapBusinessEntity, IAgencySpatialDataEntity agencySpatialDataEntity, IAgencyAppContext agencyContext)
        {
            this.mapBusinessEntity = mapBusinessEntity;
            this.agencySpatialDataEntity = agencySpatialDataEntity;
            this.agencyContext = agencyContext;
        }
        private readonly IAgencySpatialDataEntity agencySpatialDataEntity;

        [Route("geocode/reverse")]
        [APIActionInfoAttribute(Name = "Reverse Geocode Address", Scope = "reverse_geocode", Order = 1, Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves an address by the longitude, latitude and distance (optional).")]
        public WSGetAddressByCoordinateResponse GetAddressByCoordinate([FromUri]string longitude, [FromUri]string latitude, [FromUri] string distance = "100", [FromUri]string inSR = "4326")
        {
            distance = String.IsNullOrWhiteSpace(distance) ? "100" : distance;
            GetAddressByCoordinateRequest request = new GetAddressByCoordinateRequest();
            request.Longitude = System.Convert.ToDouble(longitude);
            request.Latitude = System.Convert.ToDouble(latitude);
            request.Distance = System.Convert.ToDouble(distance);
            request.InSR = String.IsNullOrWhiteSpace(inSR) ? "4326" : inSR;

            var entityResponse = this.ExcuteV1_2<GetAddressByCoordinateResponse, GetAddressByCoordinateRequest>(
                                (o) =>
                                {
                                    return mapBusinessEntity.GetAddressByCoordinate(o, agencyContext);
                                },
                                request);

            return WSGetAddressByCoordinateResponse.FromEntityModel(entityResponse.Address);
        }

        /// <summary>
        /// schema same as ArcGis
        /// sample: {"records":[{"attributes":{"OBJECTID":0,"SINGLELINEINPUT":"1414 21st St, Sacramento, California, 95811"}}]}
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("geocode/geocodeaddresses")]
        [APIActionInfoAttribute(Name = "Geocode Addresses", Scope = "geocode_addresses", Order = 1, Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves a list of longitude, latitude by a list of address.")]
        public WSGetCoordinatesByAddressesResponse GetCoordinatesByAddresses()
        {
            var task = Request.Content.ReadAsStringAsync();
            var formData = task.Result;

            var formDataModel = !String.IsNullOrWhiteSpace(formData) ? HttpUtility.ParseQueryString(formData) : null;
            string addresses = formDataModel != null ? formDataModel["addresses"] : null;
            string outSR = formDataModel != null ? formDataModel["outSR"] : null;
            string cacheEnabled = formDataModel != null ? formDataModel["cacheEnabled"] : null;

            if (String.IsNullOrWhiteSpace(addresses))
            {
                throw new BadRequestException("Invalid parameters.", "Addresses is required.", ErrorCodes.bad_request_400);
            }

            outSR = String.IsNullOrWhiteSpace(outSR) ? "4326" : outSR;
            var tempCacheEnabled = !String.IsNullOrWhiteSpace(cacheEnabled) ? "true".Equals(cacheEnabled, StringComparison.OrdinalIgnoreCase) : true;
            var serializer = new JavaScriptSerializer();
            var wsRequest = !String.IsNullOrWhiteSpace(addresses) ? serializer.Deserialize<WSGetCoordinatesByAddressesRequest>(addresses) : null;
            if (wsRequest != null)
            {
                wsRequest.OutSR = outSR;
                wsRequest.CacheEnabled = tempCacheEnabled;
            }
            //var wsRequest = JsonConverter.FromJsonTo<WSGetCoordinatesByAddressesRequest>(addresses);
            var request = WSGetCoordinatesByAddressesRequest.ToEntityModel(wsRequest);

            var entityResponse = this.ExcuteV1_2<GeoGetCoordinatesByAddressesResponse, GeoGetCoordinatesByAddressesRequest>(
                                (o) =>
                                {
                                    return mapBusinessEntity.GetCoordinates(o);
                                },
                                request);

            return WSGetCoordinatesByAddressesResponse.FromEntityModel(entityResponse);
        }
    }
}
