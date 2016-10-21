using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.WSModels.RecordConditions
{
    [DataContract(Name = "getRecordConditionsResponse")]
    public class WSRecordConditionsResponse : WSResponseBase
    {
        /// <summary>
        /// The record conditions information.
        /// </summary>
        [DataMember(Name = "conditions", EmitDefaultValue = false)]
        public List<WSCondition> Conditions { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>WSRecordConditionsResponse.</returns>
        public static WSRecordConditionsResponse FromEntityModel(ConditionsResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSRecordConditionsResponse()
            {
                Conditions = entityModel.Conditions == null ? null : WSCondition.FromEntityModels(entityModel.Conditions.ToArray()).ToList()
            };

            return result;
        }
    }
}
