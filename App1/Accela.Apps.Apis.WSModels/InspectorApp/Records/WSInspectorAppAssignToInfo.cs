using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract]
    public class WSInspectorAppAssignToInfo
    {
        [DataMember(Name = "totalJobCost", EmitDefaultValue = false)]
        public string TotalJobCost { get; set; }

        [DataMember(Name = "completeDate", EmitDefaultValue = false)]
        public string CompleteDate { get; set; }

        [DataMember(Name = "AssignDate", EmitDefaultValue = false)]
        public string AssignDate { get; set; }

        [DataMember(Name = "scheduledDate", EmitDefaultValue = false)]
        public string ScheduledDate { get; set; }

        [DataMember(Name = "assignStaff", EmitDefaultValue = false)]
        public string AssignStaff { get; set; }

        [DataMember(Name = "assignDepartment", EmitDefaultValue = false)]
        public string AssignDepartment { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        public static WSInspectorAppAssignToInfo FromEntityModel(AssignToInfo assignToInfo)
        {
            WSInspectorAppAssignToInfo wsAssignToInfo = null;
            if (assignToInfo != null)
            {
                wsAssignToInfo = new WSInspectorAppAssignToInfo()
                {
                    AssignDate = assignToInfo.AssignDate,
                    AssignDepartment = assignToInfo.AssignDepartment,
                    AssignStaff = assignToInfo.AssignStaff,
                    CompleteDate = assignToInfo.CompleteDate,
                    ScheduledDate = assignToInfo.ScheduledDate,
                    TotalJobCost = assignToInfo.TotalJobCost,
                    Priority = assignToInfo.Priority
                };

            }

            return wsAssignToInfo;
        }
    }
}
