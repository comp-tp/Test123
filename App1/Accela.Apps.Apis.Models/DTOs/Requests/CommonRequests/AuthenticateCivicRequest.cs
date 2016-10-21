using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests
{
    [DataContract]
    public class AuthenticateCivicRequest : RequestBase
    {       
        [DataMember(Name = "loginName", EmitDefaultValue = false)]
        public string LoginName { get; set; }

        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        [DataMember(Name = "appId", EmitDefaultValue = false)]
        public string AppId { get; set; }
    }
}
