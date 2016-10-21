using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.V4;

namespace Accela.Apps.Apis.WSModels.StandardComments.V4
{
    [DataContract]
    public class WSStandardCommentGroupV4 : WSIdentifierBaseV4
    {
        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">WSStandardCommentGroup collection.</param>
        /// <returns>the entity models.</returns>
        public static StandardCommentGroupModel[] ToEntityModels(WSStandardCommentGroupV4[] wsModels)
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
        public static WSStandardCommentGroupV4[] FromEntityModels(StandardCommentGroupModel[] entityModels)
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
        public static StandardCommentGroupModel ToEntityModel(WSStandardCommentGroupV4 wsModel)
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
        public static WSStandardCommentGroupV4 FromEntityModel(StandardCommentGroupModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardCommentGroupV4()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
