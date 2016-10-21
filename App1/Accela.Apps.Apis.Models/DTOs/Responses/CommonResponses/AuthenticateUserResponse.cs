using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract(Name = "AuthenticateUserResponse")]
    public class AuthenticateUserResponse : ResponseBase
    {
        [DataMember(Name = "authorization", EmitDefaultValue = false)]
        public string Authorization { get; set; }
        [DataMember(Name = "environmentName", EmitDefaultValue = false)]
        public string EnvironmentName { get; set; } 
    }
}
