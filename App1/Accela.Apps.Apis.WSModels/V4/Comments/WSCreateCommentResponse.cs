using Accela.Apps.Apis.Models.DTOs.Responses.CitizenCommentResponses;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract(Name="createCommentResponse")]
    public class WSCreateCommentV4Response : WSResponseBase
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public string CommentID { get; set; }

        /// <summary>
        /// Convert CreateCommentResponse to WSCreateCommentResponse.
        /// </summary>
        /// <param name="createCommentResponse">CreateCommentResponse.</param>
        /// <returns>WSCreateCommentResponse.</returns>
        public static WSCreateCommentV4Response FromEntityModel(CreateCommentResponse createCommentResponse)
        {
            WSCreateCommentV4Response wsCreateCommentResponse = null;
            if (createCommentResponse != null)
            {
                if (createCommentResponse.CommentModel != null)
                {
                    wsCreateCommentResponse = new WSCreateCommentV4Response();
                    wsCreateCommentResponse.CommentID = createCommentResponse.CommentModel.ID.ToString();
                }
            }

            return wsCreateCommentResponse;
        }
    }
}
