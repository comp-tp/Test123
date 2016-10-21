using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "conditionSummaryResponse")]
    public class WSConditionSummaryResponse : WSResponseBase
    {
        [DataMember(Name = "conditionSummary", EmitDefaultValue = false)]
        public WSConditionSummary ConditionSummary { get; set; }

        public static WSConditionSummaryResponse FromEntityModel(ConditionSummaryResponse response)
        {
            WSConditionSummaryResponse result = null;

            if (response != null)
            {
                result = new WSConditionSummaryResponse()
                {
                    ConditionSummary = WSConditionSummary.FromEntityModel(response.ConditionSummary)
                };
            }

            return result;
        }
    }
}
