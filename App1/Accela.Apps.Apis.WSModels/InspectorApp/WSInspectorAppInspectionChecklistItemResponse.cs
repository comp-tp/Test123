using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.WSModels.InspectorApp;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    /// <summary>
    /// inspection checklist item response
    /// </summary>
    [DataContract(Name = "getInspectionChecklistItemResponse")]
    public class WSInspectorAppInspectionChecklistItemResponse : WSPagedResponse
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

        public static WSInspectorAppInspectionChecklistItemResponse FromEntityModel(InspectionChecklistItemResponse inspectionChecklistItemResponse)
        {
            var WSInspectorAppInspectionChecklistItemResponse = new WSInspectorAppInspectionChecklistItemResponse();
            if (inspectionChecklistItemResponse != null)
            {
                if (inspectionChecklistItemResponse.PageInfo != null)
                {
                    WSInspectorAppInspectionChecklistItemResponse.PageInfo = new WSPagination();
                    WSInspectorAppInspectionChecklistItemResponse.PageInfo.TotalRows = inspectionChecklistItemResponse.PageInfo.TotalRows;
                    WSInspectorAppInspectionChecklistItemResponse.PageInfo.HasMore = inspectionChecklistItemResponse.PageInfo.TotalRows > inspectionChecklistItemResponse.PageInfo.Offset + inspectionChecklistItemResponse.PageInfo.Limit;                    
                }

                WSInspectorAppInspectionChecklistItemResponse.InspectionChecklistItems = WSInspectorAppChecklistItem.FromEntityModels(inspectionChecklistItemResponse.InspectionChecklistItems);
            }
            return WSInspectorAppInspectionChecklistItemResponse;
        }
    }
}
