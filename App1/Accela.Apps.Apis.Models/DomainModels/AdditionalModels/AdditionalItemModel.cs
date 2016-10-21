using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    [DataContract(Name = "additionalItem")]
    public class AdditionalItemModel : AdditionalColumnModel
    {
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        [DataMember(Name = "valueId", EmitDefaultValue = false)]
        public string ValueId { get; set; }
    }

    public class AdditionalItemComparer : IEqualityComparer<AdditionalItemModel>
    {
        public bool Equals(AdditionalItemModel x, AdditionalItemModel y)
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

        public int GetHashCode(AdditionalItemModel group)
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
