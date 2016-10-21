using System;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class StandardCommentHelper : GovXmlHelperBase
    {
        public static StandardCommentResponse ToClientStandardComments(GetStandardCommentsResponse response)
        {
            StandardCommentResponse results = new StandardCommentResponse();
            var standardComments = response != null && response.standardComments != null && response.standardComments.standardComment != null && response.standardComments.standardComment.Length > 0 ? response.standardComments.standardComment : null;
            var standardCommentGroups = response != null && response.standardCommentsGroups != null && response.standardCommentsGroups.standardCommentsGroups != null && response.standardCommentsGroups.standardCommentsGroups.Length > 0 ? response.standardCommentsGroups.standardCommentsGroups : null;
            standardCommentGroups = standardCommentGroups == null ? new StandardCommentsGroup[] { } : standardCommentGroups;

            var gc = standardComments != null ?
                        from c in standardComments
                        where c != null
                        let cGroupId =
                            c.type != null &&
                            c.type.standardCommentsGroups != null &&
                            c.type.standardCommentsGroups.standardCommentsGroupIds != null &&
                            c.type.standardCommentsGroups.standardCommentsGroupIds.Length > 0
                                ? c.type.standardCommentsGroups.standardCommentsGroupIds[0].keys.ToStringKeys()
                                : String.Empty
                        join g in standardCommentGroups.DefaultIfEmpty()
                            on cGroupId equals (g != null && g.keys != null ? g.keys.ToStringKeys() : String.Empty) into cWithGroups
                        from g in cWithGroups.DefaultIfEmpty()
                        select new { Comment = c, Group = g }
                        :
                        from g in standardCommentGroups
                        where g != null
                        && g.standardComment != null
                        && g.standardComment.standardComment != null
                        && g.standardComment.standardComment.Length > 0
                        from c in g.standardComment.standardComment
                        where c != null
                        select new { Comment = c, Group = g };
            var tempResults = from i in gc
                              let g = i.Group
                              let c = i.Comment
                              select new StandardCommentModel()
                              {
                                  Identifier = g != null && c.keys != null ? g.keys.Contact(c.keys).ToStringKeys() : (c.keys != null ? c.keys.ToStringKeys() : String.Empty),
                                  Display = c.identifierDisplay,
                                  Comments = c.text,
                                  CommentGroup = g == null ? null : new StandardCommentGroupModel()
                                  {
                                      Identifier = g.keys != null ? g.keys.ToStringKeys() : String.Empty,
                                      Display = g.identifierDisplay
                                  },
                                  CommentType = c.type == null ? null : new StandardCommentTypeModel()
                                  {
                                      Identifier = c.type.keys != null ? c.type.keys.ToStringKeys() : String.Empty,
                                      Display = c.type.identifierDisplay
                                  }
                              };
            results.StandardComments = tempResults.ToList();

            return results;
        }
    }
}
