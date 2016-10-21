using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;


namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    [DataContract]
    public class SystemInspectionTypeResponse: PagedResponse
    {
        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<SystemInspectionTypeModel> Types { get; set; } 
    }
}
