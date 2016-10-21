using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CitizenCommentResponses
{
    [DataContract]
    public class GetCommentResponse : PagedResponse
    {
        [DataMember(EmitDefaultValue=false)]
        public List<CitizenCommentModel> CitizenComments { get; set; }
    }
}
