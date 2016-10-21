using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.WSModels.StandardComments
{
    [DataContract]
    public class WSStandardCommentType : WSDataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
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
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">WSStandardCommentType list.</param>
        /// <returns>the entity models.</returns>
        public static StandardCommentTypeModel[] ToEntityModels(WSStandardCommentType[] wsModels)
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
        public static WSStandardCommentType[] FromEntityModels(StandardCommentTypeModel[] entityModels)
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
        /// <param name="wsModel">WSStandardCommentType.</param>
        /// <returns>the entity model.</returns>
        public static StandardCommentTypeModel ToEntityModel(WSStandardCommentType wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new StandardCommentTypeModel()
            {
                Identifier = wsModel.Id,
                Display = wsModel.Display
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSStandardCommentType FromEntityModel(StandardCommentTypeModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentType()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
