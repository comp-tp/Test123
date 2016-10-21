using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests
{
    [DataContract]
    public class GeoSearchAgenciesByAddressRequest : RequestBase
    {
        [DataMember(Name = "address")]
        public string Address { get; set; }
    }
}
