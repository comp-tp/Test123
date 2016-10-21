using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract(Name = "GetSettingResponse")]
    public class AppSettingResponse : ResponseBase
    {
        [DataMember(Name = "settingValue", EmitDefaultValue = false)]
        public string SettingValue { get; set; }
    }
}
