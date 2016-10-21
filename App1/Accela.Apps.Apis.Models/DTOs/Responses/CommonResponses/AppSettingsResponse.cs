﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract]
    public class AppSettingsResponse : ResponseBase
    {
        [DataMember(Name = "settingValues", EmitDefaultValue = false)]
        public Dictionary<string,string> SettingValues { get; set; }
    }
}
