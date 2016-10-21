using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    /// <summary>
    /// Standard comment response
    /// </summary>
    [DataContract(Name = "GetStandardCommentResponse")]
    public class StandardCommentResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the standard comments.
        /// </summary>
        /// <value>
        /// The standard comments.
        /// </value>
        [DataMember(Name = "standardComments")]
        public List<StandardCommentModel> StandardComments 
        { 
            get; 
            set; 
        }
    }
}
