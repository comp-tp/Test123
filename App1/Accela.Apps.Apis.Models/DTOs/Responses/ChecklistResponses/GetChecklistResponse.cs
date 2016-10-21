using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses
{
    public class GetChecklistResponse : PagedResponse
    {
        public List<ChecklistModel> checklistModels { get; set; }
    }
}
