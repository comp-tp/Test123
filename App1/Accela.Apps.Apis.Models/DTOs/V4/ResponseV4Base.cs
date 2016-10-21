using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels;

namespace Accela.Apps.Apis.Models.DTOs.V4
{
    /// <summary>
    /// Response base
    /// </summary>
    [DataContract(Name = "response")]
    public class ResponseV4Base
    {
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int Status { get; set; }
    }
}
