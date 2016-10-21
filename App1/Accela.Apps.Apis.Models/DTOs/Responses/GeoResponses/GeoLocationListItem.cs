using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses
{
    [DataContract]
    public class GeoLocationListItem
    {
        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "location")]
        public GeoLocation Location { get; set; }
    }
}
