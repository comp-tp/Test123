using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.ServerPropertyModels
{
    [DataContract(Name = "serverPropertyV4Model")]
    public class ServerPropertyV4Model
    {
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string Version { get; set; }
    }
}
