using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.OAuth2
{
    [DataContract(Name="accessToken")]
    public class WSAccessTokenInfo : WSResponseBase
    {
        [DataMember(Name = "appId", EmitDefaultValue = false)]
        public string AppId { get; set; }

        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "agencyName", EmitDefaultValue = false)]
        public string AgencyName { get; set; }

        [DataMember(Name = "environment", EmitDefaultValue = false)]
        public string Environment { get; set; }

        [DataMember(Name = "scopes")]
        public List<string> Scopes { get; set; }

        [DataMember(Name = "expiresIn", EmitDefaultValue = false)]
        public ulong ExpiresIn { get; set; }

        [DataMember(Name = "error", EmitDefaultValue = false)]
        public string Error { get; set; }

        [DataMember(Name = "errorDescription", EmitDefaultValue = false)]
        public string ErrorDescription { get; set; }
    }
}
