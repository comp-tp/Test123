using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
    [DataContract]
    public class UploadAttachmentDescRequest : RequestBase
    {
        [DataMember(Name = "desc")]
        public string Desc { get; set; }

        [DataMember(Name = "inspectionId")]
        public string InspectionId { get; set; }

        [DataMember(Name = "fileName")]
        public string FileName { get; set; }
    }
}
