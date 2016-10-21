using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.RecordTypes
{
    [DataContract(Name = "getRecordTypeResponse")]
    public class WSRecordTypeResponse : WSResponseBase
    {
        [DataMember(Name = "recordType", EmitDefaultValue = false)]
        public WSRecordType RecordType { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>ws owners response</returns>
        public static WSRecordTypeResponse FromEntityModel(RecordTypesResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSRecordTypeResponse()
            {
                RecordType = entityModel.RecordTypes == null ? null : WSRecordType.FromEntityModels(entityModel.RecordTypes.ToArray()).ToList().FirstOrDefault()
            };

            return result;
        }
    }
}
