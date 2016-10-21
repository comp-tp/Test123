using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Geo
{
    [DataContract(Name = "geoSingleLineItem")]
    public class WSGeoSingleLineItem
    {
        [DataMember(Name = "attributes")]
        public WSGeoSingleLine Attributes { get; set; }
    }
}
