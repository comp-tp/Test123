using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.CostModels
{
    [DataContract(Name = "itemType")]
    public class CostItemTypeModel
    {
        /// <summary>
        /// Gets or sets the type id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the type display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }
    }
}
