using System.IO;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
    [DataContract]
    public class CreateAttachmentRequest : RequestBase
    {
        [DataMember(Name = "attachment")]
        public Attachment Attachment { get; set; }

        public string EntityId { get; set; }
        public string EntityType { get; set; }
        public Stream FileContent { get; set; }
    }
}
