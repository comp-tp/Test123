using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.WSModels.Records;
using Accela.Apps.Apis.WSModels.RecordStatus;
using Accela.Apps.Apis.WSModels.RecordTypes;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Apis.WSModels.Common;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.StandardChoices;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;
using Accela.Apps.Apis.Services.Handlers.Models;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system/record")]
    [APIControllerInfoAttribute(Name = "Records", Group = "Entities", Order = 14, Description = "System Record REST API")]
    public class SystemRecordController : ControllerBase
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

        //private IReferenceBusinessEntity _referenceBusinessEntity = null;
        private readonly IReferenceBusinessEntity referenceBusinessEntity;
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

        //private IASIBusinessEntity asiBusinessEntity = null;
        private readonly IASIBusinessEntity asiBusinessEntity;
        //{
        //    get
        //    {
        //        if (asiBusinessEntity == null)
        //        {
        //            asiBusinessEntity = IocContainer.Resolve<IASIBusinessEntity>();
        //        }

        //        return asiBusinessEntity;
        //    }
        //}

        public SystemRecordController(IReferenceBusinessEntity referenceBusinessEntity, IASIBusinessEntity asiBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
            this.asiBusinessEntity = asiBusinessEntity;
        }

        [Route("types")]
        [APIActionInfoAttribute(Name = "Describe Record Types", Order=0, Scope = "get_ref_record_types", Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves record types by the module.")]
        public WSRecordTypesResponse GetRecordTypes(string module = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new RecordTypesRequest();
            request.Module = module;
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<RecordTypesResponse, RecordTypesRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetRecordTypes(o);
                },
                request);

            var result = WSRecordTypesResponse.FromEntityModel(tempResult);
            return result;
        }

        [Route("types/{recordTypeId}")]
        [APIActionInfoAttribute(Name = "Describe Record Type", Order = 1, Scope = "get_ref_record_type", Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves record type by its id.")]
        public WSRecordTypeResponse GetRecordType(string recordTypeId)
        {
            var request = new RecordTypesRequest();
            request.Module = recordTypeId.Split('-')[0];
            request.RecordTypeId = recordTypeId;

            var tempResult = this.ExcuteV1_2<RecordTypesResponse, RecordTypesRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetRecordTypes(o);
                },
                request);

            var result = WSRecordTypeResponse.FromEntityModel(tempResult);
            return result;
        }

        [Route("workordertemplates")]
        [APIActionInfoAttribute(Name = "Describe Work Order Templates", Order=2, Scope = "get_ref_work_order_templates", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves work order templates given the agency.")]
        public WSSystemWorkOrderTemplateResponse GetWorkOrderTemplates(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            WorkOrderTemplateRequest request = new WorkOrderTemplateRequest();
            SetPageRangeToRequest(request, offset, limit);

            var response = this.ExcuteV1_2<WorkOrderTemplateResponse, WorkOrderTemplateRequest>
                (
                    o => referenceBusinessEntity.GetWorkOrderTemplates(o),
                    request);

            return WSSystemWorkOrderTemplateResponse.FromEntityModel(response);
        }

        [Route("type/{id}/asis")]
        [APIActionInfoAttribute(Name = "Describe ASI", Order = 3, Scope = "get_ref_record_type_asis", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information about the record type.")]
        public WSASIResponse GetRecordTypeAdditionals(string id)
        {

            AdditionalRequest request = new AdditionalRequest();
            request.RelatedId = id;


            var response = this.ExcuteV1_2<AdditionalResponse, AdditionalRequest>
                (
                (o) => { return referenceBusinessEntity.GetRecordTypeAdditionals(o); },
                request);

            return WSASIResponse.FromEntityModel(response);

        }

        [Route("type/{id}/asis/drilldowns/{drilldownid}")]
        [APIActionInfoAttribute(Name = "Describe ASI Drilldown", Order = 3, Scope = "get_ref_asis_drilldown", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information's drilldown about the record type.")]
        public WSDrillDownValuesResponse GetRecordTypeAdditionalDrilldown(string id, string drilldownid, string parentvalueid = null)
        {
            AdditionalRequest request = new AdditionalRequest();
            request.RelatedId = id;


            var response = this.ExcuteV1_2<AdditionalResponse, AdditionalRequest>
                ((o) => { return referenceBusinessEntity.GetRecordTypeAdditionals(o); },
                request);


            if (response != null && response.Additionals != null && response.Additionals.Count > 0)
            {
                DrillDownValuesResponse drillDownValuesResponse = null;
                if (string.IsNullOrEmpty(parentvalueid))
                {
                    drillDownValuesResponse = asiBusinessEntity.GetASIDrilldownValue(drilldownid, response.Additionals);
                }
                else
                {
                    drillDownValuesResponse = asiBusinessEntity.GetASIDrilldownValueByParent(drilldownid, parentvalueid, response.Additionals);
                }
                return WSDrillDownValuesResponse.FromEntityModel(drillDownValuesResponse);
            }

            return new WSDrillDownValuesResponse();
        }

        [Route("type/{id}/asits")]
        [APIActionInfoAttribute(Name = "Describe ASIT",Order=4, Scope = "get_ref_record_type_asits", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information tables for the record type.")]
        public WSASITResponse GetRecordTypeAdditionalTables(string id)
        {

            AdditionalTableRequest request = new AdditionalTableRequest();
            request.RelatedId = id;


            var response = this.ExcuteV1_2<AdditionalTableResponse, AdditionalTableRequest>
                (
                (o) => { return referenceBusinessEntity.GetRecordTypeAdditionalTables(o); },
                request);

            return WSASITResponse.FromEntityModel(response);

        }

        [Route("type/{id}/asits/drilldowns/{drilldownid}")]
        [APIActionInfoAttribute(Name = "Describe ASIT Drilldown", Order = 4, Scope = "get_ref_asit_drilldown", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information tables's drilldown for the record type.")]
        public WSDrillDownValuesResponse GetRecordTypeAdditionalTableDrilldown(string id, string drilldownid, string parentvalueid = null)
        {
            AdditionalTableRequest request = new AdditionalTableRequest();
            request.RelatedId = id;

            var response = this.ExcuteV1_2<AdditionalTableResponse, AdditionalTableRequest>
                ((o) => { return referenceBusinessEntity.GetRecordTypeAdditionalTables(o); },
                request);

            if (response != null && response.AdditionalTables != null && response.AdditionalTables.Count > 0)
            {     
                DrillDownValuesResponse drillDownValuesResponse = null;               
                if (string.IsNullOrEmpty(parentvalueid))
                {
                    drillDownValuesResponse = asiBusinessEntity.GetASITDrilldownValue(drilldownid, response.AdditionalTables);
                }
                else
                {
                    drillDownValuesResponse = asiBusinessEntity.GetASITDrilldownValueByParent(drilldownid, parentvalueid, response.AdditionalTables);
                }       

                return WSDrillDownValuesResponse.FromEntityModel(drillDownValuesResponse);
            }
            return new WSDrillDownValuesResponse();
        }

        [Route("type/{typeId}/statuses")]
        [APIActionInfoAttribute(Name = "Describe Record Status", Order=6, Scope = "get_ref_record_type_statuses", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves status of the record specified by the record type.")]
        public WSRecordStatusesResponse GetRecordStatusByType(string typeId)
        {

            RecordStatusesRequest request = new RecordStatusesRequest();
            request.RecordTypeId = typeId;

            var response = this.ExcuteV1_2<RecordStatusesResponse, RecordStatusesRequest>
                (
                (o) => { return referenceBusinessEntity.GetRecordStatusByType(o); },
                request);

            return WSRecordStatusesResponse.FromEntityModel(response);

        }

        [Route("priorities")]
        [APIActionInfoAttribute(Name = "Describe Priorities",Order=5, Scope = "get_ref_record_priorities", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves priorities of the reference records.")]
        public WSRecordPrioritiesResponse GetPriorities()
        {

            var request = new RecordPrioritiesRequest();

            var entityResponse = this.ExcuteV1_2<RecordPrioritiesResponse, RecordPrioritiesRequest>(
                                    (o) =>
                                    {
                                        return referenceBusinessEntity.GetRecordPriorities(o);
                                    },
                                    request);

            return WSRecordPrioritiesResponse.FromEntityModel(entityResponse);

        }

        [Route("workordertask/units")]
        [APIActionInfoAttribute(Name = "Describe Work Order Task Unit", Order = 7, Scope = "get_ref_workordertask_units", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get work order task unit.")]
        public WSGetWorkOrderTaskUnitResponse GetWorkOrderTaskUnit(string lang = null)
        {
            var request = new GetStandardChoicesRequest();
            request.StandardChoiceType = "WO_TASK_DURATION_UNIT";

            var standardChoicesResponse = this.ExcuteV1_2<StandardChoicesResponse, GetStandardChoicesRequest>(
              (o) =>
              {
                  return referenceBusinessEntity.GetStandardChoices(o);
              },
              request);

            var result = WSGetWorkOrderTaskUnitResponse.FromEntityModel(standardChoicesResponse);
            return result;
        }
    }
}
