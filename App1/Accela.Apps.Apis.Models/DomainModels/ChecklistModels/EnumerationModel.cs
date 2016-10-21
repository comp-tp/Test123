using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.ChecklistModels
{
    /// <summary>
    /// Enumeration model
    /// </summary>
    [DataContract]
    public class EnumerationModel
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

        ///// <summary>
        ///// Gets or sets the type.
        ///// </summary>
        ///// <value>
        ///// The type.
        ///// </value>
        //[DataMember(Name = "type")]
        //public string Type
        //{
        //    get;
        //    set;
        //}
    }
}
