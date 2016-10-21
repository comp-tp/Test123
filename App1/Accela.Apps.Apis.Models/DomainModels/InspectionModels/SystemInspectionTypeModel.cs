using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.Models.DomainModels.InspectionModels
{
    [DataContract]
    public class SystemInspectionTypeModel : DataModel
    {
        /// <summary>
        /// Gets or sets the inspection group Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the inspection group display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }


        [DataMember(Name = "status", EmitDefaultValue = false)]
        public List<InspectionStatusModel> Status { get; set; }


        [DataMember(Name = "checklistGroup", EmitDefaultValue = false)]
        public ChecklistGroupModel ChecklistGroup { get; set; }
    }
}
