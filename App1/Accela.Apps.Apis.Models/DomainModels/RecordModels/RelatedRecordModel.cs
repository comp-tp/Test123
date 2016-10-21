using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    [DataContract]
    public class RelatedRecordModel : ActionDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "relationship", EmitDefaultValue = false)]
        public string Relationship { get; set; }
    }
}
