using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.LocationModels
{
    [DataContract]
    public class LocationBaseModel
    {
        /// Gets or sets identifier
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MapService
        /// </summary>
        [DataMember(Name = "mapService", EmitDefaultValue = false)]
        public string MapService
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Agency
        /// </summary>
        [DataMember(Name = "agency", EmitDefaultValue = false)]
        public string Agency
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Agency
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name
        {
            get;
            set;
        }
    }
}
