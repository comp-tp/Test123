using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Assessments;

namespace Accela.Apps.Apis.WSModels.Models.Assessments
{
    [DataContract(Name = "assessmentSearchRequest")]
    public class WSAssessmenSearchtRequest : WSRequestBase
    {
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public WSAssessmentFilter Filter { get; set; }
    }
}
