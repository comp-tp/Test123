using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.RecordConditions
{
    public class WSSeverity : WSIdentifierBase
    {
        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSSeverity.</param>
        /// <returns>SeverityModel.</returns>
        public static SeverityModel ToEntityModel(WSSeverity wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new SeverityModel()
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
        public static WSSeverity FromEntityModel(SeverityModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSSeverity()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
