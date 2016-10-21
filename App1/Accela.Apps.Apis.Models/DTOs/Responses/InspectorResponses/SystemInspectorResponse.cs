using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectorResponses
{
    [DataContract]
    public  class SystemInspectorResponse: PagedResponse
    {
        [DataMember(Name = "inspectors", EmitDefaultValue = false)]
        public List<SystemInspectorModel> Inspectors { get; set; }
    }
}
