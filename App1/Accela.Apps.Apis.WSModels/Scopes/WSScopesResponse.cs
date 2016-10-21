using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Scopes
{
    [Serializable]
    [DataContract(Name = "scopesResponse")]
    public class WSScopesResponse
    {
        [DataMember(Name = "scopes", EmitDefaultValue = false)]
        public List<WSScope> Scopes { get; set; }
    }
}
