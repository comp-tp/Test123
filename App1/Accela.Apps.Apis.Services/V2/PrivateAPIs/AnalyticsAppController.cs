using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.WSModels.RecordSummary;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Apis.Services.Attributes;
using System.Web.Http;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/analytics")]
    [APIControllerInfoAttribute(Name = "Analytics", Description = "The following API is exposed to analytics information.")]
    public class AnalyticsAppController : ControllerBase
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
        private readonly IReferenceBusinessEntity referenceBusinessEntity;
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

        public AnalyticsAppController(IRecordBusinessEntity recordBusinessEntity, IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.recordBusinessEntity = recordBusinessEntity;
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

     //   private IReferenceBusinessEntity _referenceBusinessEntity = null;
    
        //{
        //    get
        //    {
        //        if (_referenceBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _referenceBusinessEntity = IocContainer.Resolve<IReferenceBusinessEntity>(ctorParams);
        //        }

        //        return _referenceBusinessEntity;
        //    }
        //}

        /// <summary>
        /// Counts the daily records.
        /// </summary>
        /// <param name="lang">The lang.</param>
        /// <param name="wsRequest">The ws request.</param>
        /// <returns>
        /// the daily records count.
        /// </returns>
        [HttpPost]
        [Route("record/chart/dailycount")]
        [APIActionInfoAttribute(Name = "Get record daily count", Scope = "analytics_get_record_daily_count", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves the number of daily records matching the query.")]
        public WSDailyRecordsCountResponse CountDailyRecords([FromBody]WSDailyRecordsCountRequest wsRequest, string lang = null)
        {

            var entityRequest = WSDailyRecordsCountRequest.ToEntityModel(wsRequest);
            var recordsResponse = this.ExcuteV1_2<DailyRecordsCountResponse, DailyRecordsCountRequest>(
                                    (o) =>
                                    {
                                        return recordBusinessEntity.CountDailyRecords(o);
                                    },
                                    entityRequest);

            return WSDailyRecordsCountResponse.FromEntityModel(recordsResponse);

        }
    }
}
