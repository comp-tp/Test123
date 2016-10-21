using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
    [DataContract]
    public class AttachmentThumbContentRequest : RequestBase
    {
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string AttachmentId { get; set; }

        [DataMember(Name = "pixelWidth")]
        public int PixelWidth { get; set; }

        [DataMember(Name = "pixelHeight")]
        public int PixelHeight { get; set; }

    }
}
