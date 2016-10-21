using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class WorkflowHelper : GovXmlHelperBase
    {
        /*
        public static GovXML ToXMLGetWorkflowModel(WorkflowTasksRequest request)
        {
            GovXML govXmlIn = new GovXML();

            govXmlIn.getWorkflow = new GetWorkflow();

            govXmlIn.getWorkflow.system = CommonHelper.GetSystem();

            if (request != null)
            {
                govXmlIn.getWorkflow.capIds = new CAPIds();
                govXmlIn.getWorkflow.capIds.capId = new CAPId[1];
                govXmlIn.getWorkflow.capIds.capId[0] = new CAPId();
                govXmlIn.getWorkflow.capIds.capId[0].keys = KeysHelper.CreateXMLKeys(request.RecordId);

                govXmlIn.getWorkflow.contextType = "Multiple";
            }

            return govXmlIn;
        }
        //*/

        /*
        public static GovXML ToXMLUpdateWorkflowModel(UpdateWorkflowTaskRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.updateWorkflowTask = new UpdateWorkflowTask();
            govXmlIn.updateWorkflowTask.system = CommonHelper.GetSystem();

            if (request != null)
            {
                govXmlIn.updateWorkflowTask.capId = new CAPId();
                govXmlIn.updateWorkflowTask.capId.keys = KeysHelper.CreateXMLKeys(request.RecordId);
                if (request.Task != null && !string.IsNullOrWhiteSpace(request.Task.StepNumber))
                {
                    WorkflowTaskModel clientObj = request.Task;
                    TaskItem result = new TaskItem();
                    result.taskDescription = clientObj.Description;
                    result.disposition = clientObj.Status;
                    result.statusDate = clientObj.StatusDate;
                    result.actionBy = clientObj.ActionBy;
                    result.recordDateTime = clientObj.RecordDateAndTime;
                    result.startTime = clientObj.StartTime;
                    result.endTime = clientObj.EndTime;
                    result.hoursSpent = clientObj.HoursSpent;
                    result.billable = BoolHelper.ToBoolString(clientObj.Billable,BoolHelper.BoolStringType.YOrN);
                    result.overTime = clientObj.Overtime;
                    result.recordBy = clientObj.RecordBy;
                    result.trackStartDate = clientObj.TimeTrackingStartDate;
                    result.estimatedDueDate = clientObj.EstimateCompletionDate;
                    result.inPossessionTime = string.IsNullOrWhiteSpace(clientObj.InPossessionHours) ? 0 : double.Parse(clientObj.InPossessionHours);
                    result.dispositionComment = clientObj.Comments;
                    result.processID = string.IsNullOrWhiteSpace(clientObj.ProcessID) ? 0 : long.Parse(clientObj.ProcessID);
                    result.stepNumber = string.IsNullOrWhiteSpace(clientObj.StepNumber) ? 0 : int.Parse(clientObj.StepNumber);
                    result.assignedUserName = clientObj.AssignTo;
                    result.dueDate = clientObj.DueDate;
                    result.assignmentDate = clientObj.AssignmentDate;
                    result.assignDepartmentName = clientObj.AssignDepartment;
                    result.actionDepartmentName = clientObj.ActionByDepartment;
                    result.activeFlag = BoolHelper.ToBoolString(clientObj.ActiveFlag, BoolHelper.BoolStringType.YOrN);
                    result.completeFlag = BoolHelper.ToBoolString(clientObj.CompleteFlag, BoolHelper.BoolStringType.YOrN);
                    result.department = RecordHelper.ToXMLDepartment(clientObj.Department);

                    result.processCode = clientObj.ProcessCode;

                    govXmlIn.updateWorkflowTask.taskItem = result;
                }
            }

            return govXmlIn;
        }
        //*/

        public static WorkflowTasksResponse ToClientWorkflowTasks(GetWorkflowResponse xmlObj)
        {
            WorkflowTasksResponse results = new WorkflowTasksResponse();

            if (xmlObj != null)
            {
                if (xmlObj.system != null)
                {
                    results.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
                }

                if (xmlObj.Workflows != null
                    && xmlObj.Workflows.workflows != null
                    && xmlObj.Workflows.workflows.Length > 0)
                {
                    results.Tasks = new List<WorkflowTaskModel>();

                    foreach (var workflow in xmlObj.Workflows.workflows)
                    {
                        if (workflow.processes != null
                            && workflow.processes.processes != null
                            && workflow.processes.processes.Length > 0)
                        {
                            foreach (var process in workflow.processes.processes)
                            {
                                if (process.taskItems != null
                                    && process.taskItems.taskItems != null
                                    && process.taskItems.taskItems.Length > 0)
                                {
                                    foreach (var task in process.taskItems.taskItems)
                                    {
                                        WorkflowTaskModel clientTask = ToClientWorkflow(task);
                                        clientTask.IsAdHocTask = BoolHelper.GetBooleanByString(process.isAdHocTask);
                                        clientTask.ParentProcessID = process.parentProcessID.ToString();
                                        //find histories
                                        if (workflow.workflowHistory != null)
                                        {
                                            clientTask.Histories = ToClientWorkflowHistories(task, workflow.workflowHistory.taskItems);
                                        }

                                        results.Tasks.Add(clientTask);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return results;
        }

        private static WorkflowTaskModel ToClientWorkflow(TaskItem task)
        {
            WorkflowTaskModel result = null;

            if (task != null)
            {
                result = new WorkflowTaskModel();
                result.Description = task.taskDescription;
                result.Status = task.disposition;
                result.StatusDate = task.statusDate;
                result.ActionBy = task.actionBy;
                result.RecordDateAndTime = task.recordDateTime;
                result.StartTime = task.startTime;
                result.EndTime = task.endTime;
                result.HoursSpent = task.hoursSpent;
                result.Billable = BoolHelper.GetBooleanByString(task.billable);
                result.Overtime = task.overTime;
                result.RecordBy = task.recordBy;
                result.TimeTrackingStartDate = task.trackStartDate;
                result.EstimateCompletionDate = task.estimatedDueDate;
                result.InPossessionHours = task.inPossessionTime.ToString();
                result.Comments = task.dispositionComment;
                result.ProcessID = task.processID.ToString();
                result.StepNumber = task.stepNumber.ToString();
                result.AssignTo = task.assignedUserName;
                result.DueDate = task.dueDate;
                result.AssignmentDate = task.assignmentDate;
                result.AssignDepartment = task.assignDepartmentName;
                result.ActionByDepartment = task.actionDepartmentName;
                result.ActiveFlag = BoolHelper.GetBooleanByString(task.activeFlag);
                result.CompleteFlag = BoolHelper.GetBooleanByString(task.completeFlag);
                result.statuses = ToClientWorkflowTaskStatuses(task.workflowStatuses);
                result.Department = RecordHelper.ToClientDepartment(task.department);

                result.ProcessCode = task.processCode;
            }

            return result;
        }

        private static List<WorkflowTaskStatusModel> ToClientWorkflowTaskStatuses(WorkflowTaskStatuses xmlObjs)
        {
            List<WorkflowTaskStatusModel> clientObjs = null;
            if (xmlObjs != null && xmlObjs.workflowTaskStatus != null)
            {
                clientObjs = new List<WorkflowTaskStatusModel>();
                foreach (var xmlObj in xmlObjs.workflowTaskStatus)
                {
                    clientObjs.Add(ToClientWorkflowTaskStatus(xmlObj));
                }
            }

            return clientObjs;
        }

        public static WorkflowTaskStatusModel ToClientWorkflowTaskStatus(WorkflowTaskStatus xmlObj)
        {
            WorkflowTaskStatusModel clientObj = null;
            if (xmlObj != null)
            {
                clientObj = new WorkflowTaskStatusModel();
                clientObj.ProcessCode = xmlObj.processCode;
                clientObj.TaskStatusCode = xmlObj.taskStatusCode;
                clientObj.TaskDescription = xmlObj.taskDescription;
                clientObj.StatusDescription = xmlObj.statusDescription;
                clientObj.ResultingAction = xmlObj.resultingAction;
                clientObj.RecordDate = xmlObj.recordDate;
                clientObj.RecorderID = xmlObj.recorderID;
                clientObj.ApplicationStatus = xmlObj.applicationStatus;
                clientObj.ParentStatus = xmlObj.parentStatus;
                clientObj.TimeTrackerClockAction = xmlObj.timeTrackerClockAction;
                clientObj.ACADisplayable = xmlObj.aCADisplayable;
                clientObj.Status = xmlObj.status;
            }

            return clientObj;
        }

        public static Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses.UpdateWorkflowTaskResponse ToClientUpdateWorkflowTask(Accela.Automation.GovXmlClient.Model.UpdateWorkflowTaskResponse updateWorkflowTaskResponse)
        {
            Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses.UpdateWorkflowTaskResponse result = new Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses.UpdateWorkflowTaskResponse();

            if (updateWorkflowTaskResponse != null)
            {
                if (updateWorkflowTaskResponse.system != null)
                {
                    result.Events = CommonHelper.GetClientEventMessage(updateWorkflowTaskResponse.system.eventMessages);
                }
                if (updateWorkflowTaskResponse.capId != null && updateWorkflowTaskResponse.capId.keys != null)
                {
                    result.RecordId = KeysHelper.ToStringKeys(updateWorkflowTaskResponse.capId.keys);
                }
                result.Result = updateWorkflowTaskResponse.result;
            }

            return result;
        }

        public static List<WorkflowTaskModel> ToClientWorkflowHistories(TaskItem task, TaskItem[] allHistories)
        {
            List<WorkflowTaskModel> retus = null;
            if (allHistories != null)
            {
                retus = new List<WorkflowTaskModel>();
                foreach (var item in allHistories)
                {
                    bool? deleteFlag=BoolHelper.GetBooleanByString(task.deleteFlag);
                    if (deleteFlag == null)
                        deleteFlag = false;
                    if (item.processID == task.processID && item.taskDescription == task.taskDescription && deleteFlag.Value == false)
                    {
                        retus.Add(ToClientWorkflow(item));
                    }
                }
            }

            return retus;
        }

        public static UpdateWorkflowTask ToXMLUpdateWorkflowTask(UpdateWorkflowTaskRequest request)
        {
            UpdateWorkflowTask updateWorkflowTask = new UpdateWorkflowTask();

            if (request != null)
            {
                updateWorkflowTask.capId = new CAPId();
                updateWorkflowTask.capId.keys = KeysHelper.CreateXMLKeys(request.RecordId);
                if (request.Task != null && !string.IsNullOrWhiteSpace(request.Task.StepNumber))
                {
                    WorkflowTaskModel clientObj = request.Task;
                    TaskItem result = new TaskItem();
                    result.taskDescription = clientObj.Description;
                    result.disposition = clientObj.Status;
                    result.statusDate = clientObj.StatusDate;
                    result.actionBy = clientObj.ActionBy;
                    result.recordDateTime = clientObj.RecordDateAndTime;
                    result.startTime = clientObj.StartTime;
                    result.endTime = clientObj.EndTime;
                    result.hoursSpent = clientObj.HoursSpent;
                    result.billable = BoolHelper.ToBoolString(clientObj.Billable, BoolHelper.BoolStringType.YOrN);
                    result.overTime = BoolHelper.ToBoolString(clientObj.Overtime == "1", BoolHelper.BoolStringType.YOrN); ;//clientObj.Overtime == "1" ? "y" : "n";
                    result.recordBy = clientObj.RecordBy;
                    result.trackStartDate = clientObj.TimeTrackingStartDate;
                    result.estimatedDueDate = clientObj.EstimateCompletionDate;
                    result.inPossessionTime = string.IsNullOrWhiteSpace(clientObj.InPossessionHours) ? 0 : double.Parse(clientObj.InPossessionHours);
                    result.dispositionComment = clientObj.Comments;
                    result.processID = string.IsNullOrWhiteSpace(clientObj.ProcessID) ? 0 : long.Parse(clientObj.ProcessID);
                    result.stepNumber = string.IsNullOrWhiteSpace(clientObj.StepNumber) ? 0 : int.Parse(clientObj.StepNumber);
                    result.assignedUserName = clientObj.AssignTo;
                    result.dueDate = clientObj.DueDate;
                    result.assignmentDate = clientObj.AssignmentDate;
                    result.assignDepartmentName = clientObj.AssignDepartment;
                    result.actionDepartmentName = clientObj.ActionByDepartment;
                    result.activeFlag = BoolHelper.ToBoolString(clientObj.ActiveFlag, BoolHelper.BoolStringType.YOrN);
                    result.completeFlag = BoolHelper.ToBoolString(clientObj.CompleteFlag, BoolHelper.BoolStringType.YOrN);
                    result.department = RecordHelper.ToXMLDepartment(clientObj.Department);

                    result.processCode = clientObj.ProcessCode;

                    updateWorkflowTask.taskItem = result;
                }
            }

            return updateWorkflowTask;
        }
    }
}
