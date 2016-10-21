using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "workflowSummaryResponse")]
    public class WSContactSummaryResponse : WSResponseBase
    {
        [DataMember(Name = "contactSummaries", EmitDefaultValue = false)]
        public List<WSContactSummary> ContactSummaries { get; set; }

        public static WSContactSummaryResponse FromEntityModel(ContactSummaryResponse response)
        {
            WSContactSummaryResponse result = null;

            if (response != null)
            {
                result = new WSContactSummaryResponse()
                {
                    ContactSummaries = WSContactSummary.FromEntityModels(response.ContactSummaries)
                };
            }

            return result;
        }
    }
}
