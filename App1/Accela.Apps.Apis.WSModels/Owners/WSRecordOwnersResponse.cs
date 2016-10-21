using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Owners
{
    /// <summary>
    /// Web service Record Owners Response
    /// </summary>
    [DataContract(Name = "getRecordOwnersResponse")]
    public class WSRecordOwnersResponse : WSPagedResponse
    {
        /// <summary>
        /// The record owner information.
        /// </summary>
        [DataMember(Name = "owners", EmitDefaultValue = false)]
        public List<WSOwner> Owners { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>Web service owners response</returns>
        public static WSRecordOwnersResponse FromEntityModel(RecordOwnersResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSRecordOwnersResponse()
            {
                Owners = entityModel.Owners == null ? null : WSOwner.FromEntityModels(entityModel.Owners.ToArray()).ToList()
            };

            return result;
        }
    }
}
