using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    [DataContract(Name = "getDrillDownValuesResponse")]
    public class WSDrillDownValuesResponse : WSResponseBase
    {
        [DataMember(Name = "drillDown", EmitDefaultValue = false)]
        public WSDrillDown DrillDown { get; set; }

        public static WSDrillDownValuesResponse FromEntityModel(DrillDownValuesResponse entityResponse)
        {
            return new WSDrillDownValuesResponse
            {
                DrillDown = WSDrillDown.FromEntityModel(entityResponse)
            };
        }
    }
}
