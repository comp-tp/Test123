using System.IO;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses
{
    [DataContract]
    public class AttachmentContentV4Response : ResponseBase
    {
        public string ContentType { get; set; }
        public Stream FileContent { get; set; }
    }
}
