using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.SummaryModels
{
    [DataContract]
    public class ProjectInformationModel : DataModel
    {
        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }

        [DataMember(Name = "recordType", EmitDefaultValue = false)]
        public string RecordType { get; set; }

        [DataMember(Name = "shortComments", EmitDefaultValue = false)]
        public string ShortComments { get; set; }
    }
}
