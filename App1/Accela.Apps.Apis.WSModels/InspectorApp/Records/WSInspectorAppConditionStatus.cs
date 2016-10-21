using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "conditionStatus")]
    public class WSInspectorAppConditionStatus : WSIdentifierBase
    {
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsConditionStatus">WSInspectorAppConditionStatus.</param>
        /// <returns>ConditionStatusModel.</returns>
        public static ConditionStatusModel ToEntityModel(WSInspectorAppConditionStatus wsConditionStatus)
        {
            if (wsConditionStatus == null)
            {
                return null;
            }

            var result = new ConditionStatusModel()
            {
                Identifier = wsConditionStatus.Id,
                Display = wsConditionStatus.Display,
                Type = wsConditionStatus.Type
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSInspectorAppConditionStatus FromEntityModel(ConditionStatusModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSInspectorAppConditionStatus()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display,
                Type = entityModel.Type
            };

            return result;
        }
    }
}
