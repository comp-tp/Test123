using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    [DataContract]
    public class InspectionGroupResponse : PagedResponse
    {
         [DataMember(Name = "inspectiongroups", EmitDefaultValue = false)] 
         public List<InspectionGroupModel> InspectionGroups{ get; set; }
    }
}
