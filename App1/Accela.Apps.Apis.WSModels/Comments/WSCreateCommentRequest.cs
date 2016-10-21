using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.CitizenCommentRequests;

namespace Accela.Apps.Apis.WSModels.Comments
{
    [DataContract(Name="commentRequest")]
    public class WSCreateCommentRequest
    {
        //[DataMember(Name = "objectID", Order = 1)]
        //public string GlobalEntityID { get; set; }

        [DataMember(Name = "comment", Order = 1)]
        public string Comment { get; set; }

        public static CreateCommentRequest ToEntityModel(WSCreateCommentRequest wsCreateCommentRequest)
        {
            var createCommentRequest = new CreateCommentRequest();
            createCommentRequest.Comment = wsCreateCommentRequest.Comment;
            return createCommentRequest;
        }
    }
}
