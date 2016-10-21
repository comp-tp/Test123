using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.LocationModels;

namespace Accela.Apps.Apis.WSModels.Location
{
    [DataContract(Name = "location")]
    public class WSLocation
    {
        [DataMember(Name = "gisObject", EmitDefaultValue = false)]
        public WSGISObject GisObject { get; set; }

        [DataMember(Name = "geometryPoint", EmitDefaultValue = false)]
        public WSGeometryPoint MapPoint { get; set; }

        public static WSLocation FromEntityModel(LocationModel location)
        {
            if (location != null)
            {
                return new WSLocation()
                {
                    GisObject = WSGISObject.FromEntityModel(location.GisObject),
                    MapPoint = WSGeometryPoint.FromEntityModel(location.GeometryPoint),
                };
            }

            return null;
        }
    }
}
