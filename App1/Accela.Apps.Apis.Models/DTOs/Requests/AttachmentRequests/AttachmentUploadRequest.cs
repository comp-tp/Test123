using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests
{
    /// <summary>
    /// Attachment upload request.
    /// </summary>
    [DataContract]
    public class AttachmentUploadRequest : RequestBase
    {
        /// <summary>
        /// Description Key
        /// </summary>
        [DataMember]
        public string DescKey
        {
            get;
            set;
        }
    }
}
