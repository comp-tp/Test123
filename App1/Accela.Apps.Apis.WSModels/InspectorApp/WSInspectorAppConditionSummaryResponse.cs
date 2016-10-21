using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppConditionSummaryResponse:WSResponseBase
    {
        [DataMember(Name = "conditionSummary", EmitDefaultValue = false)]
        public WSInspectorAppConditionSummary ConditionSummary { get; set; }

        public static WSInspectorAppConditionSummaryResponse FromEntityModel(ConditionSummaryResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var result = new WSInspectorAppConditionSummaryResponse()
            {
                ConditionSummary = WSInspectorAppConditionSummary.FromEntityModel(response.ConditionSummary)
            };

            return result;
        }
    }
}
