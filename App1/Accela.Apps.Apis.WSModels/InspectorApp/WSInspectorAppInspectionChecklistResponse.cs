using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.WSModels.Checklists;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    /// <summary>
    /// inspection checklist response
    /// </summary>
    [DataContract(Name = "getInspectionChecklistResponse")]
    public class WSInspectorAppInspectionChecklistResponse : WSPagedResponse
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

        public static WSInspectorAppInspectionChecklistResponse FromEntityModel(InspectionChecklistResponse inspectionChecklistResponse)
        {
            var wsInspectorAppInspectionChecklistResponse = new WSInspectorAppInspectionChecklistResponse();
            if (inspectionChecklistResponse != null)
            {
                if (inspectionChecklistResponse.PageInfo != null)
                {
                    wsInspectorAppInspectionChecklistResponse.PageInfo = new WSPagination();
                    wsInspectorAppInspectionChecklistResponse.PageInfo.TotalRows = inspectionChecklistResponse.PageInfo.TotalRows;
                    wsInspectorAppInspectionChecklistResponse.PageInfo.HasMore = inspectionChecklistResponse.PageInfo.TotalRows > inspectionChecklistResponse.PageInfo.Offset + inspectionChecklistResponse.PageInfo.Limit;
                }
                wsInspectorAppInspectionChecklistResponse.InspectionChecklists = WSChecklist.FromEntityModels(inspectionChecklistResponse.InspectionChecklists);
            }
            return wsInspectorAppInspectionChecklistResponse;
        }
    }
}
