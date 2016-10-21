using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "dailyRecordsCountRequest")]
    public class WSDailyRecordsCountRequest
    {
        [DataMember(Name = "recordType")]
        public string RecordType;

        [DataMember(Name = "module")]
        public List<string> Modules;

        [DataMember(Name = "dateFrom")]
        public string DateFrom;

        [DataMember(Name = "dateTo")]
        public string DateTo;

        [DataMember(Name = "returnType")]
        public string ReturnType;

        public static DailyRecordsCountRequest ToEntityModel(WSDailyRecordsCountRequest wsModel)
        {
            DailyRecordsCountRequest result = null;

            if (wsModel != null)
            {
                result = new DailyRecordsCountRequest()
                {
                    DateFrom = wsModel.DateFrom,
                    DateTo = wsModel.DateTo,
                    Modules = wsModel.Modules,
                    RecordType = wsModel.RecordType,
                    ReturnType = wsModel.ReturnType
                };
            }

            return result;
        }
    }
}
