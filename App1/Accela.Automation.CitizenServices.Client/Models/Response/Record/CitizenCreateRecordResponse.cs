using System.Runtime.Serialization;
using Accela.ACA.WSProxy;

namespace Accela.Automation.CitizenServices.Client.Models.Response.Record
{
    [DataContract]
    public class CitizenCreateRecordResponse : ResponseBase
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public CapModel4WS result { get; set; }
    }
}