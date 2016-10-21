using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.WSModels.RecordConditions4V3p
{
    [DataContract(Name = "getRecordConditionsResponse")]
    public class WSRecordConditionsResponse4V3p : WSResponseBase
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<WSCondition4V3p> Conditions { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>WSRecordConditionsResponse.</returns>
        public static WSRecordConditionsResponse4V3p FromEntityModel(ConditionsResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSRecordConditionsResponse4V3p()
            {
                Conditions = entityModel.Conditions == null ? null : WSCondition4V3p.FromEntityModels(entityModel.Conditions.ToArray()).ToList()
            };

            return result;
        }
    }
}
