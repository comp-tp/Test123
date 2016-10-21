using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Agency
{
    [DataContract]
    public class WSGeoSearchAgenciesRequest : WSRequestBase
    {
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }
    }
}
