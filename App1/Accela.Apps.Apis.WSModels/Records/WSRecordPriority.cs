﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordPriority
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }
    }
}