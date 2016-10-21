using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.WSModels.Parts;
using Accela.Apps.Apis.WSModels.RecordCosts;
using Accela.Apps.Apis.WSModels.RecordTypes;
using Accela.Apps.Apis.WSModels.RelatedRecords;
using Accela.Apps.Apis.WSModels.V1.WorkOrderTasks;
namespace Accela.Apps.Apis.WSModels.Common
{
    [DataContract(Name = "workOrderTemplate")]
    public class WSSystemWorkOrderTemplate : WSDataModel
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        [DataMember(Name = "primary", EmitDefaultValue = false)]
        public string Primary { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSRecordType Type { get; set; }

        [DataMember(Name = "costs", EmitDefaultValue = false)]
        public List<WSCost> Costs { get; set; }

        [DataMember(Name = "parts", EmitDefaultValue = false)]
        public List<WSPart> Parts { get; set; }

        [DataMember(Name = "workOrderTasks", EmitDefaultValue = false)]
        public List<WSWorkOrderTask> WorkOrderTasks { get; set; }

        [DataMember(Name = "department", EmitDefaultValue = false)]
        public WSDepartment Department { get; set; }

        internal static WSSystemWorkOrderTemplate FromEntityModel(WorkOrderTemplateModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new WSSystemWorkOrderTemplate()
                       {
                           Name = model.Name,
                           Comments = model.Comments,
                           Description = model.Description,
                           Primary = model.Primary,
                           Priority = model.Priority,
                           Type = WSRecordType.FromEntityModel(model.Type),
                           Department = WSDepartment.FromEntityModelForWorkOrderTemplate(model.Department),
                           Costs = model.Costs != null
                                       ? model.Costs.ConvertAll(WSCost.FromEntityModel).Where(x => x != null).ToList()
                                       : null,
                           Parts = model.Parts != null
                                       ? model.Parts.ConvertAll(WSPart.FromEntityModel).Where(x => x != null).ToList()
                                       : null,
                           WorkOrderTasks = model.WorkOrderTasks != null
                                                ? model.WorkOrderTasks.ConvertAll(WSWorkOrderTask.FromEntityModel).Where
                                                      (x => x != null).ToList()
                                                : null
                       };
        }
    }
}