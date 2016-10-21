using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract]
    public class WSWorkflowTasksResponse : WSResponseBase
    {
        [DataMember(Name = "workflowTasks", EmitDefaultValue = false)]
        public List<WSWorkflowTask> Tasks { get; set; }

        public static WSWorkflowTasksResponse FromEntityModel(WorkflowTasksResponse entityResponse)
        {
            WSWorkflowTasksResponse result = new WSWorkflowTasksResponse();

            if (entityResponse != null
                && entityResponse.Tasks != null
                && entityResponse.Tasks.Count > 0)
            {
                result.Tasks = new List<WSWorkflowTask>();

                foreach (var task in entityResponse.Tasks)
                {
                    result.Tasks.Add(WSWorkflowTask.FromEntityModel(task));
                }
            }

            return result;
        }
    }
}
