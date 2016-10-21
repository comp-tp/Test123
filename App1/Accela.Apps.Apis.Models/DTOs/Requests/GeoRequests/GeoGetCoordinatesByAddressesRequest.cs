using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests
{
    [DataContract]
    public class GeoGetCoordinatesByAddressesRequest : RequestBase
    {
        [DataMember(Name = "addresses")]
        public string[] Addresses { get; set; }

        [DataMember(Name = "outSR")]
        public string OutSR { get; set; }

        [DataMember(Name = "cacheEnabled")]
        public bool CacheEnabled { get; set; }
    }
}
