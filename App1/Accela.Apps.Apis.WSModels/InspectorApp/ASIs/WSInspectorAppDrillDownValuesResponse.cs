using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "getDrillDownValuesResponse")]
    public class WSInspectorAppDrillDownValuesResponse : WSResponseBase
    {
        [DataMember(Name = "drillDown", EmitDefaultValue = false)]
        public WSInspectorAppDrillDown DrillDown { get; set; }

        public static WSInspectorAppDrillDownValuesResponse FromEntityModel(DrillDownValuesResponse entityResponse)
        {
            return new WSInspectorAppDrillDownValuesResponse
            {
                DrillDown = WSInspectorAppDrillDown.FromEntityModel(entityResponse)
            };
        }
    }
}
