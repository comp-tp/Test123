using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses
{
    [DataContract(Name = "getAttachmentResponse")]
    public class AttachmentsResponse : PagedResponse
    {
        [DataMember(Name = "attachments", EmitDefaultValue = false)]
        public List<Attachment> Attachments { get; set; }
    }
}