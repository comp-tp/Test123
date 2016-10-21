using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract]
    public class WSUpdateWorkflowTask : WSWorkflowTaskBase
    {

        /// <summary>
        /// Convert to the entity model.
        /// </summary>
        /// <param name="wsUpdateRecord">The ws record.</param>
        /// <returns>the entity model.</returns>
        public static WorkflowTaskModel ToEntityModel(WSUpdateWorkflowTask clientObj)
        {
            WorkflowTaskModel workflowTask = null;
            if (clientObj != null)
            {
                workflowTask = new WorkflowTaskModel();
                clientObj.ToEntityModelInner(workflowTask);
            }

            return workflowTask;
        }
    }
}
