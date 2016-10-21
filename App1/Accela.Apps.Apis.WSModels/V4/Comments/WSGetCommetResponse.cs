using Accela.Apps.Apis.Models.DTOs.Responses.CitizenCommentResponses;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract(Name = "getCommentsResponse")]
    public class WSGetCommentV4Response : WSResponseBase
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<WSCommentV4> Comments { get; set; }

        public static WSGetCommentV4Response FromEntityModel(GetCommentResponse getCommentResponse)
        {
            WSGetCommentV4Response wsCommetResponse = new WSGetCommentV4Response();
            wsCommetResponse.Comments = new List<WSCommentV4>();
            if (getCommentResponse == null) return wsCommetResponse;
            
            if (getCommentResponse.CitizenComments != null && getCommentResponse.CitizenComments.Count > 0)
            {                    
                foreach (var citizenCommentModel in getCommentResponse.CitizenComments)
                {
                    var wsComment = WSCommentV4.FromEntityModel(citizenCommentModel);
                    wsCommetResponse.Comments.Add(wsComment);
                }
            };

            return wsCommetResponse;
        }
    }
}
