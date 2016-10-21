using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "InspectionChecklistGroup")]
    public class WSSystemInspectionChecklistGroup : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false, Order = 1)]
        public string Display { get; set; }

        /// <summary>
        ///  convert ws entity from biz entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        internal static WSSystemInspectionChecklistGroup FromEntityModel(ChecklistGroupModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new WSSystemInspectionChecklistGroup()
                       {
                           Id = model.Identifier,
                           Display = model.Display,

                       };
        }
    }
}


