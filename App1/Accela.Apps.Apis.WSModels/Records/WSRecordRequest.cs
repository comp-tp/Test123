using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordRequest : WSRequestBase
    {
        // Here should return record model instead of void
        public RecordModel ToEntityModel(WSRecordRequest record)
        {
            return null;
        }
    }
}
