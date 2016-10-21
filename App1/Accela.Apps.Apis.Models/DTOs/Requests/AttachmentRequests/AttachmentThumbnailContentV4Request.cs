using System;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
    [DataContract]
    public class AttachmentThumbnailContentV4Request : RequestBase
    {
        [DataMember(Name = "attachmentId")]
        public string AttachmentId { get; set; }

        [DataMember(Name = "pixelWidth")]
        public int PixelWidth { get; set; }

        [DataMember(Name = "pixelHeight")]
        public int PixelHeight { get; set; }

        public AttachmentV4Model Attachment { get; set; }
    }

    [DataContract]
    public class AttachmentV4Request : RequestBase
    {
        [DataMember(Name = "attachmentId")]
        public string AttachmentId { get; set; }
    }
}
