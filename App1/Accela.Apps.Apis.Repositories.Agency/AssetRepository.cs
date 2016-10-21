using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class AssetRepository : RepositoryBase, IAssetRepository
    {
        //public AssetRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //}

        public AssetRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {

        }

        public AssetsResponse GetAssets(AssetsRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getAssets = new GetAssets();
            govXmlIn.getAssets.system = CommonHelper.GetSystem(request, this.CurrentContext);

            AssetHelper.ToGovXmlFromCriteria(govXmlIn.getAssets, request.Criteria, request.Elements);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getAssets.system,
                (o) => o.getAssetsResponse == null ? null : o.getAssetsResponse.system);

            AssetsResponse results = AssetHelper.GetClientAssets(response.getAssetsResponse, request.IgnoreCoordinatesSearch);
            return results;
        }

        public AssetResponse GetAsset(AssetRequest assetRequest)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getAssets = new GetAssets();
            govXmlIn.getAssets.system = CommonHelper.GetSystem(assetRequest, this.CurrentContext);

            AssetHelper.ToGovXmlFromCriteria(govXmlIn.getAssets, assetRequest.Criteria, assetRequest.Elements);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getAssets.system,
                (o) => o.getAssetsResponse == null ? null : o.getAssetsResponse.system);

            var assetsResponse = AssetHelper.GetClientAssets(response.getAssetsResponse, assetRequest.IgnoreCoordinatesSearch);
            return new AssetResponse()
            {
                Asset = assetsResponse != null && assetsResponse.Assets != null && assetsResponse.Assets.Count == 1 ? assetsResponse.Assets[0] : null,
                Error = assetsResponse.Error,
                Events = assetsResponse.Events
            };
        }

        public AssetsResponse SearchAssets(AssetsSearchRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getAssets = new GetAssets();
            govXmlIn.getAssets.system = CommonHelper.GetSystem(request, this.CurrentContext);

            AssetHelper.ToGovXmlFromAssetSearchCriteria(govXmlIn.getAssets, request.Criteria, request.Elements);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getAssets.system,
                (o) => o.getAssetsResponse == null ? null : o.getAssetsResponse.system);

            AssetsResponse results = AssetHelper.GetClientAssets(response.getAssetsResponse, request.IgnoreCoordinatesSearch);

            return results;
        }

        public Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse.CreateAssetResponse CreateAsset(CreateAssetRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.createAsset = new CreateAsset();
            govXmlIn.createAsset.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.createAsset.asset = AssetHelper.ToXMLCreateAsset(request);

            GovXML response = CommonHelper.Post(govXmlIn,
                                govXmlIn.createAsset.system,
                                (o) => o.createAssetResponse == null ? null : o.createAssetResponse.system);

            Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse.CreateAssetResponse result = AssetHelper.ToClientAssetResponse(response.createAssetResponse);

            return result;
        }

        public List<AssetCAModel> GetConditionAssessmentsById(int offset, int limit, string assetId, out Pagination pageInfo)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.GetAssetCAs = new GetAssetCAs();
            govXmlIn.GetAssetCAs.system = CommonHelper.GetSystem(new RequestBase() { Limit = limit, Offset = offset }, this.CurrentContext);
            govXmlIn.GetAssetCAs.AssetIds = new AssetIds();
            AssetId assetIdParam = new AssetId();
            assetIdParam.keys = KeysHelper.CreateXMLKeys(assetId);
            govXmlIn.GetAssetCAs.AssetIds.assetId = new AssetId[] { assetIdParam };

            GovXML response = CommonHelper.Post(govXmlIn, govXmlIn.GetAssetCAs.system, (o) => o.GetAssetCAsResponse == null ? null : o.GetAssetCAsResponse.system);

            List<AssetCAModel> assetCAModels = new List<AssetCAModel>();
            if (response != null && response.GetAssetCAsResponse != null && response.GetAssetCAsResponse.assetCAs != null &&
               response.GetAssetCAsResponse.assetCAs.assetCA != null && response.GetAssetCAsResponse.assetCAs.assetCA.Count() > 0)
            {
                assetCAModels = AssetHelper.GetClientAssetCAs(response.GetAssetCAsResponse.assetCAs.assetCA.ToList());
            }

            pageInfo = new Pagination();
            if (response.GetAssetCAsResponse != null && response.GetAssetCAsResponse.system != null)
            {
                pageInfo = CommonHelper.GetPaginationFromSystem(response.GetAssetCAsResponse.system);
            }            

            return assetCAModels;
        }
    }
}
