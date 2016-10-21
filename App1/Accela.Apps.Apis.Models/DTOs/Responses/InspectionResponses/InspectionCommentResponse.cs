using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    /// <summary>
    /// inspection comment response
    /// </summary>
    [DataContract(Name = "getInspectionCommentResponse")]
    public class InspectionCommentResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection comments.
        /// </summary>
        /// <value>
        /// The inspection comments.
        /// </value>
        [DataMember(Name = "inspectionComments")]
        public List<Comment> InspectionComments
        {
            get;
            set;
        }
    }
}
