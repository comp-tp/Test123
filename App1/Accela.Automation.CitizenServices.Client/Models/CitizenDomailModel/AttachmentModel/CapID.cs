using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models
{
    [DataContract(Name = "capID")]
    public class CapID
    {
        [DataMember]
        public string serviceProviderCode { get; set; }

        [DataMember]
        public string id1 { get; set; }

        [DataMember]
        public string id2 { get; set; }

        [DataMember]
        public string id3 { get; set; }
    }
}