using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.Owners
{
    [DataContract(Name = "getOwnersResponse")]
    public class WSOwnersResponse : WSPagedResponse
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
        public static WSOwnersResponse FromEntityModel(OwnersResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSOwnersResponse()
            {
                Owners = entityModel.Owners == null ? null : WSOwner.FromEntityModels(entityModel.Owners.ToArray()).ToList()
            };

            return result;
        }
    }
}
