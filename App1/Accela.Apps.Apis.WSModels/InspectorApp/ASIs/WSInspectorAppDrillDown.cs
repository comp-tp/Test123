using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "drillDown")]
    public class WSInspectorAppDrillDown
    {
        [DataMember(Name = "childIds", EmitDefaultValue = false, Order = 0)]
        public List<string> ChildIds { get; set; }

        [DataMember(Name = "values", EmitDefaultValue = false, Order = 1)]
        public List<WSInspectorAppDrillDownNode> Values { get; set; }

        public static WSInspectorAppDrillDown FromEntityModel(DrillDownValuesResponse entityResponse)
        {
            WSInspectorAppDrillDown result = new WSInspectorAppDrillDown();

            if (entityResponse.ChildIds != null)
            {
                result.ChildIds = new List<string>();
                result.ChildIds.AddRange(entityResponse.ChildIds);
            }

            if (entityResponse.Values != null)
            {
                result.Values = new List<WSInspectorAppDrillDownNode>();
                foreach (var value in entityResponse.Values)
                {
                    result.Values.Add(new WSInspectorAppDrillDownNode
                    {
                        Identifier = value.Identifier,
                        Display = value.Display
                    });
                }
            }

            return result;
        }
    }

    [DataContract(Name = "drillDownNode")]
    public class WSInspectorAppDrillDownNode
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }
    }
}
