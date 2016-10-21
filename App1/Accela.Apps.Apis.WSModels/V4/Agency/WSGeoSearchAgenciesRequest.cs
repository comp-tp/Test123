using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Agency.V4
{
    [DataContract]
    public class WSGeoSearchAgenciesV4Request : WSRequestBase
    {
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }
    }
}
