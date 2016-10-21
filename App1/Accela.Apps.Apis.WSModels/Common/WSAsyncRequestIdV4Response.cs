using Accela.Apps.Shared.WSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Common
{
    [DataContract]
    public class AsyncRequestIdV4
    {
        [DataMember(Name = "requestId")]
        public string RequestId { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }
    }
}
