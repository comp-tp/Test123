using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppInspectionSummaryResponse:WSResponseBase
    {
        [DataMember(Name = "inspectionSummary", EmitDefaultValue = false)]
        public WSInspectorAppInspectionSummary InspectionSummary { get; set; }

        public static WSInspectorAppInspectionSummaryResponse FromEntityModel(InspectionSummaryResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var result = new WSInspectorAppInspectionSummaryResponse()
            {
                InspectionSummary = WSInspectorAppInspectionSummary.FromEntityModel(response.InspectionSummary)
            };

            return result;
        }
    }
}
