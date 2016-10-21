using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Modules;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "dailyRecordCounts")]
    public class WSDailyRecord
    {
        [DataMember(Name = "day", EmitDefaultValue = false)]
        public int Day;

        [DataMember(Name = "moduleCounts", EmitDefaultValue = false)]
        public List<WSModuleCount> ModuleCounts;

        public static List<WSDailyRecord> FromEntityModels(List<DailyRecordModel> models)
        {
            List<WSDailyRecord> result = null;

            if (models != null)
            {
                result = models.Select(p => FromEntityModel(p)).ToList();
            }

            return result;
        }

        public static WSDailyRecord FromEntityModel(DailyRecordModel model)
        {
            WSDailyRecord result = null;

            if (model != null)
            {
                result = new WSDailyRecord()
                {
                    Day = model.Day,
                    ModuleCounts = WSModuleCount.FromEntityModels(model.Modules)
                };
            }

            return result;
        }
    }
}
