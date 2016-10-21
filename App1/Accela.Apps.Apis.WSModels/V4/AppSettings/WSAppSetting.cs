using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4.AppSettings
{
    [DataContract]
    public class WSAppSettingV4
    {
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }
    }
}
