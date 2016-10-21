using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.LocationModels;

namespace Accela.Apps.Apis.WSModels.Location
{
    [DataContract(Name = "geometryPoint")]
    public class WSGeometryPoint
    {
        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "X", EmitDefaultValue = false)]
        public string X { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "Y", EmitDefaultValue = false)]
        public string Y { get; set; }

        public static WSGeometryPoint FromEntityModel(GeometryPointModel geoPoint)
        {
            if (geoPoint != null)
            {
                return new WSGeometryPoint()
                {
                    Id = geoPoint.Id,
                    X = geoPoint.X,
                    Y = geoPoint.Y
                };
            }

            return null;
        }
    }
}
