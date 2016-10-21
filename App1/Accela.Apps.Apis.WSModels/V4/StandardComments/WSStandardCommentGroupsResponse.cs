using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.StandardComments.V4
{
    [DataContract(Name = "getStandardCommentGroupsResponse")]
    public class WSStandardCommentGroupsV4Response : WSPagedResponse
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<WSStandardCommentGroupV4> StandardCommentGroups { get; set; }

        public static WSStandardCommentGroupsV4Response FromEntityModel(StandardCommentGroupResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentGroupsV4Response()
            {
                PageInfo = WSPagination.FromEntityModel(entityModel.PageInfo),
                StandardCommentGroups = entityModel.StandardCommentGroups == null ? null : WSStandardCommentGroupV4.FromEntityModels(entityModel.StandardCommentGroups.ToArray()).ToList()
            };

            return result;
        }
    }
}
