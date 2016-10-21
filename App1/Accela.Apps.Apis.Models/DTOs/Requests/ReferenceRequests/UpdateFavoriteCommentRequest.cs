using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests
{
    [DataContract]
    public class UpdateFavoriteCommentRequest: RequestBase
    {
        /// <summary>
        /// Client's last version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Favorite comments
        /// </summary>
        [DataMember(Name = "favoriteComment", EmitDefaultValue = false)]
        public FavoriteCommentModel FavoriteComment { get; set; }
    }
}
