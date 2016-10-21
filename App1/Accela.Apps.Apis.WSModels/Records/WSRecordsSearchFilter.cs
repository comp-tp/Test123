using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name="recordsSearchFilter")]
    public class WSRecordsSearchFilter
    {
        [DataMember(Name = "recordIds", EmitDefaultValue = false)]
        public string RecordIds{get;set;}

        [DataMember(Name = "recordTypeIds", EmitDefaultValue = false)]
        public string RecordTypeIds{get;set;}

        [DataMember(Name = "recordStatusIds", EmitDefaultValue = false)]
        public string RecordStatusIds { get; set; }

        [DataMember(Name = "pacelIds", EmitDefaultValue = false)]
        public string PacelIds { get; set; }

        [DataMember(Name = "address", EmitDefaultValue = false)]
        public WSRecordsSearchFilterAddressCondition Address { get; set; }

        [DataMember(Name = "contact", EmitDefaultValue = false)]
        public WSRecordsSearchFilterContactCondition Contact { get; set; }

        [DataMember(Name = "openDateFrom", EmitDefaultValue = false)]
        public string OpenDateFrom { get; set; }

        [DataMember(Name = "openDateTo", EmitDefaultValue = false)]
        public string OpenDateTo { get; set; }
    }

    [DataContract(Name="address")]
    public class WSRecordsSearchFilterAddressCondition
    {
        [DataMember(Name = "street", EmitDefaultValue = false)]
        public string Street { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "zipCode", EmitDefaultValue = false)]
        public string ZipCode { get; set; }
        
    }

    [DataContract(Name = "contact")]
    public class WSRecordsSearchFilterContactCondition
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "number", EmitDefaultValue = false)]
        public string Number { get; set; }
    }
}
