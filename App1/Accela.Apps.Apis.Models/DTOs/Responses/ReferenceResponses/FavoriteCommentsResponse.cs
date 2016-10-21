using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract]
    public class FavoriteCommentsResponse : ResponseBase
    {
        /// <summary>
        /// Client's last version
        /// </summary>
        [DataMember(Name = "lastVersion", EmitDefaultValue = false)]
        public int LastVersion { get; set; }

        /// <summary>
        /// FavoriteComments for response to
        /// </summary>
        [DataMember(Name = "favoriteComments", EmitDefaultValue = false)]
        public List<FavoriteCommentModel> FavoriteComments { get; set; }
    }
}
