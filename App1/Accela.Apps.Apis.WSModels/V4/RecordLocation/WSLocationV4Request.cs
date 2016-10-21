using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4.RecordLocation
{
    [DataContract(Name = "locationRequest")]
    public class WSLocationV4Request
    {
        [DataMember(Name = "ids", EmitDefaultValue = false)]
        public List<string> Ids
        {
            get;
            set;
        }
    }
}
