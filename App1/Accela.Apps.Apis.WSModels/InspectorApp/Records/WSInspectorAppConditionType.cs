using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "conditionType")]
    public class WSInspectorAppConditionType : WSIdentifierBase
    {
        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSInspectorAppConditionType.</param>
        /// <returns>the entity model.</returns>
        public static ConditionTypeModel ToEntityModel(WSInspectorAppConditionType wsModel)
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
        public static WSInspectorAppConditionType FromEntityModel(ConditionTypeModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSInspectorAppConditionType()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
