using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using System;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests
{
    public class ResourcesFilter : RequestBase
    {

        public Guid ResourceId { get; set;}

        public string Api { get; set;}

        public string HttpMethod { get; set; }

        public string Ids { get; set; }


    }
}
