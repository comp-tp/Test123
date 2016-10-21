using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.StandardComments
{
    [DataContract(Name = "getStandardCommentGroupsResponse")]
    public class WSStandardCommentGroupsResponse : WSPagedResponse
    {
        [DataMember(Name = "standardCommentGroups", EmitDefaultValue = false)]
        public List<WSStandardCommentGroup> StandardCommentGroups { get; set; }

        public static WSStandardCommentGroupsResponse FromEntityModel(StandardCommentGroupResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentGroupsResponse()
            {
                PageInfo = WSPagination.FromEntityModel(entityModel.PageInfo),
                StandardCommentGroups = entityModel.StandardCommentGroups == null ? null : WSStandardCommentGroup.FromEntityModels(entityModel.StandardCommentGroups.ToArray()).ToList()
            };

            return result;
        }
    }
}
