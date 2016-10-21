using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract]
    public class RefreshDataResponse: ResponseBase 
    {
        [DataMember(Name = "returnKey", EmitDefaultValue = false)]
        public string ReturnKey { get; set; }
    }
}
