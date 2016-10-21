using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    [DataContract(Name = "drillDown")]
    public class WSDrillDown
    {
        [DataMember(Name = "childIds", EmitDefaultValue = false, Order = 0)]
        public List<string> ChildIds { get; set; }

        [DataMember(Name = "values", EmitDefaultValue = false, Order = 1)]
        public List<WSDrillDownNode> Values { get; set; }

        public static WSDrillDown FromEntityModel(DrillDownValuesResponse entityResponse)
        {
            WSDrillDown result = new WSDrillDown();

            if (entityResponse.ChildIds != null)
            {
                result.ChildIds = new List<string>();
                result.ChildIds.AddRange(entityResponse.ChildIds);
            }

            if (entityResponse.Values != null)
            {
                result.Values = new List<WSDrillDownNode>();
                foreach (var value in entityResponse.Values)
                {
                    result.Values.Add(new WSDrillDownNode
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
    public class WSDrillDownNode
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }
    }
}
