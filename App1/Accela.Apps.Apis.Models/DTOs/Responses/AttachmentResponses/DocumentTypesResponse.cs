using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses
{
    [DataContract(Name = "GetDocumentInfoResponse")]
    public class DocumentTypesResponse : PagedResponse
    {
        ///<summary>
        /// Attactment Info
        /// </summary>
        [DataMember(Name = "docummentGroupModels", EmitDefaultValue = false)]
        public List<DocumentGroupModel> DocumentGroup { get; set; }
    }
}

