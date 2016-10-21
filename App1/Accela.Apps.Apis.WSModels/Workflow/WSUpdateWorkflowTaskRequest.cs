using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract(Name = "UpdateWorkFlowTask")]
    public class WSUpdateWorkflowTaskRequest
    {
        [DataMember(Name = "workFlowTask", EmitDefaultValue = false)]
        public WSUpdateWorkflowTask WorkFlowTask
        {
            get;
            set;
        }
        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }

        public static UpdateWorkflowTaskRequest ToEntityModel(WSUpdateWorkflowTaskRequest request)
        {
            var result = new UpdateWorkflowTaskRequest()
            {
                RecordId = request != null ? request.RecordId : null,
                Task = request != null ? WSUpdateWorkflowTask.ToEntityModel(request.WorkFlowTask) : null
            };

            return result;
        }

    }
}
