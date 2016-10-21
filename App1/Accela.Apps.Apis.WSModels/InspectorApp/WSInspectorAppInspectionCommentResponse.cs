using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppInspectionCommentResponse :  WSPagedResponse
    {
        [DataMember(Name = "inspectionComments", EmitDefaultValue = false)]
        public List<WSInspectorAppComment> InspectorAppComments { get; set; }

        public static WSInspectorAppInspectionCommentResponse FromEntityModel(InspectionCommentResponse inspectionCommentResponse)
        {
            var wsInspectorAppInspectionCommentResponse = new WSInspectorAppInspectionCommentResponse();
            if (inspectionCommentResponse != null)
            {
                if (inspectionCommentResponse.PageInfo != null)
                {
                    wsInspectorAppInspectionCommentResponse.PageInfo = new WSPagination();
                    wsInspectorAppInspectionCommentResponse.PageInfo.TotalRows = inspectionCommentResponse.PageInfo.TotalRows;
                    wsInspectorAppInspectionCommentResponse.PageInfo.HasMore = inspectionCommentResponse.PageInfo.TotalRows > inspectionCommentResponse.PageInfo.Offset + inspectionCommentResponse.PageInfo.Limit;
                }

                wsInspectorAppInspectionCommentResponse.InspectorAppComments = WSInspectorAppComment.FromEntityModels(inspectionCommentResponse.InspectionComments);
            }
            return wsInspectorAppInspectionCommentResponse;
        }
    }
}
