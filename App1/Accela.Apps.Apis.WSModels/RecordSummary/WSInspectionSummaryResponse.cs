using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "inspectionSummaryResponse")]
    public class WSInspectionSummaryResponse : WSResponseBase
    {
        [DataMember(Name = "inspectionSummary", EmitDefaultValue = false)]
        public WSInspectionSummary InspectionSummary { get; set; }

        public static WSInspectionSummaryResponse FromEntityModel(InspectionSummaryResponse response)
        {
            WSInspectionSummaryResponse result = null;

            if (response != null)
            {
                result = new WSInspectionSummaryResponse()
                {
                    InspectionSummary = WSInspectionSummary.FromEntityModel(response.InspectionSummary)
                };
            }

            return result;
        }
    }
}
