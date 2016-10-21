using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract]
    public class CreateFavoriteCommentResponse : ResponseBase
    {
        /// <summary>
        /// Client's last version
        /// </summary>
        [DataMember(Name = "lastVersion", EmitDefaultValue = false)]
        public int LastVersion { get; set; }

        /// <summary>
        /// FavoriteComment's sid
        /// </summary>
        [DataMember(Name = "sid", EmitDefaultValue = false)]
        public string SID { get; set; }
    }
}
