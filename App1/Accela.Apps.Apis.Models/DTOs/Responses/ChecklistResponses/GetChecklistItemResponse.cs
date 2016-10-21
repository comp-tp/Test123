using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses
{
    public class GetChecklistItemResponse : PagedResponse
    {
        public List<ChecklistItemModel> ChecklistItemModels { get; set; }
    }
}
