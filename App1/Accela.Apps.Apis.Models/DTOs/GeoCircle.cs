using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class GeoCircle
    {
        [DataMember(Name = "centerX", EmitDefaultValue = false)]
        public string CenterX { get; set; }

        [DataMember(Name = "centerY", EmitDefaultValue = false)]
        public string CenterY { get; set; }

        [DataMember(Name = "radius", EmitDefaultValue = false)]
        public string Radius { get; set; }
    }
}
