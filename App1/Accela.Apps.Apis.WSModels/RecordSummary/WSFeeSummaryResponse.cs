using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "feeSummaryResponse")]
    public class WSFeeSummaryResponse : WSResponseBase
    {
        [DataMember(Name = "feeSummary", EmitDefaultValue = false)]
        public WSFeeSummary FeeSummary { get; set; }

        public static WSFeeSummaryResponse FromEntityModel(FeeSummaryResponse response)
        {
            WSFeeSummaryResponse result = null;

            if (response != null)
            {
                result = new WSFeeSummaryResponse()
                {
                    FeeSummary = WSFeeSummary.FromEntityModel(response.FeeSummary)
                };
            }

            return result;
        }
    }
}
