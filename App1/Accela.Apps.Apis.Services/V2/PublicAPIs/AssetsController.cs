using System.Collections.Generic;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/assets")]
    [APIControllerInfoAttribute(Name = "Assets", Group = "Entities", Order = 10, Description = "The following APIs are exposed to assets.")]
    public class AssetsController : ControllerBase
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

        //private IRecordBusinessEntity _recordBusinessEntity = null;
        private readonly IRecordBusinessEntity recordBusinessEntity;
        //{
        //    get
        //    {
        //        if (_recordBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _recordBusinessEntity = IocContainer.Resolve<IRecordBusinessEntity>(ctorParams);
        //        }

        //        return _recordBusinessEntity;
        //    }
        //}
        private readonly IAgencyAppContext agencyContext;

        public AssetsController(IAssetBusinessEntity assetBusinessEntity, IRecordBusinessEntity recordBusinessEntity, IAgencyAppContext agencyContext)
        {
            this.assetBusinessEntity = assetBusinessEntity;
            this.recordBusinessEntity = recordBusinessEntity;
            this.agencyContext = agencyContext;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Simple Search Assets", Scope = "get_assets", Order = 6, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves assets matching the query.")]
        public WSAssetsResponse GetAssets(string ids = null, string display = null, string types = null, string status = null,
                                          string description = null, string comments = null, string currentValueRange = null,
                                          string statusDateRange = null, string serviceDateRange = null, string lang = null,
                                          string assetgroup = null, string name = null, string houseNumber = null, string streetName = null,
                                          string city = null, string state = null, string zipCode = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = SetRequestParameters(ids, display, types, status,
                                               description, comments, currentValueRange,
                                               statusDateRange, serviceDateRange,
                                               assetgroup, name, houseNumber, streetName,
                                               city, state, zipCode, offset, limit);

            AssetsResponse response = this.ExcuteV1_2<AssetsResponse, AssetsRequest>(
             (o) =>
             {
                 return assetBusinessEntity.GetAssets(o);
             },
             request);

            return WSAssetsResponse.FromEntityModel(response);
        }

        private AssetsRequest SetRequestParameters(string ids, string display, string types,
                                                    string status, string description, string comments,
                                                    string currentValueRange, string statusDateRange, string serviceDateRange,
                                                    string assetgroup, string name, string houseNumber, string streetName,
                                                    string city, string state, string zipCode, int offset, int limit)
        {
            AssetsRequest request = new AssetsRequest();

            //construct query criteria
            request.Criteria = new AssetCriteria()
            {
                Display = display,
                AssetStatus = status,
                Description = description,
                Comments = comments,
                Name = name
            };

            if (!string.IsNullOrEmpty(houseNumber) || !string.IsNullOrEmpty(streetName) ||
                !string.IsNullOrEmpty(city) || !string.IsNullOrEmpty(state) ||
                !string.IsNullOrEmpty(zipCode))
            {
                request.Criteria.DetailAddress = new AssetDetailAddress();
                request.Criteria.DetailAddress.City = city;
                request.Criteria.DetailAddress.HouseNumber = houseNumber;
                request.Criteria.DetailAddress.State = state;
                request.Criteria.DetailAddress.StreetName = streetName;
                request.Criteria.DetailAddress.ZipCode = zipCode;
            }

            //construct query criteria about asset id list
            request.Criteria.AssetIds = this.SpliteIdsToList(ids);

            //construct query criteria about asset type id list
            request.Criteria.AssetTypeIds = this.SpliteIdsToList(types);

            if (string.IsNullOrEmpty(types) && !string.IsNullOrEmpty(assetgroup))
            {
                request.Criteria.AssetTypeIds = new List<string>() { assetgroup };
            }

            //construct query criteria about asset status date range
            RangeParameter statusDate = SplitRangeParameter(statusDateRange);
            if (statusDate != null)
            {
                request.Criteria.StatusDateFrom = statusDate.From;
                request.Criteria.StatusDateTo = statusDate.To;
            }

            //construct query criteria about asset date of service range
            RangeParameter dateOfService = SplitRangeParameter(serviceDateRange);
            if (dateOfService != null)
            {
                request.Criteria.DateOfServiceFrom = dateOfService.From;
                request.Criteria.DateOfServiceTo = dateOfService.To;
            }

            //construct query criteria about asset current value
            RangeParameter currentValue = SplitRangeParameter(currentValueRange);
            if (currentValue != null)
            {
                request.Criteria.CurrentValueFrom = currentValue.From;
                request.Criteria.CurrentValueTo = currentValue.To;
            }

            //construct query criteria about pagination info and system info
            SetPageRangeToRequest(request, offset, limit);
            return request;
        }

        [Route("{ids}")]
        [APIActionInfoAttribute(Name = "Get Assets", Scope = "get_asset", Order = 7, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves assets matching an array of asset IDs.")]
        public WSAssetsResponseNoPaging GetAssetsByIds(string ids = null, string lang = null)
        {
            AssetsRequest request = new AssetsRequest();

            //construct query criteria
            request.Criteria = new AssetCriteria();

            //construct query criteria about asset id list
            request.Criteria.AssetIds = this.SpliteIdsToList(ids);

            AssetsResponse response = this.ExcuteV1_2<AssetsResponse, AssetsRequest>(
             (o) =>
             {
                 return assetBusinessEntity.GetAssets(o);
             },
             request);

            return WSAssetsResponseNoPaging.FromEntityModel(response);

        }

        public WSAssetResponse GetAssetById(string lang, string id)
        {
            var request = new AssetRequest();

            request.Criteria = new AssetCriteria();
            request.Criteria.AssetIds = new List<string>() { id };

            var response = this.ExcuteV1_2<AssetResponse, AssetRequest>(
            (o) =>
            {
                return assetBusinessEntity.GetAsset(o);
            },
            request);

            return WSAssetResponse.FromEntityModel(response);

        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Create Asset", Scope = "create_asset", Order = 10, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Creates an asset whose status and type are from reference data. Refer to the reference data section for more information.")]
        public WSCreateAssetResponse CreateAsset([FromBody]WSCreateAssetRequest request, string lang = null)
        {

            CreateAssetRequest entityRequest = new CreateAssetRequest();

            entityRequest.Asset = new AssetModel();

            WSCreateAssetRequest.ToEntityModel(entityRequest, request);

            var entityResponse = this.ExcuteV1_2<CreateAssetResponse, CreateAssetRequest>(
                                    (o) =>
                                    {
                                        return assetBusinessEntity.CreateAsset(o);
                                    },
                                    entityRequest);

            return WSCreateAssetResponse.FromEntityModel(entityResponse);

        }

        [Route("{id}/conditionassessments")]
        [APIActionInfoAttribute(Name = "Get Asset Condition Assessments", Order = 9, Scope = "get_condition_assessments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns a list of condition assessments of the specific asset.")]
        public WSGetAssetCAsResponse GetConditionAssessmentsById(string id, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new GetAssetCAsRequest();

            request.AssetId = id;
            SetPageRangeToRequest(request, offset, limit);

            var response = this.ExcuteV1_2<GetAssetCAsResponse, GetAssetCAsRequest>(
            (o) =>
            {
                return assetBusinessEntity.GetConditionAssessmentsById(o);
            },
            request);

            return WSGetAssetCAsResponse.FromEntityModel(response);

        }

        [Route("{id}/attributes")]
        [APIActionInfoAttribute(Name = "Get Asset Attributes", Order = 8, Scope = "get_asset_attributes", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns a list of condition assessments of the specific asset.")]
        public WSGetAssetAttributesResponse GetAssetAttributes(string id, string lang = null)
        {
            var request = new AssetRequest();
            request.Criteria = new AssetCriteria();
            request.Criteria.AssetIds = new List<string>() { id };

            var response = this.ExcuteV1_2<AssetResponse, AssetRequest>(
            (o) =>
            {
                return assetBusinessEntity.GetAsset(o);
            },
            request);

            return WSGetAssetAttributesResponse.FromEntityModel(response);
        }

        [Route("{id}/attributetables")]
        [APIActionInfoAttribute(Name = "Get Asset Attribute Tables", Order = 8, Scope = "get_asset_attributetables", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns a list of atrribute tables of the specific asset.")]
        public WSGetAssetAttributeTablesResponse GetAssetAttributeTables(string id, string lang = null)
        {
            var request = new AssetRequest();
            request.Criteria = new AssetCriteria();
            request.Criteria.AssetIds = new List<string>() { id };
            var response = this.ExcuteV1_2<AssetResponse, AssetRequest>(
            (o) =>
            {
                return assetBusinessEntity.GetAsset(o);
            },
            request);

            return WSGetAssetAttributeTablesResponse.FromEntityModel(response);
        }

        [Route("{id}/workorders")]
        public WSGetAssetWorkOrdersResponse GetAssetWorkOrders(string id, string lang = null)
        {
            RecordsRequest request = new RecordsRequest() { Criteria = new RecordCriteria() };
            request.Criteria.AssetIds = new List<string>(1);
            request.Criteria.AssetIds.Add(id);
            request.Criteria.ReturnElements = new List<string>() { "Addresses" };


            var RecordsResponse = this.ExcuteV1_2<RecordsResponse, RecordsRequest>(
                        (o) =>
                        {
                            return recordBusinessEntity.GetRecords(o, agencyContext);
                        },
                        request);

            return WSGetAssetWorkOrdersResponse.FromEntityModel(RecordsResponse);
        }
    }
}
