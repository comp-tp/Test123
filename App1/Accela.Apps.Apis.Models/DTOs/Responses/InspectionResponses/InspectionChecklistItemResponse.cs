using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    /// <summary>
    /// inspection checklist item response
    /// </summary>
    [DataContract(Name = "getInspectionChecklistItemResponse")]
    public class InspectionChecklistItemResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection checklist items.
        /// </summary>
        /// <value>
        /// The inspection checklist items.
        /// </value>
        [DataMember(Name = "inspectionChecklistItems")]
        public List<ChecklistItemModel> InspectionChecklistItems
        {
            get;
            set;
        }
    }
}
