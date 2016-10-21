using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CitizenCommentResponses
{
    [DataContract]
    public class CreateCommentResponse : ResponseBase
    {
        [DataMember(Name = "comment", EmitDefaultValue=false)]
        public CitizenCommentModel CommentModel { get; set; }

        [DataMember(Name = "userCommentCount", EmitDefaultValue = false)]
        public int UserCommentCount { get; set; }

    }
}
