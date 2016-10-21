using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    [DataContract]
    public class DailyRecordModel : DataModel
    {
        [DataMember(Name = "day", EmitDefaultValue = false)]
        public int Day;

        [DataMember(Name = "modules", EmitDefaultValue = false)]
        public List<ModuleModel> Modules;
    }
}
