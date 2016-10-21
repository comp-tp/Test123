using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using System.Linq;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.StandardComments.V4
{
    [DataContract]
    public class WSStandardCommentV4
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
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
        [DataMember(Name = "text", EmitDefaultValue = false)]
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
        [DataMember(Name = "group", EmitDefaultValue = false)]
        public WSStandardCommentGroupV4 CommentGroup
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
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSStandardCommentTypeV4 CommentType
        {
            get;
            set;
        }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The ws models.</param>
        /// <returns>the entity models.</returns>
        public static StandardCommentModel[] ToEntityModels(WSStandardCommentV4[] wsModels)
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
        public static WSStandardCommentV4[] FromEntityModels(StandardCommentModel[] entityModels)
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
        public static StandardCommentModel ToEntityModel(WSStandardCommentV4 wsModel)
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
                CommentGroup = WSStandardCommentGroupV4.ToEntityModel(wsModel.CommentGroup),
                CommentType = WSStandardCommentTypeV4.ToEntityModel(wsModel.CommentType)
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSStandardCommentV4 FromEntityModel(StandardCommentModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentV4()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display,
                Comments = entityModel.Comments,
                CommentGroup = WSStandardCommentGroupV4.FromEntityModel(entityModel.CommentGroup),
                CommentType = WSStandardCommentTypeV4.FromEntityModel(entityModel.CommentType)
            };

            return result;
        }
    }
}
