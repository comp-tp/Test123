using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
    /// <summary>
    /// The class didn't interact with client
    /// </summary>
    public class AttachmentsRequest : PageListRequest
    {
        public string EntityId{ get; set; }
        public string EntityType { get; set; }
    }
}
