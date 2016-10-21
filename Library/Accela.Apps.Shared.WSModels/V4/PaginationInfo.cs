using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.WSModels
{
    [Serializable]
    [DataContract(Name = "page")]
    public class PaginationInfo
    {
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset { get; set; }

        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; set; }

        [DataMember(Name = "hasMore", EmitDefaultValue = false)]
        public bool HasMore { get; set; }
    }
}
