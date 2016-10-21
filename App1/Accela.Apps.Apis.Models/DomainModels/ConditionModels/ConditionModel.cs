using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.ConditionModels
{
    [DataContract]
    public class ConditionModel : ActionDataModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the ConditionName.
        /// </summary>
        [DataMember(Name = "conditionName", EmitDefaultValue = false)]
        public string ConditionName { get; set; }

        /// <summary>
        /// Gets or sets the condition's description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the condition's description
        /// </summary>
        [DataMember(Name = "longDescription", EmitDefaultValue = false)]
        public string LongDescription { get; set; }

        /// <summary>
        /// Gets or sets the condition type
        /// </summary>
        [DataMember(Name = "conditionType", EmitDefaultValue = false)]
        public ConditionTypeModel ConditionType { get; set; }

        /// <summary>
        /// Gets or sets the condition's apply date
        /// </summary>
        [DataMember(Name = "applyDate", EmitDefaultValue = false)]
        public string ApplyDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date
        /// </summary>
        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the effective date
        /// </summary>
        [DataMember(Name = "effectiveDate", EmitDefaultValue = false)]
        public string EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the condition status type
        /// </summary>
        [DataMember(Name = "conditionStatus", EmitDefaultValue = false)]
        public ConditionStatusModel ConditionStatus { get; set; }

        /// <summary>
        /// Condition's Severity
        /// </summary>
        [DataMember(Name = "severityLevel", EmitDefaultValue = false)]
        public SeverityModel SeverityLevel { get; set; }

        /// <summary>
        /// Gets or sets the display condition notice
        /// </summary>
        [DataMember(Name = "displayConditionNotice", EmitDefaultValue = false)]
        public string DisplayConditionNotice { get; set; }

        /// <summary>
        /// Gets or sets whether or not include in condition name
        /// </summary>
        [DataMember(Name = "includeInConditionName", EmitDefaultValue = false)]
        public string IncludeInConditionName { get; set; }

        /// <summary>
        /// Gets or sets whether or not include in short description
        /// </summary>
        [DataMember(Name = "includeInShortDescription", EmitDefaultValue = false)]
        public string IncludeInShortDescription { get; set; }

        /// <summary>
        /// Gets or sets whether or not inheriable
        /// </summary>
        [DataMember(Name = "inheritable", EmitDefaultValue = false)]
        public string Inheritable { get; set; }

        /// <summary>
        /// Gets or sets public display message
        /// </summary>
        [DataMember(Name = "publicDisplayMessage", EmitDefaultValue = false)]
        public string PublicDisplayMessage { get; set; }

        /// <summary>
        /// Gets or sets resolution action
        /// </summary>
        [DataMember(Name = "resolutionAction", EmitDefaultValue = false)]
        public string ResolutionAction { get; set; }

        /// <summary>
        /// Gets or sets condition's short comment
        /// </summary>
        [DataMember(Name = "shortComment", EmitDefaultValue = false)]
        public string ShortComment { get; set; }

        /// <summary>
        /// Gets or sets condition's long comment
        /// </summary>
        [DataMember(Name = "longComment", EmitDefaultValue = false)]
        public string LongComment { get; set; }

        /// <summary>
        /// Gets or sets whether or not it is open condition
        /// </summary>
        [DataMember(Name = "openCondition", EmitDefaultValue = false)]
        public string OpenCondition { get; set; }

        /// <summary>
        /// Gets or sets condition's group
        /// </summary>
        [DataMember(Name = "conditionGroup", EmitDefaultValue = false)]
        public ConditionGroupModel ConditionGroup { get; set; }

        /// <summary>
        /// Gets or sets the condition is read only
        /// </summary>
        [DataMember(Name = "readOnly", EmitDefaultValue = false)]
        public string ReadOnly { get; set; }
    }
}
