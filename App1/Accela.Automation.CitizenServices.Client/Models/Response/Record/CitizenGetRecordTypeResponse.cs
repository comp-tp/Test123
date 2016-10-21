using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.ACA.WSProxy;

namespace Accela.Automation.CitizenServices.Client.Models.Response.Record
{
    [DataContract]
    public class CitizenGetRecordTypeResponse : ResponseBase
    {
        [DataMember(Name = "result")]
        public List<CapTypeModel> result { get; set; }
    }
}