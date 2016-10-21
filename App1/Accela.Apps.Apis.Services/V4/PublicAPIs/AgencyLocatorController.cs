using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Apps.Apis.WSModels.Agency.V4;
using Accela.Apps.Shared;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System.Web.Http;

namespace Accela.Apps.Apis.Services.V4
{
    [RoutePrefix("v4/search")]
    public class AgencyLocatorV4Controller : ControllerBase
    {
        private IAgencySpatialDataEntity _agencySpatialDataEntity = null;
        private IAgencySpatialDataEntity agencySpatialDataEntity;
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

        public AgencyLocatorV4Controller(IAgencySpatialDataEntity agencySpatialDataEntity)
        {
            this.agencySpatialDataEntity = agencySpatialDataEntity;
        }

        [HttpPost]
        [POST("agencies")]
        public WSGeoSearchAgenciesV4Response SearchAgencyByCoordinate([FromBody] WSGeoSearchAgenciesV4Request wsRequest, string lang = null)
        {
            var request = new GeoSearchAgenciesRequest()
            {
                Longitude = wsRequest.Longitude,
                Latitude = wsRequest.Latitude
            };

            var tempResult = this.ExcuteV1_2<GeoSearchAgenciesResponse, GeoSearchAgenciesRequest>(
                                (o) => agencySpatialDataEntity.SearchAgencyByCoordinate(o),
                                request);

            return WSGeoSearchAgenciesV4Response.FromEntityModel(tempResult);
        }
    }
}
