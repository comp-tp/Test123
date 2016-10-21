using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.WSModels.Checklists;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    /// <summary>
    /// inspection checklist response
    /// </summary>
    [DataContract(Name = "getInspectionChecklistResponse")]
    public class WSInspectionChecklistResponse : WSPagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection checklists.
        /// </summary>
        /// <value>
        /// The inspection checklists.
        /// </value>
        [DataMember(Name = "inspectionChecklists")]
        public List<WSChecklist> InspectionChecklists
        {
            get;
            set;
        }

        public static WSInspectionChecklistResponse FromEntityModel(InspectionChecklistResponse inspectionChecklistResponse)
        {
            var wsInspectionChecklistResponse = new WSInspectionChecklistResponse();
            if (inspectionChecklistResponse != null)
            {
                if (inspectionChecklistResponse.PageInfo != null)
                {
                    wsInspectionChecklistResponse.PageInfo = new WSPagination();
                    wsInspectionChecklistResponse.PageInfo.TotalRows = inspectionChecklistResponse.PageInfo.TotalRows;
                    wsInspectionChecklistResponse.PageInfo.HasMore = inspectionChecklistResponse.PageInfo.TotalRows > inspectionChecklistResponse.PageInfo.Offset + inspectionChecklistResponse.PageInfo.Limit;
                }
                wsInspectionChecklistResponse.InspectionChecklists = WSChecklist.FromEntityModels(inspectionChecklistResponse.InspectionChecklists);
            }
            return wsInspectionChecklistResponse;
        }
    }
}
