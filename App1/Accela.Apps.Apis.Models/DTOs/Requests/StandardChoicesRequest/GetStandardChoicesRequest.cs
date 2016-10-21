﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests
{
    public class GetStandardChoicesRequest : RequestBase
    {
        public string StandardChoiceType { get; set; }

        public string StandardChoiceValue { get; set; }
    }
}
