using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ChecklistModels
{
    [DataContract]
    public class ChecklistGroupModel
    {
        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }

        [DataMember(Name = "display")]
        public string Display { get; set; }
    }
	
    public class ChecklistGroupComparer : IEqualityComparer<ChecklistGroupModel>
    {
        public bool Equals(ChecklistGroupModel x, ChecklistGroupModel y)
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

        public int GetHashCode(ChecklistGroupModel group)
        {
            if (Object.ReferenceEquals(group, null))
            {
                return 0;
            }

            int hashGroupId = group.Identifier == null ? 0 : group.Identifier.GetHashCode();

            return hashGroupId;
        }
    }
}
