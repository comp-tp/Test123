using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name = "getChecklistGroupResponse")]
    public class WSGetChecklistGroupResponse : WSPagedResponse
    {
        [DataMember(Name = "checklistGroups", EmitDefaultValue = false)]
        public List<WSChecklistGroup> checklistGroups { get; set; }

        public static WSGetChecklistGroupResponse FromEntityModel(GetChecklistGroupResponse getChecklistGroupResponse)
        {
            WSGetChecklistGroupResponse wsGetChecklistGroupResponse = new WSGetChecklistGroupResponse
            {
                PageInfo = WSPagination.FromEntityModel(getChecklistGroupResponse.PageInfo)
            };           

            if (getChecklistGroupResponse != null && getChecklistGroupResponse.ChecklistGroups != null)
            {
                wsGetChecklistGroupResponse.checklistGroups = WSChecklistGroup.FromEntityModels(getChecklistGroupResponse.ChecklistGroups);
            }

            return wsGetChecklistGroupResponse;
        }
    }
}
