using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Accela.Apps.Apis.WSModels.AppSettings
{
    [DataContract]
    public class WSAppSetting
    {
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }
    }
}
