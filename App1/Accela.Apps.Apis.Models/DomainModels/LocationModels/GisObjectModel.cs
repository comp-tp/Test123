using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.LocationModels
{
    [DataContract]
    public class GisObjectModel
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets layerId
        /// </summary>
        [DataMember(Name = "layerId", EmitDefaultValue = false)]
        public string LayerId
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets mapService
        /// </summary>
        [DataMember(Name = "mapService", EmitDefaultValue = false)]
        public string MapService
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        [DataMember(Name = "featureId", EmitDefaultValue = false)]
        public string FeatureId
        {
            get;
            set;
        }
    }
}
