using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.ACA.WSProxy;

namespace Accela.Automation.CitizenServices.Client.Models.Response.Record
{
    [DataContract]
    public class CitizenRecordContactsResponse : PagedResponse
    {
        [DataMember(Name = "result")]
        public List<CapContactModel> result { get; set; }
    }
}