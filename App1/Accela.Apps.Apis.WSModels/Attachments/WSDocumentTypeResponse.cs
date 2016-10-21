using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;

namespace Accela.Apps.Apis.WSModels.Attachments
{
    [DataContract(Name = "getDocumentTypesResponse")]
    public class WSDocumentTypeResponse : WSPagedResponse
    {
        [DataMember(Name = "documentGroups", EmitDefaultValue = false)]
        public List<WSDocumentGroup> DocumenttGroup { get; set; }

        /// <summary>
        /// Converts from the entity model
        /// </summary>
        /// <param name="entityModel">The entity model</param>
        /// <returns>basic owners respnose</returns>
        public static WSDocumentTypeResponse FromEntityModel(DocumentTypesResponse documentResponse)
        {
            return new WSDocumentTypeResponse()
            {
                DocumenttGroup = GetDocumentGroupMode(documentResponse)
            };
        }

        public static List<WSDocumentGroup> GetDocumentGroupMode(DocumentTypesResponse documentTypesResponse)
        { 
            if(documentTypesResponse == null || documentTypesResponse.DocumentGroup == null ||
               documentTypesResponse.DocumentGroup.Count == 0 ) return null;
            List<WSDocumentGroup> wsDocumentModel = new List<WSDocumentGroup>();
            foreach(DocumentGroupModel addModel in documentTypesResponse.DocumentGroup)
            {
                WSDocumentGroup group = new WSDocumentGroup()
                {
                    Id = addModel.Identifier,
                    Display = addModel.Dispaly,
                    Type = ToDocumentType(addModel.DocumentType)
                };
                wsDocumentModel.Add(group);
            }
            return wsDocumentModel;
        }

        private static List<WSDocumentType> ToDocumentType(List<DocumentTypeModel> addItemLst)
        {
            if (addItemLst == null || addItemLst.Count == 0) return null;
            List<WSDocumentType> documentTypeLst = new List<WSDocumentType>();
            foreach (DocumentTypeModel addItem in addItemLst)
            {
                WSDocumentType type = new WSDocumentType()
                {
                    Id = addItem.Identifier,
                    Display = addItem.Display,
                    Description = addItem.Description,
                    Download = addItem.Download,
                };
                documentTypeLst.Add(type);
            }
            return documentTypeLst;
        }

    }
}
