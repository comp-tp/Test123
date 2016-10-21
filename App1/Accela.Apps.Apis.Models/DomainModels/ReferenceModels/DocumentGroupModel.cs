using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract(Name = "documentGroupModel")]
    public class DocumentGroupModel : DataModel
    {
        /// <summary>
        /// Gets or sets the DocumentGroupType Id.
        /// </summary>
       [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the DoucmentGroupType Diaplay.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Dispaly { get; set; }

        /// <summary>
        /// Add DocumentType into record type
        /// </summary>
        [DataMember(Name = "doucmentTypeModelLst", EmitDefaultValue = false)]
        public List<DocumentTypeModel> DocumentType { get; set; } 
    }
}
