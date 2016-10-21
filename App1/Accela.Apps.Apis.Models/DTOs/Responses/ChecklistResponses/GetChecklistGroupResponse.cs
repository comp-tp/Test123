using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses
{
    public class GetChecklistGroupResponse : PagedResponse
    {
        public List<ChecklistGroupModel> ChecklistGroups { get; set; }
    }
}
