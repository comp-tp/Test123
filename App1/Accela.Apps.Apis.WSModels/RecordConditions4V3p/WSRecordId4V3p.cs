using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.RecordConditions4V3p
{
    [DataContract(Name = "recordId")]
    public class WSRecordId4V3p : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "customId", EmitDefaultValue = false)]
        public string CustomId { get; set; }

        [DataMember(Name = "trackingId", EmitDefaultValue = false)]
        public string TrackingId { get; set; }

        [DataMember(Name = "serviceProviderCode", EmitDefaultValue = false)]
        public string ServiceProviderCode { get; set; }
    }
}
