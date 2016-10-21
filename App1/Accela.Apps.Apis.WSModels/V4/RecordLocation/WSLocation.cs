using Accela.Apps.Apis.Models.DomainModels.LocationModels;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract(Name = "location")]
    public class WSLocationV4
    {
        [DataMember(Name = "gisObject", EmitDefaultValue = false)]
        public WSGISObjectV4 GisObject { get; set; }

        [DataMember(Name = "geometryPoint", EmitDefaultValue = false)]
        public WSGeometryPointV4 MapPoint { get; set; }

        public static WSLocationV4 FromEntityModel(LocationModel location)
        {
            if (location != null)
            {
                return new WSLocationV4()
                {
                    GisObject = WSGISObjectV4.FromEntityModel(location.GisObject),
                    MapPoint = WSGeometryPointV4.FromEntityModel(location.GeometryPoint),
                };
            }

            return null;
        }
    }

    [DataContract(Name = "location")]
    public class WSRecordLocationV4
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "gisObject", EmitDefaultValue = false)]
        public WSGISObjectV4 GisObject { get; set; }

        [DataMember(Name = "geometryPoint", EmitDefaultValue = false)]
        public WSGeometryPointV4 MapPoint { get; set; }

        public static WSRecordLocationV4 FromEntityModel(RecordLocationModel location)
        {
            if (location != null)
            {
                var result = new WSRecordLocationV4()
                {
                    Id = location.Id
                };

                if (location.Location == null) return result;

                result.GisObject = WSGISObjectV4.FromEntityModel(location.Location.GisObject);
                result.MapPoint = WSGeometryPointV4.FromEntityModel(location.Location.GeometryPoint);

                return result;
            }

            return null;
        }
    }
}
