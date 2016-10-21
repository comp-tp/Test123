using System.Runtime.Serialization;
using System;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordGeoFilter
    {
        [DataMember(Name = "civicId", EmitDefaultValue = false)]
        public Guid CivicId { get; set; }

        [DataMember(Name = "bBox", EmitDefaultValue = false)]
        public WSBBox BBoxValue { get; set; }

        [DataMember(Name = "geoCircle", EmitDefaultValue = false)]
        public WSGeoCircle GeoCircle { get; set; }
    }
}
