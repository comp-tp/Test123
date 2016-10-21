using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name = "checklist")]
    public class WSChecklist
    {
        [DataMember(Name="id",Order = 1, EmitDefaultValue = false)]
        public string ID { get; set; }

        [DataMember(Name = "display", Order = 2, EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "label", Order = 3, EmitDefaultValue = false)]
        public string Label { get; set; }

        [DataMember(Name = "totalScore", Order = 4, EmitDefaultValue = false)]
        public string TotalScore { get; set; }

        public static WSChecklist FromEntityModel(ChecklistModel checklistModel)
        {
            WSChecklist wsChecklist = null;
            if (checklistModel != null)
            {
                wsChecklist = new WSChecklist() { 
                    ID = checklistModel.Identifier,
                    Display = checklistModel.Subject,
                    Label = checklistModel.Label,
                    TotalScore = checklistModel.TotalScore
                };
            }
            return wsChecklist;
        }

        public static List<WSChecklist> FromEntityModels(List<ChecklistModel> checklistModels)
        {
            List<WSChecklist> wsChecklists = null;
            if (checklistModels != null && checklistModels.Count > 0)
            {
                wsChecklists = new List<WSChecklist>();
                checklistModels.ForEach(chl => wsChecklists.Add(FromEntityModel(chl)));
            }
            return wsChecklists;
        }
    }
}
