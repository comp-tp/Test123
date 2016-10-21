using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ConditionModels
{
    [DataContract]
    public class ConditionStatusModel : IdentifierBase
    {
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
    }
}
