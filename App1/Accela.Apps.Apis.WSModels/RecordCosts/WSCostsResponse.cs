using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CostResponses;

namespace Accela.Apps.Apis.WSModels.RecordCosts
{
    [DataContract(Name = "getCostsResponse")]
    public class WSCostsResponse : WSResponseBase
    {
        [DataMember(Name = "costs", EmitDefaultValue = false)]
        public List<WSCost> Costs { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="costsResponse">Parcels response.</param>
        /// <returns>WSCostsResponse.</returns>
        public static WSCostsResponse FromEntityModel(CostsResponse costsResponse)
        {
            return new WSCostsResponse()
            {
                Costs = GetWSCosts(costsResponse)
            };
        }

        /// <summary>
        /// Get costs.
        /// </summary>
        /// <param name="costsResponse">Biz parcels response</param>
        /// <returns>WSCost collection</returns>
        private static List<WSCost> GetWSCosts(CostsResponse costsResponse)
        {
            List<WSCost> wsCosts = null;
            if (costsResponse.Costs != null && costsResponse.Costs.Count > 0)
            {
                wsCosts = new List<WSCost>();
                costsResponse.Costs.ForEach(c => wsCosts.Add(WSCost.FromEntityModel(c)));
            }
            return wsCosts;
        }
    }
}
