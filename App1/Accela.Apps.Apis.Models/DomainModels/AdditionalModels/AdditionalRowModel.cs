using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    /// <summary>
    /// Additional row model
    /// </summary>
    [DataContract(Name = "additionalRow")]
    public class AdditionalRowModel : ActionDataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember(Name = "values", EmitDefaultValue = false)]
        public List<AdditionalValueModel> Values
        {
            get;
            set;
        }

        #region for old API, they only afford entityState

        [DataMember(Name = "entityState", EmitDefaultValue = false)]
        public string EntityState { get; set; }

        #endregion
    }
}
