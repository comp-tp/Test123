using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests
{
    [DataContract]
    public class AssetsSearchRequest : PageListRequest
    {
        [DataMember(Name = "elements")]
        public List<string> Elements { get; set; }

        [DataMember(Name = "criteria")]
        public AssetSearchCriteria Criteria { get; set; }

        public bool IgnoreCoordinatesSearch { get; set; }
    }
}
