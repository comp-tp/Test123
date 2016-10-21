using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ChecklistRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectorRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectorResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Checklists;
using Accela.Apps.Apis.WSModels.Inspections;
using Accela.Apps.Apis.WSModels.V1.Inspectors;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system/inspection")]
    [APIControllerInfoAttribute(Name = "Inspections", Group = "Entities", Order = 15, Description = "")]
    public class SystemInspectionsController : ControllerBase
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

        //private IChecklistBusinessEntity _checkListBusinessEntity = null;
        private readonly IChecklistBusinessEntity checklistBusinessEntity;
        //{
        //    get
        //    {
        //        if (_checkListBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _checkListBusinessEntity = IocContainer.Resolve<IChecklistBusinessEntity>(ctorParams);
        //        }
        //        return _checkListBusinessEntity;
        //    }
        //}

        public SystemInspectionsController(IReferenceBusinessEntity referenceBusinessEntity, IChecklistBusinessEntity checklistBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
            this.checklistBusinessEntity = checklistBusinessEntity;
        }


        [Route("groups")]
        [APIActionInfoAttribute(Name = "Describe Inspection Groups", Order = 1, Scope = "get_ref_inspection_groups", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspection groups given the agency.")]
        public WSInspectionGroupResponse GetInspectoinGroups(int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            var request = new InspectionGroupRequest();
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<InspectionGroupResponse, InspectionGroupRequest>(
               (o) =>
               {
                   return referenceBusinessEntity.GetInspectoinGroups(o);
               },
               request);
            var result = WSInspectionGroupResponse.FromEntityModel(tempResult);
            return result;

        }

        [Route("groups/{id}/types")]
        [APIActionInfoAttribute(Name = "Describe Inspection Types", Order = 2, Scope = "get_ref_inspection_types", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspection types of the given inspection group.")]
        public WSSystemInspectionTypeResponse GetInspectionTypes(string id, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            var request = new SystemInspectionTypeRequest() { InspectionGroupId = id };
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<SystemInspectionTypeResponse, SystemInspectionTypeRequest>(
               o => referenceBusinessEntity.GetSystemInspectionTypes(o), request);
            return WSSystemInspectionTypeResponse.FromEntityModel(tempResult);

        }

        [Route("inspectors")]
        [APIActionInfoAttribute(Name = "Get Inspectors", Scope = "get_ref_inspectors", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspectors given the agency.")]
        public WSSystemInspectorResponse GetInspectors(int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            SystemInspectorRequest request = new SystemInspectorRequest();
            SetPageRangeToRequest(request, offset, limit);

            var response = this.ExcuteV1_2<SystemInspectorResponse, SystemInspectorRequest>
                (
                    o => referenceBusinessEntity.GetSystemInspectors(o),
                    request);

            return WSSystemInspectorResponse.FromEntityModel(response);


        }

        [Route("checklist/groups")]
        [APIActionInfoAttribute(Name = "Describe Inspection Checklists", Order = 3, Scope = "get_ref_inspection_checklist_groups", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspection checklist groups given the agency.")]
        public WSGetChecklistGroupResponse GetChecklistGroups(int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            var request = new GetChecklistGroupRequest();
            SetPageRangeToRequest(request, offset, limit);

            var checklistGroupResponse = this.ExcuteV1_2<GetChecklistGroupResponse, GetChecklistGroupRequest>(
               (o) =>
               {
                   return checklistBusinessEntity.GetChecklistGroups(o);
               },
               request);
            return WSGetChecklistGroupResponse.FromEntityModel(checklistGroupResponse);

        }
    }
}
