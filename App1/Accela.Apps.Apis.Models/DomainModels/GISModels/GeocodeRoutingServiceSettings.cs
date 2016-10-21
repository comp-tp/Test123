using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System;

namespace Accela.Apps.Apis.Models.DomainModels.GISModels
{
    [Serializable]
    public class GeocodeRoutingServiceSettings
    {
        public GeocodeService GeocodeService { get; set; }

        public RoutingService RoutingService { get; set; }
    }
}
