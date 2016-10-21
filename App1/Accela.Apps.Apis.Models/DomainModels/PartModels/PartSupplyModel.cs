using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.PartModels
{
    [DataContract]
    public class PartSupplyModel : DataModel
    {
        /// <summary>
        /// Gets or sets the supply identifier.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the supply display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the supply locationName.
        /// </summary>
        [DataMember(Name = "locationName", EmitDefaultValue = false)]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the supply locationSeq.
        /// </summary>
        [DataMember(Name = "locationSeq", EmitDefaultValue = false)]
        public int LocationSeq { get; set; }
    }
}
