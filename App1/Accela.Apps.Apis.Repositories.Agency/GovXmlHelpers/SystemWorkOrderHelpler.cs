using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.CostModels;
using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class SystemWorkOrderHelpler : GovXmlHelperBase
    {
        public const string WORK_ORDER_TYPPS_MODULE_NAME = "AMS";

        /*
        /// <summary>
        /// get the all Templates (WorkOrder or Record ?)
        /// </summary>
        /// <returns></returns>
        public static IList<WorkOrderTemplateModel> GetAllWorkOrderTemplates()
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getWorkOrderTemplates = new GetWorkOrderTemplates();
            govXmlIn.getWorkOrderTemplates.contextType = "";
            govXmlIn.getWorkOrderTemplates.system = CommonHelper.GetSystem();

            GovXML govXmlOut = CommonHelper.Post(govXmlIn, govXmlIn.getWorkOrderTemplates.system,
                                                 xmlOut =>
                                                 xmlOut.getWorkOrderTemplatesResponse == null
                                                     ? null
                                                     : xmlOut.getWorkOrderTemplatesResponse.system);


            var response = govXmlOut.getWorkOrderTemplatesResponse;
            IList<WorkOrderTemplateModel> templates = new List<WorkOrderTemplateModel>();

            if (response != null && response.workOrderTemplates != null &&
                response.workOrderTemplates.WorkOrderTemplate != null)
            {
                foreach (var template in response.workOrderTemplates.WorkOrderTemplate)
                {
                    templates.Add(ToClientPart(template));
                }
            }

            return templates;

        }
        //*/

        /// <summary>
        /// Convert the govXML entity to Domain Model.(template)
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static WorkOrderTemplateModel ToClientPart(WorkOrderTemplate template)
        {
            WorkOrderTemplateModel templateModel = null;
            if (template != null)
            {
                templateModel = new WorkOrderTemplateModel()
                                    {
                                        Name = template.Name,
                                        Comments = template.Comments,
                                        Description = template.Description,
                                        Primary = template.Primary,
                                        Priority = template.Priority
                                    };

                if (template.WorkOrderType != null)
                {
                    templateModel.Type = new RecordTypeModel()
                                             {
                                                 Identifier = template.WorkOrderType.keys.ToStringKeys(),
                                                 Display = template.WorkOrderType.identifierDisplay
                                             };
                }

                if (template.Department != null)
                {
                    templateModel.Department = new DepartmentModel()
                                                   {
                                                       Identifier = template.Department.keys.ToStringKeys(),
                                                       Display = template.Department.identifierDisplay,
                                                       AgencyCode = template.Department.agencyCode,
                                                       BureauCode = template.Department.bureauCode,
                                                       DivisionCode = template.Department.divisionCode,
                                                       SectionCode = template.Department.sectionCode,
                                                       GroupCode = template.Department.groupCode,
                                                       SubGroupCode = template.Department.subgroupCode,
                                                       SubGroupCodeDesc = template.Department.subgroupDesc
                                                       // staffs
                                                   };
                }

                if (template.Costs != null && template.Costs.CostItem != null)
                {
                    templateModel.Costs = new List<CostModel>();
                    CostModel costModel;
                    foreach (var cost in template.Costs.CostItem)
                    {
                        costModel = CostHelper.ToClientCost(cost);
                        if (costModel != null)
                        {
                            templateModel.Costs.Add(costModel);
                        }
                    }
                }

                if (template.Parts != null && template.Parts.Part != null)
                {
                    templateModel.Parts = new List<PartModel>();
                    PartModel partModel;
                    foreach (var part in template.Parts.Part)
                    {
                        partModel = PartHelper.ToClientPart(part);
                        if (partModel != null)
                        {
                            templateModel.Parts.Add(partModel);
                        }
                    }

                }

                if (template.WorkOrderTasks != null && template.WorkOrderTasks.WOTTask != null)
                {
                    templateModel.WorkOrderTasks = new List<WorkOrderTaskModel>();
                    foreach (var task in template.WorkOrderTasks.WOTTask)
                    {
                        templateModel.WorkOrderTasks.Add(new  WorkOrderTaskModel()
                                                             {
                                                                 Comments = task.Comments,
                                                                 Description = task.Description,
                                                                 Estimate = task.Estimate,
                                                                 Order = task.Order,
                                                                 ProcessCode = task.ProcessCode,
                                                                 ProcessID = task.ProcessID,
                                                                 StandardOperatingProcedures =
                                                                     task.StandardOperatingProcedures,
                                                                 StepNumber = task.StepNumber,
                                                                 TaskCode = task.TaskCode,
                                                                 TaskDescription = task.TaskDescription,
                                                                 Unit = task.Unit,
                                                                 UpdatedBy = task.UpdatedBy,
                                                                 UpdatedDate = task.UpdatedDate,
                                                                 WorkflowTaskStatus = task.WorkflowTaskStatus
                                                             });

                         
                    }

                }
            }

            return templateModel;
        }

        public static IList<WorkOrderTemplateModel> ToClientWorkOrderTemplates(GetWorkOrderTemplatesResponse getWorkOrderTemplatesResponse)
        {
            IList<WorkOrderTemplateModel> templates = new List<WorkOrderTemplateModel>();

            if (getWorkOrderTemplatesResponse != null 
                && getWorkOrderTemplatesResponse.workOrderTemplates != null 
                && getWorkOrderTemplatesResponse.workOrderTemplates.WorkOrderTemplate != null)
            {
                foreach (var template in getWorkOrderTemplatesResponse.workOrderTemplates.WorkOrderTemplate)
                {
                    templates.Add(ToClientPart(template));
                }
            }

            return templates;
        }
    }
}
