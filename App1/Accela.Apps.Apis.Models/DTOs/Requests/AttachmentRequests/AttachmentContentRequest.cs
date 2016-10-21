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
    /// so it is NOT mark as data contract
    /// </summary>
    public class AttachmentContentRequest: RequestBase
    {
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string AttachmentId { get; set; }
    }
}
