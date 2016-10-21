using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.LocationModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    public class RecordLocationResponse : ResponseBase
    {
        [DataMember(Name = "location", EmitDefaultValue = false)]
        public LocationModel Location { get; set; }
    }
}
