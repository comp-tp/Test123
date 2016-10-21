using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name="checklistGroup")]
    public class WSChecklistGroup
    {
        [DataMember(Name="id", Order=1)]
        public string Id { get; set; }

        [DataMember(Name = "display", Order = 2)]
        public string Display { get; set; }

        public static WSChecklistGroup FromEntityModel(ChecklistGroupModel checklistGroupModel)
        {
            WSChecklistGroup wsChecklistGroup = null;
            if (checklistGroupModel != null)
            { 
                wsChecklistGroup = new WSChecklistGroup();
                wsChecklistGroup.Id = checklistGroupModel.Identifier;
                wsChecklistGroup.Display = checklistGroupModel.Display;
            }
            return wsChecklistGroup;
        }

        public static List<WSChecklistGroup> FromEntityModels(IList<ChecklistGroupModel> checklistGroupModels)
        {
            List<WSChecklistGroup> wsChecklistGroups = null;
            if (checklistGroupModels != null && checklistGroupModels.Count > 0)
            {
                wsChecklistGroups = new List<WSChecklistGroup>();
                foreach (var checkListGroupModel in checklistGroupModels)
                {
                    wsChecklistGroups.Add(FromEntityModel(checkListGroupModel));
                }
            }
            return wsChecklistGroups;
        }
    }
}
