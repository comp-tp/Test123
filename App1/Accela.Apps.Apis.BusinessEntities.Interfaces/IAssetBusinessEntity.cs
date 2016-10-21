using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IAssetBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Query assets according request's criteria
        /// </summary>
        /// <param name="request">Assets Request Object, include criteria and related system parameter</param>
        /// <returns>return matched asset list</returns>
        AssetsResponse GetAssets(AssetsRequest request);

        /// <summary>
        /// Get asset according request's GisObject
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AssetsResponse SearchAssets(AssetsSearchRequest request);

        /// <summary>
        /// Get asset.
        /// </summary>
        /// <param name="assetRequest">AssetRequest.</param>
        /// <returns>AssetRequest.</returns>
        AssetResponse GetAsset(AssetRequest assetRequest);
        
        CreateAssetResponse CreateAsset(CreateAssetRequest request);

        GetAssetCAsResponse GetConditionAssessmentsById(GetAssetCAsRequest getAssetCAsRequest);
    }
}
