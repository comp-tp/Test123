using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Records;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;

using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Apis.Services.Handlers.Models;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/search/records")]
    [APIControllerInfoAttribute(Name = "Records", Group = "Entities", Order = 3, Description = "")]
    public class RecordsSearchController : ControllerBase
    {

        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

        //    tmpParams.Add("appId", Context.App);
        //    tmpParams.Add("agencyName", Context.Agency);
        //    tmpParams.Add("serviceProvCode", Context.ServProvCode);
        //    var agencyUserId = Context.CurrentUser != null ? Context.CurrentUser.Id.ToString() : string.Empty;
        //    tmpParams.Add("agencyUserId", agencyUserId);
        //    tmpParams.Add("agencyUsername", Context.LoginName);
        //    tmpParams.Add("token", Context.SocialToken);
        //    tmpParams.Add("environmentName", Context.EnvName);
        //    tmpParams.Add("language", Context.Language);

        //    return tmpParams;
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

        //private IGlobalEntityBusinessEntity _globalEntityBusinessEntity = null;
        private readonly IGlobalEntityBusinessEntity globalEntityBusinessEntity;
        //{
        //    get
        //    {
        //        if (_globalEntityBusinessEntity == null)
        //        {
        //            _globalEntityBusinessEntity = IocContainer.Resolve<IGlobalEntityBusinessEntity>();
        //        }

        //        return _globalEntityBusinessEntity;
        //    }
        //}
        private readonly IAgencyAppContext agencyContext;
        public RecordsSearchController(IRecordBusinessEntity recordBusinessEntity, IGlobalEntityBusinessEntity globalEntityBusinessEntity, IAgencyAppContext agencyContext)
        {
            this.recordBusinessEntity = recordBusinessEntity;
            this.globalEntityBusinessEntity = globalEntityBusinessEntity;
            this.agencyContext = agencyContext;
        }

        private string DecodeParam(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }

        [HttpPost]
        [Route("")]
        [APIActionInfoAttribute(Name = "Advanced Search Records", Order = 8, Scope = "search_records", Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves records matching the query parameters. If you want to get addresses, set expand to Addresses. The record IDs should be comma separated. Note: The API does not support the two conditions bBox and geoCircle in agency apps.")]
        public WSRecordsSearchResponse GetRecords([FromBody]WSRecordsSearchRequest wsRecordsSearchRequest, string expand = null, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            RecordsRequest request = SetRecordsQueryRequest(expand, offset, limit, wsRecordsSearchRequest);
            request.Method = RecordsRequest.Methods.GetRecords.ToString();
            var recordsResponse = this.ExcuteV1_2<RecordsResponse, RecordsRequest>(
                                    (o) =>
                                    {
                                        return recordBusinessEntity.GetRecords(o, agencyContext);
                                    },
                                    request);

            /*
            // CF-1102 - rollback logic as it does not work well with in memory filter for performance or pagination. Use batch request for multiple status
            if (recordsResponse.Records != null && request.Criteria.RecordStatusIds != null && request.Criteria.RecordStatusIds.Count>1)
            {
                // in case of multiple statuses, GovXML not support, so do in memory filter
                // status example:
                //"status": {
                //"id": "Received-ENF_COMPLAINT",
                //"display": "Received"
                //},
                // filter on value like "Received" -- NOTE: not display value which could be multi-languages; not exact match ID which include status group
                var tempResult = new List<RecordModel>();
                var filterStatuses = new List<string[]>();
                foreach (var s in request.Criteria.RecordStatusIds)
                {
                    filterStatuses.Add(new string[]{s, s + "-"});
                }
                foreach(var r in recordsResponse.Records)
                {
                    foreach (var s in filterStatuses)
                    {
                        // exact match or starts with
                        if (r.RecordStatus!=null && (r.RecordStatus.Identifier.Equals(s[0]) || r.RecordStatus.Identifier.StartsWith(s[1], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            tempResult.Add(r);
                            break;
                        }
                    }
                }
                recordsResponse.PageInfo.TotalRows = recordsResponse.PageInfo.TotalRows-(recordsResponse.Records.Count - tempResult.Count); // less total rows
                recordsResponse.Records = tempResult;
            }
             */

            return WSRecordsSearchResponse.FromEntityModel(recordsResponse);
        }

        [HttpPost]
        [Route("coordinates")]
        [APIActionInfoAttribute(Name = "Search Records By Coordinates", Order = 8, Scope = "geocode_search_records", Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Search records with geocoding information.")]
        public WSRecordsGeoSearchResponse GetRecordsByCoordinates([FromBody]WSRecordsGeoSearchRequest wsRecordsGeoSearchRequest, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            if (string.IsNullOrEmpty(agencyContext.EnvName))
            {
                throw new BadRequestException("Http header 'x-accela-environment' is required.");
            }

            RecordsGeoRequest request = WSRecordsGeoSearchRequest.ToEntityModel(wsRecordsGeoSearchRequest);
            request.Environment = agencyContext.EnvName;
            SetPageRangeToRequest(request, offset, limit);

            RecordsGeoResponse entityResponse = this.ExcuteV1_2<RecordsGeoResponse, RecordsGeoRequest>(
                                                    (o) =>
                                                    {
                                                        return globalEntityBusinessEntity.GetRecordsViaGeo(o);
                                                    },
                                                    request);

            return WSRecordsGeoSearchResponse.FromEntityModel(entityResponse);

        }

        private RecordsRequest SetRecordsQueryRequest(string expand, int offset, int limit, WSRecordsSearchRequest WSRecordsSearchRequest)
        {
            RecordsRequest request = new RecordsRequest() { Criteria = new RecordCriteria() };
            SetPageRangeToRequest(request, offset, limit);

            if (WSRecordsSearchRequest != null)
            {
                //using SpliteIdsToList is to get returnElements, not ids.
                var returnElements = this.GetReturnElements(expand);

                if (returnElements == null || returnElements.Count == 0)
                {
                    returnElements = new List<string>() { "Addresses", "Comments" };
                }

                request.Criteria.ReturnElements = returnElements;

                if (WSRecordsSearchRequest.RecordFilter != null)
                {
                    request.Criteria.CivicSearchType = WSRecordsSearchRequest.RecordFilter.GetSearchType4Citizen();
                    request.Criteria.Module = WSRecordsSearchRequest.RecordFilter.Module;
                    request.Criteria.RecordIds = WSRecordsSearchRequest.RecordFilter.RecordIds;
                    request.Criteria.RecordTypeIds = WSRecordsSearchRequest.RecordFilter.RecordTypeIds;
                    request.Criteria.RecordStatusIds = WSRecordsSearchRequest.RecordFilter.RecordStatusIds;

                    request.Criteria.ParcelNumber = WSRecordsSearchRequest.RecordFilter.ParcelNumber;
                    
                    request.Criteria.Displays = WSRecordsSearchRequest.RecordFilter.Aliases;
                    request.Criteria.StaffIds = WSRecordsSearchRequest.RecordFilter.StaffIds;

                    if (!(string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.HouseNumber) 
                            && string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.StreetName)
                            && string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.City)
                            && string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.State)
                            && string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.ZipCode)
                            && string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.StreetDirection)
                        ))
                    {
                        request.Criteria.Address = new AddressFilter()
                        {
                            HouseNumber = WSRecordsSearchRequest.RecordFilter.HouseNumber,
                            StreetName = WSRecordsSearchRequest.RecordFilter.StreetName,
                            City = WSRecordsSearchRequest.RecordFilter.City,
                            State = WSRecordsSearchRequest.RecordFilter.State,
                            ZipCode = WSRecordsSearchRequest.RecordFilter.ZipCode,
                            StreetDirection = WSRecordsSearchRequest.RecordFilter.StreetDirection
                        };
                    }

                    if (!(string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.FirstName)
                        && string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.MiddleName)
                        && string.IsNullOrWhiteSpace(WSRecordsSearchRequest.RecordFilter.LastName)))
                    {
                        request.Criteria.Contact = new ContactFilter()
                        {
                            FirstName = WSRecordsSearchRequest.RecordFilter.FirstName,
                            MiddleName = WSRecordsSearchRequest.RecordFilter.MiddleName,
                            LastName = WSRecordsSearchRequest.RecordFilter.LastName,
                        };
                    }

                    if (WSRecordsSearchRequest.RecordFilter.BBoxValue != null)
                    {
                        request.Criteria.BBoxValue = new BBox()
                        {
                            XMin = WSRecordsSearchRequest.RecordFilter.BBoxValue.XMin,
                            XMax = WSRecordsSearchRequest.RecordFilter.BBoxValue.XMax,
                            YMin = WSRecordsSearchRequest.RecordFilter.BBoxValue.YMin,
                            YMax = WSRecordsSearchRequest.RecordFilter.BBoxValue.YMax
                        };
                    }

                    request.Criteria.OpenedDateFrom = WSRecordsSearchRequest.RecordFilter.OpenedDateFrom;
                    request.Criteria.OpenedDateTo = WSRecordsSearchRequest.RecordFilter.OpenedDateTo;

                    request.Criteria.RecordScheduledDateFrom = WSRecordsSearchRequest.RecordFilter.RecordScheduledDateFrom;
                    request.Criteria.RecordScheduledDateTo = WSRecordsSearchRequest.RecordFilter.RecordScheduledDateTo;

                    if (WSRecordsSearchRequest.RecordFilter.GeoCircle != null)
                    {
                        request.Criteria.GeoCircle = new GeoCircle
                        {
                            CenterX = WSRecordsSearchRequest.RecordFilter.GeoCircle.CenterX,
                            CenterY = WSRecordsSearchRequest.RecordFilter.GeoCircle.CenterY,
                            Radius = WSRecordsSearchRequest.RecordFilter.GeoCircle.Radius
                        };
                    }
                }
            }

            return request;
        }
    }
}
