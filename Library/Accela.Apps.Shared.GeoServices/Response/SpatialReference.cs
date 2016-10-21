using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Response
{
    [DataContract(Name = "spatialReference")]
    public class SpatialReference
    {
        [DataMember(Name = "wkid")]
        public int Wkid { get; set; }

        [DataMember(Name = "latestWkid")]
        public int LatestWkid { get; set; }
    }
}
