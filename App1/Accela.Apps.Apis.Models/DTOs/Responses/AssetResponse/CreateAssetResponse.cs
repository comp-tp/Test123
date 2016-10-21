using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    public class CreateAssetResponse : ResponseBase
    {
        public AssetModel Asset { get; set; }
    }
}
