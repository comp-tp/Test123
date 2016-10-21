using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name = "getChecklistItemResponse")]
    public class WSGetChecklistItemResponse : WSPagedResponse
    {
        [DataMember(Name = "checklistItems", EmitDefaultValue = false)]
        public List<WSChecklistItem> WSChecklistItems { get; set; }        

        public static WSGetChecklistItemResponse FromEntityModel(GetChecklistItemResponse getChecklistItemResponse)
        {
            WSGetChecklistItemResponse wsGetChecklistItemResponse = new WSGetChecklistItemResponse
            {
                PageInfo = WSPagination.FromEntityModel(getChecklistItemResponse.PageInfo)
            };

            if (getChecklistItemResponse != null && getChecklistItemResponse.ChecklistItemModels != null)
            {
                wsGetChecklistItemResponse.WSChecklistItems = WSChecklistItem.FromEntityModels(getChecklistItemResponse.ChecklistItemModels);
            }

            return wsGetChecklistItemResponse;
        }
    }
}
