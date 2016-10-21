using Accela.Apps.Apis.Models.DomainModels.LocationModels;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract(Name = "geometryPoint")]
    public class WSGeometryPointV4
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

        public static WSGeometryPointV4 FromEntityModel(GeometryPointModel geoPoint)
        {
            if (geoPoint != null)
            {
                return new WSGeometryPointV4()
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
