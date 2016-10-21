using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CitizenCommentResponses;

namespace Accela.Apps.Apis.WSModels.Comments
{
    [DataContract(Name = "getCommentsResponse")]
    public class WSGetCommentResponse : WSResponseBase
    {
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public List<WSComment> Comments { get; set; }

        public static WSGetCommentResponse FromEntityModel(GetCommentResponse getCommentResponse)
        {
            WSGetCommentResponse wsCommetResponse = null;
            if (getCommentResponse != null)
            {
                wsCommetResponse = new WSGetCommentResponse();
                if (getCommentResponse.CitizenComments != null && getCommentResponse.CitizenComments.Count > 0)
                {                    
                    wsCommetResponse.Comments = new List<WSComment>();
                    foreach (var citizenCommentModel in getCommentResponse.CitizenComments)
                    {
                        var wsComment = WSComment.FromEntityModel(citizenCommentModel);
                        wsCommetResponse.Comments.Add(wsComment);
                    }
                };
            }

            return wsCommetResponse;
        }
    }
}
