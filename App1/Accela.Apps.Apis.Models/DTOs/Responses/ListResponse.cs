using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DTOs.Responses
{
    [DataContract(Name = "ListResponse")]
    public class ListResponse<T> : PagedResponse
    {
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public List<T> Data { get; set; }
    }
}
