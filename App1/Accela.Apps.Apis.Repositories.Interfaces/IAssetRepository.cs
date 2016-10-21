using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IAssetRepository : IRepository
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
        /// Get asset by id.
        /// </summary>
        /// <param name="assetRequest">AssetRequest.</param>
        /// <returns>AssetResponse.</returns>
        AssetResponse GetAsset(AssetRequest assetRequest);

        CreateAssetResponse CreateAsset(CreateAssetRequest request);

        List<AssetCAModel> GetConditionAssessmentsById(int offset, int limit, string assetId, out Pagination pageInfo);
    }
}
