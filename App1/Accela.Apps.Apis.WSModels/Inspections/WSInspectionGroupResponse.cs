using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    public class WSInspectionGroupResponse : WSPagedResponse
    {
        [DataMember(Name = "groups")]
        public List<WSInspectionGroup> InpectonGroups { get; set; }

        public static WSInspectionGroupResponse FromEntityModel(InspectionGroupResponse entityResponse)
        {
            WSInspectionGroupResponse response = new WSInspectionGroupResponse
            {
                PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo)
            };

            response.InpectonGroups = new List<WSInspectionGroup>();

            if (entityResponse.InspectionGroups != null)
            {
                entityResponse.InspectionGroups.ForEach(model => response.InpectonGroups.Add(WSInspectionGroup.FromEntityModel(model)));
            }

            return response;
        }
    }
}
