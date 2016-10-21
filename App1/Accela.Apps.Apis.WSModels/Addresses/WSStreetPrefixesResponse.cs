using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract(Name = "GetStreetPrefixesResponse")]
    public class WSStreetPrefixesResponse : WSResponseBase
    {
        [DataMember(Name = "streetPrefixes", EmitDefaultValue = false)]
        public List<WSStreetPrefix> StreetPrefixes { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="parcelsResponse">Street prefixes response</param>
        /// <returns>Basic street prefix response</returns>
        public static WSStreetPrefixesResponse FromEntityModel(StreetPrefixesResponse streetPrefixesResponse)
        {
            return new WSStreetPrefixesResponse()
            {
                StreetPrefixes = GetStreetPrefixes(streetPrefixesResponse)
            };
        }

        /// <summary>
        /// Get basic street prefixes
        /// </summary>
        /// <param name="streetPrefixesResponse">Biz street prefixes response</param>
        /// <returns>Basic street prefix collection</returns>
        private static List<WSStreetPrefix> GetStreetPrefixes(StreetPrefixesResponse streetPrefixesResponse)
        {
            List<WSStreetPrefix> basicStreetPrefix = null;
            if (streetPrefixesResponse.StreetPrefixes != null && streetPrefixesResponse.StreetPrefixes.Count > 0)
            {
                basicStreetPrefix = new List<WSStreetPrefix>();
                streetPrefixesResponse.StreetPrefixes.ForEach(r => basicStreetPrefix.Add(WSStreetPrefix.FromEntityModel(r)));
            }
            return basicStreetPrefix;
        }
    }
}
