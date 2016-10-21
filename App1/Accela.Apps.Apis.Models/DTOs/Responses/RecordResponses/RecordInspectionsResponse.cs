using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "getRecordInspectionsResponse")]
    public class RecordInspectionsResponse : PagedResponse
    {
        /// <summary>
        /// The record inspection information.
        /// </summary>
        [DataMember(Name = "inspections", EmitDefaultValue = false)]
        public List<InspectionModel> Inspections { get; set; }
    }
}
