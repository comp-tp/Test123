using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses;
using Accela.Apps.Apis.WSModels.V4;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels
{
    [DataContract]
    public class WSListResponse<T> : WSPagedResponse
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<T> Data { get; set; }
    }
}
