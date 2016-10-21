using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using System.IO;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses
{
    [DataContract(Name = "getAttachmentResponse")]
    public class AttachmentResponse : ResponseBase
    {
        //[DataMember(Name = "attachment", EmitDefaultValue = false)]
        //public CivicHeroAttachmentModel Attachment { get; set; }

        public Stream FileContent { get; set; }
    }
}
