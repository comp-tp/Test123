using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Automation.GovXmlClient.Model;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class WorkOrderTaskHelper
    {
        public static List<WorkOrderTaskModel> ToClientWorkOrderTasks(WorkOrderTasks xmlTasks)
        {
            List<WorkOrderTaskModel> result = null;

            if (xmlTasks != null && xmlTasks.WorkOrderTask != null)
            {
                result = new List<WorkOrderTaskModel>();

                foreach (var entry in xmlTasks.WorkOrderTask)
                {
                    result.Add(ToClientWorkOrderTask(entry));
                }
            }

            return result;
        }

        public static WorkOrderTaskModel ToClientWorkOrderTask(WorkOrderTask xmlTask)
        {
            if (xmlTask != null)
            {
                var clientTask = new WorkOrderTaskModel
                {
                    Order = xmlTask.Order,
                    TaskCode = xmlTask.TaskCode,
                    Estimate = xmlTask.Estimate,
                    Actual = xmlTask.Actual,
                    Unit = xmlTask.Unit,
                    CompletedDate = xmlTask.CompletedDate,
                    TotalCost = xmlTask.TotalCost,
                    Description = xmlTask.Description,
                    TaskDescription = xmlTask.TaskDescription,
                    CompletedBy = xmlTask.CompletedBy,
                    UpdatedDate = xmlTask.UpdatedDate,
                    UpdatedBy = xmlTask.UpdatedBy,
                    Comments = xmlTask.Comments,
                    StandardOperatingProcedures = xmlTask.StandardOperatingProcedures,
                    Status = xmlTask.Status,
                    Complete = xmlTask.Complete,
                    ProcessCode = xmlTask.ProcessCode,
                    ProcessID = xmlTask.ProcessID,
                    StepNumber = xmlTask.StepNumber,
                    WorkflowTaskStatus = xmlTask.WorkflowTaskStatus,
                    TaskCodeIndex = xmlTask.TaskCodeIndex
                };

                return clientTask;
            }

            return null;
        }
    }
}
