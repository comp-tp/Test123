using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;

namespace Accela.Apps.Apis.WSModels.RecordConditions
{
    [DataContract(Name = "conditionType")]
    public class WSConditionType : WSIdentifierBase
    {
        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSConditionType.</param>
        /// <returns>the entity model.</returns>
        public static ConditionTypeModel ToEntityModel(WSConditionType wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ConditionTypeModel()
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
        public static WSConditionType FromEntityModel(ConditionTypeModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSConditionType()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
