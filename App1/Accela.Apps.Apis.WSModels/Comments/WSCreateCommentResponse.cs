using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CitizenCommentResponses;

namespace Accela.Apps.Apis.WSModels.Comments
{
    [DataContract(Name="createCommentResponse")]
    public class WSCreateCommentResponse : WSResponseBase
    {
        [DataMember(Name = "commentID", EmitDefaultValue = false)]
        public string CommentID { get; set; }

        /// <summary>
        /// Convert CreateCommentResponse to WSCreateCommentResponse.
        /// </summary>
        /// <param name="createCommentResponse">CreateCommentResponse.</param>
        /// <returns>WSCreateCommentResponse.</returns>
        public static WSCreateCommentResponse FromEntityModel(CreateCommentResponse createCommentResponse)
        {
            WSCreateCommentResponse wsCreateCommentResponse = null;
            if (createCommentResponse != null)
            {
                if (createCommentResponse.CommentModel != null)
                {
                    wsCreateCommentResponse = new WSCreateCommentResponse();
                    wsCreateCommentResponse.CommentID = createCommentResponse.CommentModel.ID.ToString();
                }
            }

            return wsCreateCommentResponse;
        }
    }
}
