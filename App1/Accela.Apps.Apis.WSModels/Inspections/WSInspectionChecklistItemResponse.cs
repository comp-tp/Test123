using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.WSModels.InspectorApp;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    /// <summary>
    /// inspection checklist item response
    /// </summary>
    [DataContract(Name = "getInspectionChecklistItemResponse")]
    public class WSInspectionChecklistItemResponse : WSPagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection checklist items.
        /// </summary>
        /// <value>
        /// The inspection checklist items.
        /// </value>
        [DataMember(Name = "inspectionChecklistItems")]
        public List<WSInspectorAppChecklistItem> InspectionChecklistItems
        {
            get;
            set;
        }

        public static WSInspectionChecklistItemResponse FromEntityModel(InspectionChecklistItemResponse inspectionChecklistItemResponse)
        {
            var wsInspectionChecklistItemResponse = new WSInspectionChecklistItemResponse();
            if (inspectionChecklistItemResponse != null)
            {
                if (inspectionChecklistItemResponse.PageInfo != null)
                {
                    wsInspectionChecklistItemResponse.PageInfo = new WSPagination();
                    wsInspectionChecklistItemResponse.PageInfo.TotalRows = inspectionChecklistItemResponse.PageInfo.TotalRows;
                    wsInspectionChecklistItemResponse.PageInfo.HasMore = inspectionChecklistItemResponse.PageInfo.TotalRows > inspectionChecklistItemResponse.PageInfo.Offset + inspectionChecklistItemResponse.PageInfo.Limit;                    
                }

                wsInspectionChecklistItemResponse.InspectionChecklistItems = WSInspectorAppChecklistItem.FromEntityModels(inspectionChecklistItemResponse.InspectionChecklistItems);
            }
            return wsInspectionChecklistItemResponse;
        }
    }
}
