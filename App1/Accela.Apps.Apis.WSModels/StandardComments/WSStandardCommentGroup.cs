using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.WSModels.StandardComments
{
    [DataContract]
    public class WSStandardCommentGroup : WSIdentifierBase
    {
        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">WSStandardCommentGroup collection.</param>
        /// <returns>the entity models.</returns>
        public static StandardCommentGroupModel[] ToEntityModels(WSStandardCommentGroup[] wsModels)
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
        public static WSStandardCommentGroup[] FromEntityModels(StandardCommentGroupModel[] entityModels)
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
        /// <param name="wsModel">WSStandardCommentGroup.</param>
        /// <returns>the entity model.</returns>
        public static StandardCommentGroupModel ToEntityModel(WSStandardCommentGroup wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new StandardCommentGroupModel()
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
        public static WSStandardCommentGroup FromEntityModel(StandardCommentGroupModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentGroup()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
