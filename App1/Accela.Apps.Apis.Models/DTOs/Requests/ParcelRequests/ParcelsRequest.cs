﻿using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests
{
    [DataContract]
    public class ParcelsRequest : PageListRequest
    {
        [DataMember(Name = "elements")]
        public List<string> Elements { get; set; }

        [DataMember(Name = "criteria")]
        public ParcelCriteria Criteria { get; set; }

        public bool IgnoreCoordinatesSearch { get; set; }
    }
}