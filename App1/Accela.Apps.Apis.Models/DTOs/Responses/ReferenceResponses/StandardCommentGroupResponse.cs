using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "getStandardCommentGroupResponse")]
    public class StandardCommentGroupResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the standard comment groups.
        /// </summary>
        /// <value>
        /// The standard comment groups.
        /// </value>
        [DataMember(Name = "standardCommentGroups")]
        public List<StandardCommentGroupModel> StandardCommentGroups
        {
            get;
            set;
        }
    }
}
