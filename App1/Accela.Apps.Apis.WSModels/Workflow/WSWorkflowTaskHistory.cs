using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract]
    public class WSWorkflowTaskHistory : WSWorkflowTaskBase
    {

        public static List<WSWorkflowTaskHistory> FromEntityModels(List<WorkflowTaskModel> entityObjs)
        {
            if (entityObjs != null && entityObjs.Count > 0)
            {
                var wsObjs = new List<WSWorkflowTaskHistory>();
                foreach (var entityObj in entityObjs)
                {
                    wsObjs.Add(FromEntityModel(entityObj));
                };
                return wsObjs;
            }
            return null;
        }

        public static WSWorkflowTaskHistory FromEntityModel(WorkflowTaskModel task)
        {
            WSWorkflowTaskHistory result = new WSWorkflowTaskHistory();
            result.FromEntityModelInner(task);
            return result;
        }
    }
}
