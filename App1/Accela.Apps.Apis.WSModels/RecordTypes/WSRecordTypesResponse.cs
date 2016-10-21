using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.RecordTypes
{
    [DataContract(Name = "getRecordTypesResponse")]
    public class WSRecordTypesResponse : WSPagedResponse
    {
        [DataMember(Name = "recordTypes", EmitDefaultValue = false)]
        public List<WSRecordType> RecordTypes { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>ws owners response</returns>
        public static WSRecordTypesResponse FromEntityModel(RecordTypesResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSRecordTypesResponse()
            {
                PageInfo = WSPagination.FromEntityModel(entityModel.PageInfo),
                RecordTypes = entityModel.RecordTypes == null ? null : WSRecordType.FromEntityModels(entityModel.RecordTypes.ToArray()).ToList()
            };

            return result;
        }
    }
}
