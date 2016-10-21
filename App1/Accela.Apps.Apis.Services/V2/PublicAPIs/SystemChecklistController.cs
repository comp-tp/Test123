using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ChecklistRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Checklists;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system/inspection/checklists")]
    public class SystemChecklistController : ControllerBase
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

        public SystemChecklistController(IChecklistBusinessEntity checklistBusinessEntity)
        {
            this.checklistBusinessEntity = checklistBusinessEntity;
        }

        [Route("{id}/items")]
        [APIActionInfoAttribute(Name = "Get Checklist Items", Scope = "get_ref_checklist_items", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves a list of checklist items of the specified checklist.")]
        public WSGetChecklistItemResponse GetChecklistItems(string id, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            var getChecklistItemRequest = new GetChecklistItemRequest();
            getChecklistItemRequest.ChecklistID = id;
            SetPageRangeToRequest(getChecklistItemRequest, offset, limit);

            var checklistItemResponse = this.ExcuteV1_2<GetChecklistItemResponse, GetChecklistItemRequest>(
               (o) =>
               {
                   return checklistBusinessEntity.GetChecklistItems(o);
               },
               getChecklistItemRequest);
            return WSGetChecklistItemResponse.FromEntityModel(checklistItemResponse);

        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Get Checklists", Scope = "get_ref_checklists", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves a list of checklists from reference data.")]
        public WSGetChecklistResponse GetChecklists(string groupid = null, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            var getChecklistRequest = new GetChecklistRequest();
            getChecklistRequest.GroupID = groupid;
            SetPageRangeToRequest(getChecklistRequest, offset, limit);

            var checklistResponse = this.ExcuteV1_2<GetChecklistResponse, GetChecklistRequest>(
               (o) =>
               {
                   return checklistBusinessEntity.GetChecklists(o);
               },
               getChecklistRequest);
            return WSGetChecklistResponse.FromEntityModel(checklistResponse);

        }
    }
}
