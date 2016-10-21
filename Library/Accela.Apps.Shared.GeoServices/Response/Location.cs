using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Response
{
    [DataContract(Name="location")]
    public class Location
    {
        [DataMember(Name="x")]
        public double X { get; set; }

        [DataMember(Name="y")]
        public double Y { get; set; }
    }
}
