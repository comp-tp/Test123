using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class AssetBusinessEntity : IAssetBusinessEntity
    {
        

        public AssetBusinessEntity(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;

        }

        private readonly IAssetRepository assetRepository;
        

        public AssetsResponse SearchAssets(AssetsSearchRequest request)
        {
            request.Elements = new List<string>() { "GISObjects" };
            return assetRepository.SearchAssets(request);
        }

        public AssetsResponse GetAssets(AssetsRequest request)
        {
            request.Elements = new List<string>() { "GISObjects" };
            return assetRepository.GetAssets(request);
        }

        public AssetResponse GetAsset(AssetRequest assetRequest)
        {
            assetRequest.Elements = new List<string>() { "GISObjects" };
            var assetResponse = assetRepository.GetAsset(assetRequest);
            if (assetResponse.Error == null && assetResponse.Asset == null)
            {
                throw new NotFoundException("The asset didn't exist.");
            }
            return assetResponse;
        }

        public CreateAssetResponse CreateAsset(CreateAssetRequest request)
        {
            return assetRepository.CreateAsset(request);
        }

        public GetAssetCAsResponse GetConditionAssessmentsById(GetAssetCAsRequest getAssetCAsRequest)
        {
            var getAssetCAsResponse = new GetAssetCAsResponse();
            Pagination pageInfo;
            var assetCAModels = assetRepository.GetConditionAssessmentsById(getAssetCAsRequest.Offset, getAssetCAsRequest.Limit, getAssetCAsRequest.AssetId, out pageInfo);
            getAssetCAsResponse.AssetCAModels = assetCAModels;
            getAssetCAsResponse.PageInfo = pageInfo;
            return getAssetCAsResponse;
        }
    }
}
