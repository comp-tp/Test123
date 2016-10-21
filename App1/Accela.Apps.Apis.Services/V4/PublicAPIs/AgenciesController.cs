using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.AgencyRequests;
using Accela.Apps.Apis.Models.DTOs.Responses;
using Accela.Apps.Apis.Models.DTOs.Responses.AgencyResponses;
//using Accela.Apps.Apis.Models.DTOs.V4.Agency;
using Accela.Apps.Apis.WSModels;
using Accela.Apps.Apis.WSModels.V4;
using Accela.Apps.Shared;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Accela.Apps.Apis.Services.V4
{
    [RoutePrefix("v4/agencies")]
    public class AgenciesV4Controller : ControllerBase
    {
        //private IAgencyBusinessEntity _agencyBusinessEntity = null;
        private readonly IAgencyBusinessEntity agencyBusinessEntity;
        //{
        //    get
        //    {
        //        if (_agencyBusinessEntity == null)
        //        {
        //            _agencyBusinessEntity = IocContainer.Resolve<IAgencyBusinessEntity>();
        //        }

        //        return _agencyBusinessEntity;
        //    }
        //}

        public AgenciesV4Controller(IAgencyBusinessEntity agencyBusinessEntity)
        {
            this.agencyBusinessEntity = agencyBusinessEntity;
        }

        // TODO: support pagination, order, filter on name, display name, etc.
        [GET("")]
        public WSListResponse<WSAgencyV4> GetAgencies(string name=null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST, 
            string order = null, string direction = null)
        {
            var request = new AgenciesRequest();
            SetPageRangeToRequest(request, offset, limit);

            var entityResponse = this.ExcuteV1_2<ListResponse<AgencyModel>, AgenciesRequest>(
                                (o) =>
                                {
                                    return agencyBusinessEntity.GetAgencies(o);
                                },
                                request);

            return new WSListResponse<WSAgencyV4>() { Data = WSAgencyV4.FromEntitiesModel(entityResponse.Data) };

        }

        //[GET("{name}")]
        //public WSAgencyV4Response GetAgency(string name)
        //{

        //    var request = new AgencyRequest();
        //    request.AgencyName = name;

        //    var entityResponse = this.ExcuteV1_2<AgencyResponse, AgencyRequest>(
        //                        (o) =>
        //                        {
        //                            return agencyBusinessEntity.GetAgency(o);
        //                        },
        //                        request);

        //    return WSAgencyV4Response.FromEntityModel(entityResponse);

        //}

        //[GET("{name}/environments")]
        //public WSAgencyEnvironmentsV4Response GetAgencyEnvironments(string name)
        //{
        //    var request = new AgencyEnvironmentsV4Request();
        //    request.AgencyName = name;
        //    var entityResponse = agencyBusinessEntity.GetAgencyEnvironments(request);

        //    return WSAgencyEnvironmentsV4Response.FromEntityModel(entityResponse);
        //}

    //    [GET("{name}/logo")]
    //    public HttpResponseMessage GetAgencyLogo(string name)
    //    {

    //        var request = new AgencyRequest();
    //        request.AgencyName = name;
    //        request.IsGetLogo = true;

    //        var agencyResponse = this.ExcuteV1_2<AgencyResponse, AgencyRequest>(
    //                            (o) =>
    //                            {
    //                                return agencyBusinessEntity.GetAgency(o);
    //                            },
    //                            request);


    //        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    //        if (agencyResponse.Error == null)
    //        {
    //            if (agencyResponse.Agency != null && !string.IsNullOrEmpty(agencyResponse.Agency.IconContent))
    //            {
    //                MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(agencyResponse.Agency.IconContent));

    //                string retImgType = "image/{0}";
    //                string iconName = agencyResponse.Agency.IconName;
    //                string imgType = Path.GetExtension(iconName).Replace(".", "");
    //                ms.Position = 0;
    //                result.Content = new StreamContent(ms);
    //                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(string.Format(retImgType,imgType));

    //            }
    //            else
    //            {
    //                result.StatusCode = HttpStatusCode.NotFound;
    //            }
    //        }
    //        else
    //        {
    //            string error = JsonConverter.ToJson(agencyResponse);
    //            result.StatusCode = HttpStatusCode.InternalServerError;
    //            result.Content = new StringContent(error);
    //            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    //        }

    //        return result;
    //    }
    }
}
