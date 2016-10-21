using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Owners;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;

namespace Accela.Apps.Apis.WSModels.Parcels
{
    /// <summary>
    /// Web service Parcel Owners Response
    /// </summary>
    [DataContract(Name = "getParcelOwnersResponse")]
    public class WSParcelOwnersResponse : WSPagedResponse
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
        public static WSParcelOwnersResponse FromEntityModel(ParcelOwnersResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSParcelOwnersResponse()
            {
                Owners = entityModel.Owners == null ? null : WSOwner.FromEntityModels(entityModel.Owners.ToArray()).ToList()
            };

            return result;
        }
    }
}
