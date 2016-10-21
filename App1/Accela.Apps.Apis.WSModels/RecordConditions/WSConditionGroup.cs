using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;

namespace Accela.Apps.Apis.WSModels.RecordConditions
{
    [DataContract(Name = "conditionGroup")]
    public class WSConditionGroup : WSIdentifierBase
    {
        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSConditionGroup.</param>
        /// <returns>ConditionGroupModel.</returns>
        public static ConditionGroupModel ToEntityModel(WSConditionGroup wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ConditionGroupModel()
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
        public static WSConditionGroup FromEntityModel(ConditionGroupModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSConditionGroup()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
