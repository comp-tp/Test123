using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DomainModels.InspectionModels
{
    /// <summary>
    /// InspectionType class
    /// </summary>
    [DataContract]
    public class InspectionTypeModel : IdentifierBase
    {

        /// <summary>
        /// Gets or sets the inspection status group keys.
        /// </summary>
        [DataMember(Name = "statusList", EmitDefaultValue = false)]
        public List<InspectionStatusModel> StatusList { get; set; }

        /// <summary>
        /// Gets or sets the standard comments group ids.
        /// </summary>
        /// <value>
        /// The standard comments group ids.
        /// </value>
        [DataMember(Name = "standardCommentsGroupIds", EmitDefaultValue = false)]
        public string[] StandardCommentsGroupIds { get; set; }
    }
}
