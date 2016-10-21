using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.RecordConditions4V3p;
using Accela.Apps.Shared.Contexts;
using Accela.Infrastructure.Configurations;

using System.Web.Http;
using System;

namespace Accela.Apps.Apis.Services
{
    /// <summary>
    /// !!!!! IMPORTANT NOTE: !!!!!
    /// This is a temp API controler for condition proxy API issue which was caused by issued higher version of inspector App,
    /// as the App has used some proxy APIs which need higher AA/gateway versions.
    /// </summary>
    [RoutePrefix("v3p1/records")]
    public class RecordConditions4V3pController : ControllerBase
    {
        private const string RECORD = "CAP";

        private readonly IRecordBusinessEntity recordBusinessEntity;
        private readonly IConfigurationReader configurationReader;

        private readonly IAgencyAppContext agencyContext;

        public RecordConditions4V3pController(IRecordBusinessEntity recordBusinessEntity, IAgencyAppContext agencyContext, IConfigurationReader configurationReader)
        {
            this.recordBusinessEntity = recordBusinessEntity;
            this.agencyContext = agencyContext;
			this.configurationReader = configurationReader;
        }

        /// <summary>
        /// !!!!! IMPORTANT NOTE: !!!!!
        /// This is a temp API for condition proxy API issue which was caused by issued higher version of inspector App,
        /// as the App has used some proxy APIs which need higher AA/gateway versions.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lang"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        [Route("{id}/conditions")]
        [APIActionInfoAttribute(Name = "Get Record's Conditions", Order = 15, Scope = "get_record_conditions", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves conditions for the record by record ID and other parameters (optional).")]
        public WSRecordConditionsResponse4V3p GetConditions(string id, string lang = null, string priority = null)
        {
            var agencyPrefix = String.Format("{0}-", agencyContext.Agency);
            var agencyPrefixIndex = !String.IsNullOrWhiteSpace(id) ? id.IndexOf(agencyPrefix, StringComparison.OrdinalIgnoreCase) : -1;
            var originalId = agencyPrefixIndex != -1 ? id.Substring(agencyPrefixIndex + agencyPrefix.Length) : id;

            var request = new ConditionsRequest();
            request.RecordId = originalId;
            request.Filter = priority;

            var tempResult = ExcuteV1_2<ConditionsResponse, ConditionsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordConditions(o);
                },
                request);

            var result = WSRecordConditionsResponse4V3p.FromEntityModel(tempResult);
            return result;

        }

    }
}
