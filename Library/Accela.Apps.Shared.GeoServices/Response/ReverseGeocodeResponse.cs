using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Response
{
    [DataContract(Name = "reverseGeocodeResponse")]
    public class ReverseGeocodeResponse
    {
        [DataMember(Name="address")]
        public ReverseGeocodeAddress Address { get; set; }

        [DataMember(Name = "error")]
        public ESRIError Error { get; set; }
    }
}
