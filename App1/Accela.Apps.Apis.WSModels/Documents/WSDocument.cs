using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Documents
{
    [DataContract(Name = "document")]
    public class WSDocument : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "fileName", EmitDefaultValue = false)]
        public string FileName { get; set; }

        [DataMember(Name = "fileType", EmitDefaultValue = false)]
        public string FileType { get; set; }

        [DataMember(Name = "fileSize", EmitDefaultValue = false)]
        public int FileSize { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "documentType", EmitDefaultValue = false)]
        public string DocumentType { get; set; }

        public static WSDocument FromEntityModel(Attachment entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            return new WSDocument
            {
                Id = entityModel.Identifier,
                FileName = entityModel.FileName,
                FileSize = entityModel.FileSize,
                FileType = entityModel.FileType,
                Description = entityModel.Description,
                DocumentType = entityModel.AttachmentType
            };
        }

        public static Attachment ToEntityModel(WSDocument serviceModel)
        {
            if (serviceModel == null)
            {
                return null;
            }

            return new Attachment
            {
                Identifier = serviceModel.Id,
                FileName = serviceModel.FileName,
                FileType = serviceModel.FileType,
                FileSize = serviceModel.FileSize,
                Description = serviceModel.Description,
                AttachmentType = serviceModel.DocumentType
            };
        }
    }
}
