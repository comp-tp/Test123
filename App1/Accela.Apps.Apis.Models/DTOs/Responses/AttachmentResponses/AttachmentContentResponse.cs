using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses
{
    [DataContract]
    public class AttachmentContentResponse : ResponseBase
    {
        public Stream FileContent { get; set; }
    }
}
