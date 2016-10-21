using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.StandardComments
{
    [DataContract(Name = "getStandardCommentsResponse")]
    public class WSStandardCommentsResponse : WSPagedResponse
    {
        [DataMember(Name = "standardComments", EmitDefaultValue = false)]
        public List<WSStandardComment> StandardComments { get; set; }

        public static WSStandardCommentsResponse FromEntityModel(StandardCommentResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentsResponse()
            {
                PageInfo = WSPagination.FromEntityModel(entityModel.PageInfo),
                StandardComments = entityModel.StandardComments == null ? null : WSStandardComment.FromEntityModels(entityModel.StandardComments.ToArray()).ToList()
            };

            return result;
        }
    }
}
