using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.WSModels.V4;
using System.Linq;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.StandardComments
{
    [DataContract]
    public class WSStandardCommentTypeV4 : WSIdentifierBaseV4
    {
        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">WSStandardCommentType list.</param>
        /// <returns>the entity models.</returns>
        public static StandardCommentTypeModel[] ToEntityModels(WSStandardCommentTypeV4[] wsModels)
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
        public static WSStandardCommentTypeV4[] FromEntityModels(StandardCommentTypeModel[] entityModels)
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
        public static StandardCommentTypeModel ToEntityModel(WSStandardCommentTypeV4 wsModel)
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
        public static WSStandardCommentTypeV4 FromEntityModel(StandardCommentTypeModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentTypeV4()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
