using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Geo
{
    [DataContract]
    public class WSGeoLocationListItem : WSResponseBase
    {
        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "location")]
        public WSGeoLocation Location { get; set; }
    }
}
