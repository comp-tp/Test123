using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.RecordStatus
{
    [DataContract(Name = "getRecordStatusesResponse")]
    public class WSRecordStatusesResponse : WSPagedResponse
    {
        [DataMember(Name = "recordStatuses", EmitDefaultValue = false)]
        public List<WSRecordStatus> RecordStatuses { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>ws owners response</returns>
        public static WSRecordStatusesResponse FromEntityModel(RecordStatusesResponse entityModel)
        {
            if (entityModel == null)
            {
                return new WSRecordStatusesResponse();
            }

            var result = new WSRecordStatusesResponse()
            {
                RecordStatuses = WSRecordStatus.FromEntityModels(entityModel.RecordStatuses)
            };

            return result;
        }
    }
}
