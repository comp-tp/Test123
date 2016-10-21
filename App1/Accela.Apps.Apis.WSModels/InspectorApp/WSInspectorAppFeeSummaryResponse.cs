using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppFeeSummaryResponse:WSResponseBase
    {
        [DataMember(Name = "feeSummary", EmitDefaultValue = false)]
        public WSInspectorAppFeeSummary FeeSummary { get; set; }

        public static WSInspectorAppFeeSummaryResponse FromEntityModel(FeeSummaryResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var result = new WSInspectorAppFeeSummaryResponse()
            {
                FeeSummary = WSInspectorAppFeeSummary.FromEntityModel(response.FeeSummary)
            };

            return result;
        }
    }
}
