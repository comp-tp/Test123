using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "conditionsResponse")]
    public class WSInspectorAppConditionsResponse
    {
        [DataMember(Name = "conditions", EmitDefaultValue = false)]
        public List<WSInspectorAppCondition> Conditions { get; set; }

        public static WSInspectorAppConditionsResponse FromEntityModel(ConditionsResponse model)
        {
            WSInspectorAppConditionsResponse result = null;

            if (model != null)
            {
                var conditionArray = model.Conditions != null ? model.Conditions.ToArray() : null;
                var conditionArray4Entity = WSInspectorAppCondition.FromEntityModels(conditionArray);
                var conditionList = conditionArray4Entity != null ? new List<WSInspectorAppCondition>(conditionArray4Entity) : null;
                result = new WSInspectorAppConditionsResponse()
                {
                    Conditions = conditionList
                };
            }

            return result;
        }
    }
}
