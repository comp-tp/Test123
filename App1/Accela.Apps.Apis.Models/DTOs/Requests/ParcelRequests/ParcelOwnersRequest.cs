﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests
{
    public class ParcelOwnersRequest : PageListRequest
    {
        public string ParcelId { get; set; }
    }
}