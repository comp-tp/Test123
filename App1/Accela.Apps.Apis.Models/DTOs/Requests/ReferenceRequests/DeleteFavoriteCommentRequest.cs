using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests
{
    [DataContract]
    public class DeleteFavoriteCommentRequest : RequestBase
    {
        /// <summary>
        /// Client's last version
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// Favorite comment sid
        /// </summary>
        [DataMember(Name = "sid", EmitDefaultValue = false)]
        public string SID { get; set; }
    }
}
