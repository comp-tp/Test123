using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    [DataContract(Name = "GetAssetUnitTypesResponse")]
     public class AssetUnitTypesResponse : PagedResponse
    {
        /// <summary>
        /// AssetUnitType Info
        /// </summary>
        [DataMember(Name = "assetUnitTypesModel")]
        public List<AssetUnitTypesModel> AssetUnitTypes { get; set;} 
    }
}
