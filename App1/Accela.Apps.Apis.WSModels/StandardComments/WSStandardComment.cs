using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.WSModels.StandardComments
{
    [DataContract]
    public class WSStandardComment
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
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
        public WSStandardCommentGroup CommentGroup
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
        public WSStandardCommentType CommentType
        {
            get;
            set;
        }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The ws models.</param>
        /// <returns>the entity models.</returns>
        public static StandardCommentModel[] ToEntityModels(WSStandardComment[] wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSStandardComment[] FromEntityModels(StandardCommentModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The ws model.</param>
        /// <returns>the entity model.</returns>
        public static StandardCommentModel ToEntityModel(WSStandardComment wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new StandardCommentModel()
            {
                Identifier = wsModel.Id,
                Display = wsModel.Display,
                Comments = wsModel.Comments,
                CommentGroup = WSStandardCommentGroup.ToEntityModel(wsModel.CommentGroup),
                CommentType = WSStandardCommentType.ToEntityModel(wsModel.CommentType)
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSStandardComment FromEntityModel(StandardCommentModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardComment()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display,
                Comments = entityModel.Comments,
                CommentGroup = WSStandardCommentGroup.FromEntityModel(entityModel.CommentGroup),
                CommentType = WSStandardCommentType.FromEntityModel(entityModel.CommentType)
            };

            return result;
        }
    }
}
