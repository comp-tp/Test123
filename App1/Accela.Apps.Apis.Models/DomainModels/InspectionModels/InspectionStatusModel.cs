using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.InspectionModels
{
    /// <summary>
    /// Inspection Status class
    /// </summary>
    [DataContract]
    public class InspectionStatusModel : IdentifierBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the inspection statustype.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        #endregion Properties
    }
}