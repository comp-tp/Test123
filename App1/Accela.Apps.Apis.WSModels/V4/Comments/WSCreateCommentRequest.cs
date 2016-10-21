using Accela.Apps.Apis.Models.DTOs.Requests.CitizenCommentRequests;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract(Name="commentRequest")]
    public class WSCreateCommentV4Request
    {
        [DataMember(Name = "comment", Order = 1)]
        public string Comment { get; set; }

        public static CreateCommentRequest ToEntityModel(WSCreateCommentV4Request wsCreateCommentRequest)
        {
            var createCommentRequest = new CreateCommentRequest {Comment = wsCreateCommentRequest.Comment};
            return createCommentRequest;
        }
    }
}
