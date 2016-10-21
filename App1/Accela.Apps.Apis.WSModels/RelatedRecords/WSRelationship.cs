using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.RelatedRecords
{
    [DataContract]
    public class WSRelationship
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string RecordId { get; set; }

        [DataMember(Name = "relationship", EmitDefaultValue = false)]
        public string Relationship { get; set; }

        public static WSRelationship FromEntityModel(RelatedRecordModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSRelationship
            {
                RecordId = entityModel.Id,
                Relationship = entityModel.Relationship
            };

            return result;
        }
    }
}
