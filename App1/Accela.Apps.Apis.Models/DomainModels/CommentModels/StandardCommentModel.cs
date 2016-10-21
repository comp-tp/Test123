using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.CommentModels
{
    [DataContract]
    public class StandardCommentModel : DataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display
        {
            get;
            set;
        }

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
        public StandardCommentGroupModel CommentGroup
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
        public StandardCommentTypeModel CommentType
        {
            get;
            set;
        }
    }
}
