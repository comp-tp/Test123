using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract]
    public class ModuleModel
    {
        public ModuleModel()
        {
        }

        [DataMember(Name = "Key", EmitDefaultValue = false)]
        public string Key;

        [DataMember(Name = "Value", EmitDefaultValue = false)]
        public string Value;
    }
}
