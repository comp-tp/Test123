using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses
{
    [DataContract]
    public class UploadAttachmentDescResponse : ResponseBase
    {
        [DataMember(Name="key")]
        public string Key { get; set; }
    }
}
