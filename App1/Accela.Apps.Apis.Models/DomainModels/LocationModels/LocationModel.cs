using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.GISModels;

namespace Accela.Apps.Apis.Models.DomainModels.LocationModels
{
    [DataContract]
    public class LocationModel
    {
        [DataMember(Name = "gisObject", EmitDefaultValue = false)]
        public GISObjectModel GisObject { get; set; }

        [DataMember(Name = "geometryPoint", EmitDefaultValue = false)]
        public GeometryPointModel GeometryPoint { get; set; }
    }
}
