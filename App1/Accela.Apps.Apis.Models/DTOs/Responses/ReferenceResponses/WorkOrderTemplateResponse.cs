using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract]
    public class WorkOrderTemplateResponse : PagedResponse
    {
        [DataMember(Name = "templates", EmitDefaultValue = false)]
        public List<WorkOrderTemplateModel> Templates { get; set; }
    }
}
