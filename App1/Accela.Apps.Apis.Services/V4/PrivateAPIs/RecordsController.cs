using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.WSModels.V4;
using Accela.Apps.Apis.WSModels.V4.RecordLocation;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;

using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http;

namespace Accela.Apps.Apis.Services.V4
{
    [RoutePrefix("v4/search/records")]
    public class RecordsV4PrivateController : ControllerBase
    {
        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    var tmpParams = new Dictionary<string, object>
        //    {
        //        {"appId", Context.App},
        //        {"agencyName", Context.Agency},
        //        {"serviceProvCode", Context.ServProvCode},
        //        {"agencyUserId", Context.CurrentUser.Id.ToString()},
        //        {"agencyUsername", Context.LoginName},
        //        {"token", Context.SocialToken},
        //        {"environmentName", Context.EnvName},
        //        {"language", Context.Language}
        //    };

        //    return tmpParams;
        //}

        //private IRecordBusinessEntity _recordBusinessEntity = null;
        private readonly IRecordBusinessEntity recordBusinessEntity;
        //{
        //    get
        //    {
        //        if (_recordBusinessEntity == null)
        //        {
        //            var ctorParams = MakeConstructorParameters();
        //            _recordBusinessEntity = IocContainer.Resolve<IRecordBusinessEntity>(ctorParams);
        //        }

        //        return _recordBusinessEntity;
        //    }
        //}

        public RecordsV4PrivateController(IRecordBusinessEntity recordBusinessEntity)
        {
            this.recordBusinessEntity = recordBusinessEntity;
        }

        [HttpPost]
        [Route("location")]
        public WSLocationV4Response GetRecordLocation([FromBody]WSLocationV4Request locationRequest)
        {
            if (locationRequest == null || locationRequest.Ids == null)
            {
                //throw new ArgumentNullException("ids cannot be empty.");
                throw new MobileException("ids cannot be empty in the JSON request body.");
            }

            var request = new RecordLocationRequest
            {
                Criteria = new RecordCriteria { RecordIds = locationRequest.Ids }
            };

            var entityResponse = ExcuteV1_2<RecordsLocationResponse, RecordLocationRequest>(
                                    (o) => recordBusinessEntity.GetRecordsLocation(o),
                                    request);

            return WSLocationV4Response.FromEntityModel(entityResponse);
        }
    }
}
