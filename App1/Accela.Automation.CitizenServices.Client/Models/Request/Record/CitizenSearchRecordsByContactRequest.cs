using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Request.Record
{
    [DataContract(Name = "citizenSearchRecordsByContactRequest")]
    public class CitizenSearchRecordsByContactRequest : RequestBase
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string middleName { get; set; }

        [DataMember]
        public string lastName { get; set; }
    }
}