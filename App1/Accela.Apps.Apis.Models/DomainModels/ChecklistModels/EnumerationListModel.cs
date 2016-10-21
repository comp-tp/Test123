using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.ChecklistModels
{
    /// <summary>
    /// Enumeration list model
    /// </summary>
    public class EnumerationListModel
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
        /// Gets or sets the enumerations.
        /// </summary>
        /// <value>
        /// The enumerations.
        /// </value>
        [DataMember(Name = "enumerations", EmitDefaultValue = false)]
        public EnumerationModel[] Enumerations
        {
            get;
            set;
        }
    }
}
