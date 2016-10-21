using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract(Name = "comment")]
    public class WSCommentV4
    {
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        [DataMember(Name = "comment", EmitDefaultValue = false, Order = 2)]
        public string Comment { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false, Order = 3)]
        public string CreatedBy { get; set; }

        [DataMember(Name = "createdDate", EmitDefaultValue = false, Order = 4)]
        public string CreatedDate { get; set; }

        public static WSCommentV4 FromEntityModel(CitizenCommentModel citizenCommentModel)
        {
            WSCommentV4 wsComment = null;
            if (citizenCommentModel != null)
            {
                return new WSCommentV4()
                {
                    Id = citizenCommentModel.ID.ToString(),
                    Comment = citizenCommentModel.Comment,
                    CreatedBy = citizenCommentModel.CreatedBy,
                    CreatedDate = citizenCommentModel.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"),
                };
            }
            return wsComment;
        }

    }
}
