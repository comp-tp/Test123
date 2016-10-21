using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models
{
    [DataContract]
    public class DocumentModel
    {
        [DataMember]
        public string serviceProviderCode { get; set; }

        [DataMember]
        public string moduleName { get; set; }

        [DataMember]
        public string fileName { get; set; }

        [DataMember]
        public string entityID { get; set; }

        [DataMember]
        public string entityType { get; set; }

        [DataMember]
        public DocumentContentModel documentContentModel { get; set; }

        [DataMember]
        public CapID capID { get; set; }
    }
}