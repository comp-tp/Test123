using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract(Name = "authenticateCivicResponse")]
    public class AuthenticateCivicResponse : ResponseBase
    {
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }
    }
}
