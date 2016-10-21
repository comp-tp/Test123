using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V1.Inspectors
{
    [DataContract(Name = "InspectorResponse")]
    public class WSInspectorResponse : WSResponseBase
    {
        [DataMember(Name = "inspector", EmitDefaultValue = false)]
        public WSInspectorWithDepartment Inspector { get; set; }
    }
}
