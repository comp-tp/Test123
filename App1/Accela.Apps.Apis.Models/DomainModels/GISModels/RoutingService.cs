﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.GISModels
{
    [Serializable]
    public class RoutingService
    {
        public string RoutingServiceUrl { get; set; }

        public GisSecuritySettings SecuritySettings { get; set; }
    }
}