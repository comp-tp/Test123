using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    [DataContract(Name = "GetAssetResponse")]
    public class AssetsResponse : PagedResponse
    {
        [DataMember(Name = "assets", EmitDefaultValue = false)]
        public List<AssetModel> Assets { get; set; }
    }
}
