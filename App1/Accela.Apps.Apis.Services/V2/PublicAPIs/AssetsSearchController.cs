using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Shared;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using System.Web.Http;
using Accela.Apps.Apis.WSModels.Assets;
using System.Web.Http;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.Services.V2.PublicAPIs
{
    [RoutePrefix("v3/search/assets")]
    [APIControllerInfoAttribute(Name = "Assets", Group = "Entities", Order = 10, Description = "")]
    public class AssetsSearchController:ControllerBase
    {
        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

        //    tmpParams.Add("appId", Context.App);
        //    tmpParams.Add("agencyName", Context.Agency);
        //    tmpParams.Add("serviceProvCode", Context.ServProvCode);
        //    tmpParams.Add("agencyUserId", Context.CurrentUser.Id.ToString());
        //    tmpParams.Add("agencyUsername", Context.LoginName);
        //    tmpParams.Add("token", Context.SocialToken);
        //    tmpParams.Add("environmentName", Context.EnvName);
        //    tmpParams.Add("language", Context.Language);

        //    return tmpParams;
        //}

        //private IAssetBusinessEntity _assetBusinessEntity = null;
        private readonly IAssetBusinessEntity assetBusinessEntity;
        //{
        //    get
        //    {
        //        if (_assetBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _assetBusinessEntity = IocContainer.Resolve<IAssetBusinessEntity>(ctorParams);
        //        }

        //        return _assetBusinessEntity;
        //    }
        //}

        public AssetsSearchController(IAssetBusinessEntity assetBusinessEntity)
        {
            this.assetBusinessEntity = assetBusinessEntity;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Advanced Search Assets", Scope = "search_assets", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves assets matching the query.")]
        public WSAssetsResponse SearchAssets([FromBody]WSAssetsSearchRequest wsAssetsSearchRequest, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            AssetsSearchRequest request = SetAssetsQueryRequest(offset, limit, wsAssetsSearchRequest);

            var assetsResponse = this.ExcuteV1_2<AssetsResponse, AssetsSearchRequest>(
                                 (o) =>
                                 {
                                     return assetBusinessEntity.SearchAssets(o);
                                 },
                                 request);
            return WSAssetsResponse.FromEntityModel(assetsResponse);
        }

        private AssetsSearchRequest SetAssetsQueryRequest(int offset, int limit, WSAssetsSearchRequest wsAssetsSearchRequest)
        {
            AssetsSearchRequest request = new AssetsSearchRequest();
            request.Criteria = new AssetSearchCriteria();
            SetPageRangeToRequest(request, offset, limit);
            if (wsAssetsSearchRequest != null)
            {
                if (wsAssetsSearchRequest.AssetFilter != null)
                {
                    if (wsAssetsSearchRequest.AssetFilter.GisObjects != null &&
                        wsAssetsSearchRequest.AssetFilter.GisObjects.Count > 0)
                    {
                        request.Criteria.GisObjects = new System.Collections.Generic.List<AssetGisObject>();
                        foreach (var gisObject in wsAssetsSearchRequest.AssetFilter.GisObjects)
                        {
                            var gisObj = new AssetGisObject();
                            gisObj.ID = gisObject.ID;
                            gisObj.MapService = gisObject.MapService;
                            gisObj.GISLayer = gisObject.GISLayer;
                            request.Criteria.GisObjects.Add(gisObj);
                        }
                    }
                }
            }

            return request;
        }


    }
}
