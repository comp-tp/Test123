using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    [DataContract(Name = "getAssetResponse")]
    public class AssetResponse : ResponseBase
    {
        [DataMember(Name = "asset", EmitDefaultValue = false)]
        public AssetModel Asset { get; set; }
    }
}
