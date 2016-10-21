using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Diagnostics
{
    [DataContract(Name = "logDetailResponse")]
    public class WSLogDetailResponse : WSResponseBase
    {
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public string Detail { get; set; }
    }
}
