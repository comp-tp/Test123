using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract(Name = "documentTypeModel")]
    public class DocumentTypeModel : DataModel
    {
        /// <summary>
        /// Gets or sets the DocumentType Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the DocumentType Diaplay.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the Document whether download
        /// </summary>
        [DataMember(Name = "download", EmitDefaultValue = false)]
        public bool Download { get; set; }

        /// <summary>
        /// Gets or sets the Document description
        /// </summary>
        [DataMember(Name="description",EmitDefaultValue = false)]
        public string Description { get; set; }
    }
}
