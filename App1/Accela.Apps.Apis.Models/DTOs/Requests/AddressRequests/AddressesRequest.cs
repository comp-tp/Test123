using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests
{
    public class AddressesRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the identifier for the record to which the list of address belongs.
        /// </summary>
        public string RecordId { get; set; }

        [DataMember(Name = "elements")]
        public List<string> Elements { get; set; }

        [DataMember(Name = "criteria")]
        public AddressCriteria Criteria { get; set; }
    }
}
