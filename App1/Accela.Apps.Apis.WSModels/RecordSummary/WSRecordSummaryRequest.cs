using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "recordSummaryRequest")]
    public class WSRecordSummaryRequest : WSRequestBase
    {
        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }
    }
}
