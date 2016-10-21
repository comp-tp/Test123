using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Request.Record
{
    [DataContract(Name = "citizenSearchRecordsByAddressRequest")]
    public class CitizenSearchRecordsByAddressRequest : RequestBase
    {
        [DataMember]
        public string houseNumberStart { get; set; }

        [DataMember]
        public string streetName { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember]
        public string zip { get; set; }
    }
}