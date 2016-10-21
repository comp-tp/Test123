﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests
{
    public class RecordTypesRequest : PageListRequest
    {
        public string Module { get; set; }

        public string RecordTypeId { get; set; }
    }
}