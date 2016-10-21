using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    /// <summary>
    /// Additional value model
    /// </summary>
    [DataContract(Name = "additionalValue")]
    public class AdditionalValueModel : ActionDataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        [DataMember(Name = "valueId", EmitDefaultValue = false)]
        public string ValueId { get; set; }


        #region for old API, they only afford entityState

        [DataMember(Name = "entityState", EmitDefaultValue = false)]
        public string EntityState { get; set; }

        #endregion
    }
}
