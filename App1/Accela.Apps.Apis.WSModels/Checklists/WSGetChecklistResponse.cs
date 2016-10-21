using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name = "getChecklistResponse")]
    public class WSGetChecklistResponse : WSPagedResponse
    {
        [DataMember(Name="checklists")]
        public List<WSChecklist> WSChecklists { get; set; }

        public static WSGetChecklistResponse FromEntityModel(GetChecklistResponse getChecklistResponse)
        {
            var wsGetChecklistResponse = new WSGetChecklistResponse
            {
                PageInfo = WSPagination.FromEntityModel(getChecklistResponse.PageInfo)
            };

            if (getChecklistResponse != null && getChecklistResponse.checklistModels != null)
            {
                wsGetChecklistResponse.WSChecklists = WSChecklist.FromEntityModels(getChecklistResponse.checklistModels);
            }

            return wsGetChecklistResponse;
        }
    }
}
