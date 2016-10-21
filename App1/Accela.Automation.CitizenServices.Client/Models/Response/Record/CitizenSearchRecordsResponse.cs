using System.Runtime.Serialization;
using Accela.ACA.WSProxy;

namespace Accela.Automation.CitizenServices.Client.Models.Response.Record
{
    [DataContract(Name = "citizenSearchRecordsResponse")]
    public class CitizenSearchRecordsResponse : PagedResponse
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public SimpleCapModel[] result { get; set; }
    }
}