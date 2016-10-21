using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    /// <summary>
    /// inspection checklist response
    /// </summary>
    [DataContract(Name = "getInspectionChecklistResponse")]
    public class InspectionChecklistResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection checklists.
        /// </summary>
        /// <value>
        /// The inspection checklists.
        /// </value>
        [DataMember(Name = "inspectionChecklists")]
        public List<ChecklistModel> InspectionChecklists
        {
            get;
            set;
        }
    }
}
