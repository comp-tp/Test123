﻿using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests
{
    /// <summary>
    /// Asset request class.
    /// </summary>
    [DataContract(Name = "getAssetRequest")]
    public class AssetRequest : RequestBase
    {
        [DataMember(Name = "elements")]
        public List<string> Elements { get; set; }

        [DataMember(Name = "criteria")]
        public AssetCriteria Criteria { get; set; }

        public bool IgnoreCoordinatesSearch { get; set; }
    }
}
