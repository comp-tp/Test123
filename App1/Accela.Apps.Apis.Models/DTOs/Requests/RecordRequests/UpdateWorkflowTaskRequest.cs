using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "UpdateWorkflowTaskRequest")]
    public class UpdateWorkflowTaskRequest : RequestBase
    {
        [DataMember(Name = "WorkflowTask", EmitDefaultValue = false)]
        public WorkflowTaskModel Task { get; set; }

        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }
    }
}
