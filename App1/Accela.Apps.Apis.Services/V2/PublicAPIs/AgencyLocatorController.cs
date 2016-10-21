using System.Collections.Generic;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Agency;
using Accela.Apps.Shared;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Accela.Apps.Apis.Services.V2.PublicAPIs
{
    [RoutePrefix("v3/geo")]
    [APIControllerInfoAttribute(Name = "Agency Locator", Group = "Geo", Order = 6, Description = "The following API is exposed to GIS settings.")]
    public class AgencyLocatorController : ControllerBase
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

        //private IRecordBusinessEntity _recordBusinessEntity = null;
        private readonly IRecordBusinessEntity recordBusinessEntity;
        //{
        //    get
        //    {
        //        if (_recordBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _recordBusinessEntity = IocContainer.Resolve<IRecordBusinessEntity>(ctorParams);
        //        }

        //        return _recordBusinessEntity;
        //    }
        //}

        public AgencyLocatorController(IRecordBusinessEntity recordBusinessEntity, IAgencySpatialDataEntity agencySpatialDataEntity)
        {
            this.recordBusinessEntity = recordBusinessEntity;
            this.agencySpatialDataEntity = agencySpatialDataEntity;
        }

        //private IAgencySpatialDataEntity _agencySpatialDataEntity = null;
        private readonly IAgencySpatialDataEntity agencySpatialDataEntity;
        //{
        //    get
        //    {
        //        if (_agencySpatialDataEntity == null)
        //        {
        //            _agencySpatialDataEntity = IocContainer.Resolve<IAgencySpatialDataEntity>();
        //        }

        //        return _agencySpatialDataEntity;
        //    }
        //}

        [HttpPost]
        [POST("search/agencies")]
        [APIActionInfoAttribute(Name = "Search Agencies By Coordinates", Order = 1, Scope = "search_agencies_by_geo", Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves an agency given the longitude and latitude.")]
        public WSGeoSearchAgenciesResponse SearchAgencyByCoordinate([FromBody] WSGeoSearchAgenciesRequest wsRequest, string lang = null)
        {
            var request = new GeoSearchAgenciesRequest()
            {
                Longitude = wsRequest.Longitude,
                Latitude = wsRequest.Latitude
            };

            var tempResult = this.ExcuteV1_2<GeoSearchAgenciesResponse, GeoSearchAgenciesRequest>(
                                (o) =>
                                {
                                    return agencySpatialDataEntity.SearchAgencyByCoordinate(o);
                                },
                                request);

            return WSGeoSearchAgenciesResponse.FromEntityModel(tempResult);
        }
    }
}
