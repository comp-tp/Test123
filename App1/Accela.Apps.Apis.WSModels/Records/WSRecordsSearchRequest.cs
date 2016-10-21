using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "recordSearchRequest")]
    public class WSRecordsSearchRequest : WSRequestBase
    {
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public WSRecordFilter RecordFilter { get; set; }
    }
}
