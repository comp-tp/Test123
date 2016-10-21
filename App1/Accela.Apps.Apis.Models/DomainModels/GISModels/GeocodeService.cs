using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.GISModels
{
    [Serializable]
    public class GeocodeService
    {
        public string GeocodeServiceUrl { get; set; }

        public GisSecuritySettings SecuritySettings { get; set; }
    }
}
