using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.V1.WorkOrderTasks
{
    [DataContract(Name = "getWorkOrderTasksResponse")]
    public class WSWorkOrderTasksResponse : WSResponseBase
    {
        /// <summary>
        /// The record inspection information.
        /// </summary>
        [DataMember(Name = "workOrderTasks", EmitDefaultValue = false)]
        public List<WSWorkOrderTask> WorkOrderTasks { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>ws owners response</returns>
        public static WSWorkOrderTasksResponse FromEntityModel(WorkOrderTasksResponse entityResponse)
        {
            var response = new WSWorkOrderTasksResponse
            {
            };

            response.WorkOrderTasks = new List<WSWorkOrderTask>();

            if (entityResponse.Tasks != null)
            {
                entityResponse.Tasks.ForEach(model => response.WorkOrderTasks.Add(WSWorkOrderTask.FromEntityModel(model)));
            }

            return response;
        }
    }
}
