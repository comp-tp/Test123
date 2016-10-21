using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppStandardComment:WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comment group.
        /// </summary>
        /// <value>
        /// The comment group.
        /// </value>
        [DataMember(Name = "commentGroup", EmitDefaultValue = false)]
        public WSInspectorAppStandardCommentGroup CommentGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the comment.
        /// </summary>
        /// <value>
        /// The type of the comment.
        /// </value>
        [DataMember(Name = "commentType", EmitDefaultValue = false)]
        public WSInspectorAppStandardCommentType CommentType
        {
            get;
            set;
        }

        public static WSInspectorAppStandardComment FromEntityModel(StandardCommentModel standardComment)
        {
            if (standardComment == null)
            {
                return null;
            }

            var result = new WSInspectorAppStandardComment()
            {
                Comments= standardComment.Comments,
                Display=standardComment.Display,
                Id = standardComment.Identifier,
                CommentGroup = WSInspectorAppStandardCommentGroup.FromEntityModel(standardComment.CommentGroup),
                CommentType= WSInspectorAppStandardCommentType.FromEntityModel(standardComment.CommentType)
            };

            return result;
        }
    }
}
