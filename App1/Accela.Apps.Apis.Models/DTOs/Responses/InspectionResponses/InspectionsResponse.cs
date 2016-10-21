using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    [DataContract]
    public class InspectionsResponse : PagedResponse
    {
        [DataMember(Name = "inspections", EmitDefaultValue = false)]
        public List<InspectionModel> Inspections { get; set; }
    }
}
