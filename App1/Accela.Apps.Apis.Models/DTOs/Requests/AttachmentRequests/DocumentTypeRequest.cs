using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
   public class DocumentTypeRequest : PageListRequest
    {
        /// <summary>
        /// related id
        /// </summary>
        public string RelatedId { get; set; }
    }
}
