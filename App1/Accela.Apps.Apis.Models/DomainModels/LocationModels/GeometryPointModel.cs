using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.LocationModels
{
    [DataContract]
    public class GeometryPointModel
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

    }
}
