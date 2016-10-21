using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppContactSummaryResponse
    {
        [DataMember(Name = "contactSummaries", EmitDefaultValue = false)]
        public List<WSInspectorAppContactSummary> ContactSummaries { get; set; }

        public static WSInspectorAppContactSummaryResponse FromEntityModel(ContactSummaryResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var result = new WSInspectorAppContactSummaryResponse();
            if (response.ContactSummaries != null)
            {
                result.ContactSummaries = new List<WSInspectorAppContactSummary>();
                response.ContactSummaries.ForEach(item =>
                {
                    result.ContactSummaries.Add(WSInspectorAppContactSummary.FromEntityModel(item));
                });
            }
            
            return result;
        }
    }
}
