using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppStandardCommentGroupResponse:WSPagedResponse
    {
        [DataMember(Name = "standardCommentGroups", EmitDefaultValue = false)]
        public List<WSInspectorAppStandardCommentGroup> StandardCommentGroups { get; set; }

        public static WSInspectorAppStandardCommentGroupResponse FromEntityModel(StandardCommentGroupResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSInspectorAppStandardCommentGroupResponse()
            {
                PageInfo = WSPagination.FromEntityModel(entityModel.PageInfo),
                StandardCommentGroups = entityModel.StandardCommentGroups == null ? null : WSInspectorAppStandardCommentGroup.FromEntityModels(entityModel.StandardCommentGroups.ToArray()).ToList()
            };

            return result;
        }
    }
}
