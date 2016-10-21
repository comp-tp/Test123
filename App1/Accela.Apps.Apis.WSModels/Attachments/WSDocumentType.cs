using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Attachments
{
    [DataContract(Name = "documentType")]
    public  class WSDocumentType : WSDataModel
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
        /// Gets or sets the wsdocument download status
        /// </summary>
        [DataMember(Name = "download",EmitDefaultValue = false)]
        public bool Download { get; set; }

        /// <summary>
        /// Gets or sets the wsdocument description
        /// </summary>
        [DataMember(Name = "description",EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Convert BaseModel to DocumentTypeModel
        /// </summary>
        /// <param name="baseModel">BaseModel</param>
        /// <returns>DocumentTypeModel</returns>
        public static DocumentTypeModel ToEnityModel(WSDocumentType baseModel)
        {
            if (baseModel!= null)
            {
                var result = new DocumentTypeModel()
                {
                    Identifier = baseModel.Id,
                    Display = baseModel.Display,
                    Description = baseModel.Description,
                    Download = baseModel.Download
                };
                return result;
            }
            return null; 
        }

        /// <summary>
        /// Convert BaseModels list to WSDocumentType List
        /// </summary>
        /// <param name="baseModels">BaseModels List</param>
        /// <returns>DocumentTypeModel List</returns>
        public static List<DocumentTypeModel> ToEntityModels(List<WSDocumentType> baseModels)
        {
            if(baseModels!=null && baseModels.Count > 0)
            {
                var documentTypeModels = new List<DocumentTypeModel>();
                foreach(var baseModel in baseModels)
                {
                    documentTypeModels.Add(ToEnityModel(baseModel));
                };
                return documentTypeModels;
            }
            return null;
        }
    }
}
