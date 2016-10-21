using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    [DataContract(Name = "additionalGroup")]
    public class AdditionalGroupModel
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
        /// description
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description
        {
            get;
            set;
        }

        [DataMember(Name = "subGroups", EmitDefaultValue = false)]
        public List<AdditionalSubGroupModel> SubGroups { get; set; }


        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security
        {
            get;
            set;
        }
 
    }

    public class AdditionalGroupComparer : IEqualityComparer<AdditionalGroupModel>
    {
        public bool Equals(AdditionalGroupModel x, AdditionalGroupModel y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (Object.ReferenceEquals(x, null)
                || Object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Identifier == y.Identifier;
        }

        public int GetHashCode(AdditionalGroupModel group)
        {
            if (Object.ReferenceEquals(group, null))
            {
                return 0;
            }

            int hashSettingValueId = group.Identifier == null ? 0 : group.Identifier.GetHashCode();

            return hashSettingValueId;
        }
    }
}
