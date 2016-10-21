using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract]
    public class UpdateFavoriteCommentResponse : ResponseBase
    {
        /// <summary>
        /// Client's last version
        /// </summary>
        [DataMember(Name = "lastVersion", EmitDefaultValue = false)]
        public int LastVersion { get; set; }
    }
}
