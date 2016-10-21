using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSGeoCircle
    {
        [DataMember(Name = "centerX", EmitDefaultValue = false)]
        public string CenterX { get; set; }

        [DataMember(Name = "centerY", EmitDefaultValue = false)]
        public string CenterY { get; set; }

        [DataMember(Name = "radius", EmitDefaultValue = false)]
        public string Radius { get; set; }
    }
}
