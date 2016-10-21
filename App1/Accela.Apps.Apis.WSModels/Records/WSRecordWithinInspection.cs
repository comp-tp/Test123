using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.WSModels.RecordTypes;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordWithinInspection
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSRecordType RecordType { get; set; }

        public static WSRecordWithinInspection FromEntityModel(RecordModel recordModel)
        {
            WSRecordWithinInspection result = null;

            if (recordModel != null)
            {
                result = new WSRecordWithinInspection();

                result.Id = recordModel.Identifier;
                result.Display = recordModel.Display;
                result.Name = recordModel.Name;

                if (recordModel.RecordType != null)
                {
                    result.RecordType = WSRecordType.FromEntityModel(recordModel.RecordType);
                }
            }

            return result;
        }
    }
}
