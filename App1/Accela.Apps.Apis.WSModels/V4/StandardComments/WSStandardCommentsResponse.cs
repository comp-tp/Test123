using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.StandardComments.V4
{
    [DataContract(Name = "getStandardCommentsResponse")]
    public class WSStandardCommentsV4Response : WSPagedResponse
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<WSStandardCommentV4> StandardComments { get; set; }

        public static WSStandardCommentsV4Response FromEntityModel(StandardCommentResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentsV4Response()
            {
                PageInfo = WSPagination.FromEntityModel(entityModel.PageInfo),
                StandardComments = entityModel.StandardComments == null ? null : WSStandardCommentV4.FromEntityModels(entityModel.StandardComments.ToArray()).ToList()
            };

            return result;
        }
    }
}
