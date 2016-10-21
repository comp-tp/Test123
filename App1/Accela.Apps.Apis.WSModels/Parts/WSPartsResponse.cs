using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name="GetPartsResponse")]
    public class WSPartsResponse : WSPagedResponse
    {
        [DataMember(Name = "parts", EmitDefaultValue = false)]
        public List<WSPart> Parts { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="partsResponse">Parts response.</param>
        /// <returns>Part response.</returns>
        public static WSPartsResponse FromEntityModel(PartsResponse partsResponse)
        {
            return new WSPartsResponse()
            {
                Parts = GetWSRecords(partsResponse),
                PageInfo = WSPagination.FromEntityModel(partsResponse.PageInfo)
            };
        }

        /// <summary>
        /// Get parts.
        /// </summary>
        /// <param name="partsResponse">Biz parts response</param>
        /// <returns>WSPart collection.</returns>
        private static List<WSPart> GetWSRecords(PartsResponse partsResponse)
        {
            List<WSPart> wsParts = null;
            if (partsResponse.Parts != null && partsResponse.Parts.Count > 0)
            {
                wsParts = new List<WSPart>();
                partsResponse.Parts.ForEach(r => wsParts.Add(WSPart.FromEntityModel(r)));
            }
            return wsParts;
        }   
    }
}
