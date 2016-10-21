using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Attachments
{
    [DataContract(Name="documentGroup")]
    public class WSDocumentGroup : WSDataModel
    {
        /// <summary>
        /// Gets or sets the wsdocument Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the wsdocument display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the wsdocument type 
        /// </summary>
        [DataMember(Name="types", EmitDefaultValue = false)]
        public List<WSDocumentType> Type { get; set; }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="basicModel">The basic model.</param>
        /// <returns>the entity model.</returns>
        public static DocumentGroupModel ToEntityModel(WSDocumentGroup baseModel)
        {
            if (baseModel == null)
            {
                return null;
            }

            var result = new DocumentGroupModel()
            {
                Identifier = baseModel.Id,
                Dispaly = baseModel.Display,
                DocumentType = WSDocumentType.ToEntityModels(baseModel.Type)
            };

            return result;
        }
    }
}
