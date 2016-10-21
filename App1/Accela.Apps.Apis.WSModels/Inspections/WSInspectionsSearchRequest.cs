using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspectionSearchRequest")]
    public class WSInspectionsSearchRequest : WSRequestBase
    {
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public WSInspectionFilter Filter { get; set; }

    }
}
