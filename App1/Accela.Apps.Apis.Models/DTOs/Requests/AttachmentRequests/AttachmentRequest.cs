using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
    public class AttachmentRequest : RequestBase
    {
        public string RecordId { get; set; }

        public string DocumentId { get; set; }

        public string EntityType { get; set; }
    }
}