using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.WSModels.Common
{

    [DataContract]
    public class WSBatchChildRequest : Accela.Apps.Shared.WSModels.WSRequestBase
    {
        [DataMember(Name = "relativeUrl", EmitDefaultValue = false)]
        public string RelativeUrl { get; set; }
        [DataMember(Name = "method", EmitDefaultValue = false)]
        public string method { get; set; }
        [DataMember(Name = "headers", EmitDefaultValue = false)]
        public Dictionary<string,string> hearders { get; set; }
        [DataMember(Name = "body", EmitDefaultValue = false)]
        public object body { get; set; }
    }
}
