using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.InspectionModels
{
    [DataContract]
    public class InspectionGroupModel
    {
        /// <summary>
        /// Gets or sets the inspection group Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the inspection group display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }


        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<SystemInspectionTypeModel> Types { get; set; }

        
    }
}
