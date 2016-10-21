using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    [DataContract]
    public class RecordTypeModel : DataModel
    {
        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }    

        /// <summary>
        /// Gets or sets the record display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        /// <summary>
        /// group display value
        /// </summary>
        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string Group { get; set; }

        /// <summary>
        /// sub group display value
        /// </summary>
        [DataMember(Name = "subGroup", EmitDefaultValue = false)]
        public string SubGroup { get; set; }

        /// <summary>
        /// category display value
        /// </summary>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public string Category { get; set; }

        /// <summary>
        /// type display value
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security { get; set; }

        /// <summary>
        /// additionalInformationGroup Ids
        /// </summary>
        [DataMember(Name = "additionalInformationGroupIds", EmitDefaultValue = false)]
        public List<AdditionalInformationGroupIdModel> AdditionalInformationGroupIds { get; set;}

        /// <summary>
        /// Add record status into record type
        /// </summary>
        [DataMember(Name = "recordStatuses", EmitDefaultValue = false)]
        public List<RecordStatusModel> RecordStatuses { get; set; }

        /// <summary>
        /// Inspection type group list.
        /// </summary>
        [DataMember(Name = "inspectionGroups", EmitDefaultValue = false)]
        public List<string> InspectionGroups { get; set; }

        /// <summary>
        /// Standard comment group id list.
        /// </summary>
        [DataMember(Name = "standardCommentsGroupIds", EmitDefaultValue = false)]
        public List<string> StandardCommentsGroupIds { get; set; }
    }
}
