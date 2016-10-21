using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;

namespace Accela.Apps.Apis.WSModels.StandardChoices
{
    [DataContract(Name = "getWSWorkOrderTaskUnitResponse")]
    public class WSGetWorkOrderTaskUnitResponse : WSResponseBase
    {
        [DataMember(Name = "durationUnits", EmitDefaultValue = false)]
        public List<WSWorkOrderTaskUnit> DurationUnits { get; set; }

        public static WSGetWorkOrderTaskUnitResponse FromEntityModel(StandardChoicesResponse response)
        {
            return new WSGetWorkOrderTaskUnitResponse()
            {
                DurationUnits = response.StandardChoicesModels == null ? null : WSWorkOrderTaskUnit.FromEntityModels(response.StandardChoicesModels.ToArray()).ToList()
            };
        }
    }
}
