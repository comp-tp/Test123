using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "GetAdditionalTableInfoResponse")]
    public class AdditionalTableResponse : PagedResponse
    {
        /// <summary>
        /// Additional Info
        /// </summary>
        [DataMember(Name = "additionalTables", EmitDefaultValue = false)]
        public List<AdditionalTableModel> AdditionalTables { get; set; }
    }
}
