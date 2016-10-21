using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system/asset")]
    [APIControllerInfoAttribute(Name = "Assets", Group = "Entities", Order = 10, Description = "The following APIs are exposed to reference asset apps.")]
    public class SystemAssetController : ControllerBase
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

        //private IReferenceBusinessEntity _referenceBusinessEntity = null;
        private readonly IReferenceBusinessEntity referenceBusinessEntity;
        //{
        //    get
        //    {
        //        if (_referenceBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _referenceBusinessEntity = IocContainer.Resolve<IReferenceBusinessEntity>(ctorParams);
        //        }

        //        return _referenceBusinessEntity;
        //    }
        //}

       
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemAssetController"/> class.
        /// </summary>
        public SystemAssetController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        /// <summary>
        /// Gets the statuses.
        /// </summary>
        /// <param name="lang">The language.</param>
        /// <returns>the statuses.</returns>
        [Route("statuses")]
        [APIActionInfoAttribute(Name = "Describe Asset Statuses", Order =2, Scope = "get_ref_asset_statuses", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves the status of the reference asset.")]
        public WSAssetStatusesResponse GetStatuses(string lang = null)
        {
            var request = new AssetStatusesRequest();

            var tempResult = this.ExcuteV1_2<AssetStatusesResponse, AssetStatusesRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetAssetStatuses(o);
                },
                request);

            var result = WSAssetStatusesResponse.FromEntityModel(tempResult);

            return result;
        }

        [Route("types")]
        [APIActionInfoAttribute(Name = "Describe Asset Types", Order = 1, Scope = "get_ref_asset_types", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves the types of the reference asset.")]
        public WSAssetTypesResponse GetAssetTypes(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            AssetTypesRequest request = new AssetTypesRequest();
            SetPageRangeToRequest(request, offset, limit);

            var entityResponse = this.ExcuteV1_2<AssetTypesResponse, AssetTypesRequest>(
                                    (o) =>
                                    {
                                        return referenceBusinessEntity.GetAssetTypes(o);
                                    },
                                    request);

            return WSAssetTypesResponse.FromEntityModel(entityResponse);
        }

        [Route("unitTypes")]
        [APIActionInfoAttribute(Name = "Describe Asset Unit Types", Order = 3, Scope = "get_ref_asset_unit_types", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the unit type of the reference asset.")]
        public WSAssetUnitTypesResponse GetAssetUnitTypes(string lang = null)
        {
            var request = new AssetUnitTypesRequest();

            var tempResult = this.ExcuteV1_2<AssetUnitTypesResponse, AssetUnitTypesRequest>(
              (o) =>
              {
                  return referenceBusinessEntity.GetAssetUnitTypes(o);
              },
              request);

            var result = WSAssetUnitTypesResponse.FromEntityModel(tempResult);

            string GetTmpClientResponseJson = JsonConverter.ToJson(result);

            return result;
        }

        /// <summary>
        /// Gets the asset ASIs.
        /// </summary>
        /// <param name="lang">The lang.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>the asset ASIs.</returns>
        [Route("asis")]
        [APIActionInfoAttribute(Name = "Describe Asset ASI", Order = 4, Scope = "get_ref_asset_asis", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves  reference additional information about theasset.")]
        public WSASIResponse GetASIs(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new AssetASIsRequest();
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<AdditionalResponse, AssetASIsRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetAssetASIs(o);
                },
                request);

            var result = WSASIResponse.FromEntityModel(tempResult);

            return result;
        }

        /// <summary>
        /// Gets the asset ASIs.
        /// </summary>
        /// <param name="lang">The lang.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>the asset ASIs.</returns>
        [Route("asits")]
        [APIActionInfoAttribute(Name = "Describe Asset ASIT", Order = 5, Scope = "get_ref_asset_asits", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information table for the reference asset.")]
        public WSASITResponse GetASITs(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new AssetASITsRequest();
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<AdditionalTableResponse, AssetASITsRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetAssetASITs(o);
                },
                request);

            var result = WSASITResponse.FromEntityModel(tempResult);
            return result;
        }

        [Route("assetcatypes")]
        [APIActionInfoAttribute(Name = "Get Asset CA Types", Order = 6, Scope = "get_ref_asset_catypes", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves Asset CATypes.")]
        public WSGetAssetCATypesResponse GetAssetCATypes(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new GetAssetCATypesRequest();
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<AssetCATypesResponse, GetAssetCATypesRequest>(
                 (o) =>
                 {
                     return referenceBusinessEntity.GetAssetCATypes(o);
                 },
                request);

            var result = WSGetAssetCATypesResponse.FromEntityModel(tempResult);
            return result;
        }
    }
}
