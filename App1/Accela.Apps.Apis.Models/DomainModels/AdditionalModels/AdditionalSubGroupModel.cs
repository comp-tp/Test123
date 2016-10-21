using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    /// <summary>
    /// it is for additional
    /// </summary>
    [DataContract(Name = "additionalSubGroup")]
    public class AdditionalSubGroupModel : ActionDataModel
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

        [DataMember(Name = "isStructural", EmitDefaultValue = false)]
        public bool IsStructural { get; set; }

        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<AdditionalItemModel> Items { get; set; }

        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security { get; set; }

        [DataMember(Name = "drillDownSeries", EmitDefaultValue = false)]
        public List<AdditionalDrillDownSeriesModel> DrillDownSeries { get; set; }

        [DataMember(Name = "alias", EmitDefaultValue = false)]
        public string Alias { get; set; }
    }

    public class AdditionalSubGroupComparer : IEqualityComparer<AdditionalSubGroupModel>
    {
        public bool Equals(AdditionalSubGroupModel x, AdditionalSubGroupModel y)
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

        public int GetHashCode(AdditionalSubGroupModel group)
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
