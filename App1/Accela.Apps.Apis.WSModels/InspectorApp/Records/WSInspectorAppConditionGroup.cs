using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "conditionGroup")]
    public class WSInspectorAppConditionGroup : WSIdentifierBase
    {
        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSConditionGroup.</param>
        /// <returns>ConditionGroupModel.</returns>
        public static ConditionGroupModel ToEntityModel(WSInspectorAppConditionGroup wsModel)
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
        public static WSInspectorAppConditionGroup FromEntityModel(ConditionGroupModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSInspectorAppConditionGroup()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
