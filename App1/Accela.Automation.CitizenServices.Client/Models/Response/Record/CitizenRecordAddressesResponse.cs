using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Accela.ACA.WSProxy;

namespace Accela.Automation.CitizenServices.Client.Models.Response.Record
{
    [DataContract]
    public class CitizenRecordAddressesResponse : PagedResponse
    {
        [DataMember(Name = "result")]
        public List<AddressModel> result { get; set; }
    }
}