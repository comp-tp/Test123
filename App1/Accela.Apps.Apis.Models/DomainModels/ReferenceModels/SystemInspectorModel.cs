using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract]
    public class SystemInspectorModel : DataModel
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
        /// Gets or sets the givenName
        /// </summary>
        /// <value>
        /// The givenName
        /// </value>
        [DataMember(Name = "givenName", EmitDefaultValue = false)]
        public string GivenName { get; set; }


        /// <summary>
        /// Gets or sets the familyName
        /// </summary>
        /// <value>
        /// The givenName
        /// </value>
        [DataMember(Name = "familyName", EmitDefaultValue = false)]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the active
        /// </summary>
        [DataMember(Name = "active", EmitDefaultValue = false)]
        public bool Active { get; set; }


    }
}
