using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;

namespace Accela.Apps.Apis.WSModels.Parcels
{
    [DataContract(Name = "GetParcelsResponse")]
    public class WSParcelsResponse : WSPagedResponse
    {
        [DataMember(Name = "parcels", EmitDefaultValue = false)]
        public List<WSParcel> Parcels { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="parcelsResponse">Parcels response</param>
        /// <returns>WSParcelsResponse.</returns>
        public static WSParcelsResponse FromEntityModel(ParcelsResponse parcelsResponse)
        {
            return new WSParcelsResponse()
            {
                Parcels = GetWSParcels(parcelsResponse),
                PageInfo = WSPagination.FromEntityModel(parcelsResponse.PageInfo)
            };
        }

        /// <summary>
        /// Get parcels.
        /// </summary>
        /// <param name="parcelsResponse">Biz parcels response.</param>
        /// <returns>WSParcel collection.</returns>
        private static List<WSParcel> GetWSParcels(ParcelsResponse parcelsResponse)
        {
            List<WSParcel> wsParcels = null;
            if (parcelsResponse.Parcels != null && parcelsResponse.Parcels.Count > 0)
            {
                wsParcels = new List<WSParcel>();
                parcelsResponse.Parcels.ForEach(r => wsParcels.Add(WSParcel.FromEntityModel(r)));
            }
            return wsParcels;
        }
    }
}
