
using System;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using Accela.Apps.Apis.Repositories.CitizenHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Automation.CitizenServices.Client.Models.Request.Record;
using Accela.Automation.CitizenServices.Client.Models.Response.Record;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Shared.FormatHelpers;
using Accela.Apps.Apis.Resources;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Accela.Apps.Shared.Contants;
namespace Accela.Apps.Apis.Repositories.Citizen
{
    public class RecordRepository : RepositoryBase, IRecordRepository
    {
        private IGatewayClient _gatewayClient;

        //public IAgencyAppContext CurrentContext
        //{
        //    get { return _agencyContext; }
        //}

        //private RestClient _restClient;

        ////private readonly IAgencyAppContext _agencyContext; 
        //private RestClient RestClient
        //{
        //    get
        //    {
        //        if (_restClient == null)
        //        {
        //            _restClient = new RestClient(this.CurrentContext.Agency, this.CurrentContext.EnvName);
        //        }

        //        return _restClient;
        //    }
        //}

        //public RecordRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{

        //}

        public RecordRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient)
            : base(contextEntity)
        {
            //this._agencyContext = contextEntity;
            _gatewayClient = gatewayClient;
        }

        public RecordsResponse GetRecords(RecordsRequest request)
        {
            RecordsResponse recordsResponse = null;

            if (request.Method == RecordsRequest.Methods.GetRecordsByIds.ToString())
            {
                recordsResponse = GetRecordById(request);
            }

            if (request.Method == RecordsRequest.Methods.GetRecords.ToString())
            {
                recordsResponse = SearchRecords(request);
            }

            return recordsResponse;
        }

        private RecordsResponse SearchRecords(RecordsRequest request)
        {
            RecordsResponse recordsResponse = null;
            if (request != null && request.Criteria != null)
            {
                CitizenSearchRecordsResponse citizenResult = null;

                if (request.Criteria.CivicSearchType== RecordCriteria.SearchType4Citizen.SearchByAddress)
                {
                    var addressCriteria = CitizenRecordSearchHelper.ToCitizenRequestByAddress(request);
                    var uriTemplate = "/rest/search/records/byAddress?isOnlyMyCAP={0}&isSearchAllStartRow={1}&offset={2}&limit={3}&token={4}&modules={5}";
                    string uri = String.Format(uriTemplate,
                        true,
                        true,
                        request.Offset,
                        request.Limit,
                        this.CurrentContext.SocialToken,
                        request.Criteria.Module
                        );
                    //citizenResult = RestClient.Execute<CitizenSearchRecordsResponse>(uri, addressCriteria);
                    citizenResult = _gatewayClient.Post<CitizenSearchRecordsResponse> (ApiTypes.LiteServiceWithRestPrefix, uri, addressCriteria);
                }
                //else if (request.Criteria.CivicSearchType == RecordCriteria.SearchType4Citizen.SearchByContact)
                //{
                //    var contactCriteria = CitizenRecordSearchHelper.ToCitizenRequestByContact(request);
                //    var uriTemplate = "search/records/?modules={0}&token={1}";
                //    var uri = String.Format(uriTemplate, request.Criteria.Module, this.Token);
                //    citizenResult = RestClient.Execute<CitizenSearchRecordsResponse>(uri, contactCriteria);
                //}
                else if (request.Criteria.CivicSearchType == RecordCriteria.SearchType4Citizen.SearchByIds)
                {
                    CheckIds(request.Criteria.RecordIds);

                    var uriTemplate = "/rest/search/records/{0}?isForView=true&token={1}&modules={2}";
                    var strRecordId = BuildIdsString(request.Criteria.RecordIds);
                    if (!String.IsNullOrWhiteSpace(strRecordId))
                    {
                        var uri = String.Format(uriTemplate, strRecordId, this.CurrentContext.SocialToken, request.Criteria.Module);
                        try
                        {
                            //citizenResult = RestClient.Execute<CitizenSearchRecordsResponse>(uri);
                            citizenResult = _gatewayClient.GetAsync<CitizenSearchRecordsResponse>(ApiTypes.LiteServiceWithRestPrefix, uri).Result;
                        }
                        catch (Exception ex)
                        {
                            // there is a bug in ACA light service, when passing several Ids, and one of id is not found, ACA light service would throw an exception.
                            // the bug should be fixed in future release.
                            citizenResult = new CitizenSearchRecordsResponse();
                        }

                        citizenResult = FilterByOtherCondtionsForIdsSearch(citizenResult, request);
                    }
                }
                else
                {
                    var recordCriteria = CitizenRecordSearchHelper.ToCitizenRequestByRecord(request, this.CurrentContext.ServProvCode);
                    var uriTemplate = "/rest/search/records?isOnlyMyCAP={0}&isSearchAllStartRow={1}&offset={2}&limit={3}&token={4}&modules={5}";
                    string uri = String.Format(uriTemplate,
                        false,
                        true,
                        request.Offset,
                        request.Limit,
                        this.CurrentContext.SocialToken,
                        request.Criteria.Module
                        );
                    //citizenResult = RestClient.Execute<CitizenSearchRecordsResponse>(uri, recordCriteria);
                    citizenResult = _gatewayClient.Post<CitizenSearchRecordsResponse>(ApiTypes.LiteServiceWithRestPrefix, uri, recordCriteria);
                }

                bool includeAddresses = false;
                if (request.Criteria != null && request.Criteria.ReturnElements != null)
                {
                    includeAddresses = CheckIncludeString(request.Criteria.ReturnElements, "ADDRESSES");
                }

                recordsResponse = CitizenRecordSearchHelper.ToEntityResponse(citizenResult, includeAddresses);
            }
            return recordsResponse;
        }

        private CitizenSearchRecordsResponse FilterByOtherCondtionsForIdsSearch(CitizenSearchRecordsResponse citizenResult, RecordsRequest request)
        {
            CitizenSearchRecordsResponse result = citizenResult;

            if (result != null && result.result != null && request != null && request.Criteria != null)
            {
                if (request.Criteria.Address != null)
                {
                    var addressCriteria = request.Criteria.Address;
                    int hourseNumberCriteria = 0;
                    var isParseHourseNumberSucceeded = int.TryParse(addressCriteria.HouseNumber, out hourseNumberCriteria);
                    var matches = from r in result.result
                                  where r != null
                                  && r.addressModels != null
                                  from a in r.addressModels
                                  let isInHourseNumbers = a.houseNumberStart != null && a.houseNumberEnd != null ? hourseNumberCriteria >= a.houseNumberStart.Value && hourseNumberCriteria <= a.houseNumberEnd : false
                                  let isEqualHourseNumberStart = a.houseNumberStart != null && a.houseNumberEnd == null ? hourseNumberCriteria == a.houseNumberStart.Value : false
                                  where a != null
                                  && (String.IsNullOrWhiteSpace(addressCriteria.City) || addressCriteria.City.Equals(a.city, StringComparison.OrdinalIgnoreCase))
                                  && (!isParseHourseNumberSucceeded || isInHourseNumbers || isEqualHourseNumberStart)
                                  && (String.IsNullOrWhiteSpace(addressCriteria.State) || addressCriteria.State.Equals(a.state, StringComparison.OrdinalIgnoreCase))
                                  && (String.IsNullOrWhiteSpace(addressCriteria.StreetName) || addressCriteria.StreetName.Equals(a.streetName, StringComparison.OrdinalIgnoreCase))
                                  && (String.IsNullOrWhiteSpace(addressCriteria.ZipCode) || addressCriteria.ZipCode.Equals(a.zip, StringComparison.OrdinalIgnoreCase))
                                  select r;
                    result.result = matches.ToArray();
                }

                if (!String.IsNullOrWhiteSpace(request.Criteria.Module))
                {
                    var matches = from r in result.result
                                  where r != null
                                  && request.Criteria.Module.Equals(r.moduleName, StringComparison.OrdinalIgnoreCase)
                                  select r;
                    result.result = matches.ToArray();
                }

                if (!String.IsNullOrWhiteSpace(request.Criteria.OpenedDateFrom))
                {
                    DateTime openedDateFrom;
                    var isParseSucceeded = DateTime.TryParse(request.Criteria.OpenedDateFrom, out openedDateFrom);

                    if (isParseSucceeded)
                    {
                        var matches = from r in result.result
                                      let fileDate = CommonHelper.ToUTCDateTime(r.fileDate)
                                      where r != null
                                      && fileDate != null
                                      && fileDate.Value.Date >= openedDateFrom
                                      select r;
                        result.result = matches.ToArray();
                    }
                }

                if (!String.IsNullOrWhiteSpace(request.Criteria.OpenedDateTo))
                {
                    DateTime openedDateTo;
                    var isParseSucceeded = DateTime.TryParse(request.Criteria.OpenedDateTo, out openedDateTo);

                    if (isParseSucceeded)
                    {
                        var matches = from r in result.result
                                      let fileDate = CommonHelper.ToUTCDateTime(r.fileDate)
                                      where r != null
                                      && fileDate != null
                                      && fileDate.Value.Date <= openedDateTo
                                      select r;
                        result.result = matches.ToArray();
                    }
                }
            }

            return result;
        }

        private string BuildIdsString(List<string> ids)
        {
            var strRecordId = string.Empty;

            foreach (var recordId in ids)
            {
                if (string.IsNullOrWhiteSpace(strRecordId))
                {
                    strRecordId = this.CurrentContext.ServProvCode + "-" + recordId;
                }
                else
                {
                    strRecordId = strRecordId + "," + this.CurrentContext.ServProvCode + "-" + recordId;
                }
            }

            return strRecordId;
        }

        private void CheckIds(List<string> ids)
        {
            var invalidIdList = ExtractInvalidIds(ids);

            if (invalidIdList != null && invalidIdList.Count > 0)
            {
                throw new MobileException(MobileResources.GetString("invalid_record_id"));
            }
        }

        private List<string> ExtractInvalidIds(List<string> ids)
        {
            List<string> result = null;

            if (ids != null)
            {
                var matches = from id in ids.AsEnumerable()
                              where !String.IsNullOrWhiteSpace(id)
                              let idComponentArray = id.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)
                              where idComponentArray != null
                              && idComponentArray.Length != 3
                              select id;
                result = matches.ToList();
            }

            return result;
        }

        private RecordsResponse GetRecordById(RecordsRequest request)
        {
            var getRecordByIdRequest = new CitizenGetRecordByIdRequest
            {
                recordId = request.Criteria.RecordIds[0]
            };

            //var servCode = Context.ServProvCode;
            var servCode = this.CurrentContext.ServProvCode;
            var recordId = getRecordByIdRequest.recordId;
            var token = this.CurrentContext.SocialToken;
            var lang = this.CurrentContext.Language;
            var requestUrl = "/rest/records/{0}-{1}?isForView=true&token={2}";
            requestUrl = string.Format(requestUrl, servCode, recordId, token);

            //var response = RestClient.Execute<CitizenGetRecordByIdResponse>(requestUrl);
            var response = _gatewayClient.Get<CitizenGetRecordByIdResponse>(ApiTypes.LiteServiceWithRestPrefix, requestUrl);
            var recordsResponse = CitizenRecordHelper.GetRecordByIdResponse(response);

            //Get Address if expand include addresses
            if (recordsResponse != null && recordsResponse.Records != null && recordsResponse.Records.Count > 0)
            {
                if (request.Criteria != null && request.Criteria.ReturnElements != null)
                {
                    if (CheckIncludeString(request.Criteria.ReturnElements, "ADDRESSES"))
                    {
                        AddressesRequest addressRequest = new AddressesRequest();
                        addressRequest.RecordId = request.Criteria.RecordIds[0];
                        AddressesResponse resp = this.GetAddresses(addressRequest);
                        if (resp != null)
                        {
                            recordsResponse.Records[0].Addresses = resp.Addresses;
                        }
                    }
                }
            }

            return recordsResponse;
        }

        public bool CheckIncludeString(List<string> container, string item)
        {
            bool includeString = false;
            foreach (var ele in container)
            {
                if (ele != null && ele.ToUpper() == item.ToUpper())
                {
                    includeString = true;
                    break;
                }
            }

            return includeString;
        }

        public CreateRecordResponse CreateRecord(CreateRecordRequest request)
        {
            CitizenRecordHelper recordHelper = new CitizenRecordHelper(CurrentContext.Agency, CurrentContext.ServProvCode);
            CitizenCreateRecordRequest citizenRequest = recordHelper.ToCitizenCreateRecord(request);

            string path = String.Format("/rest/records?token={0}", this.CurrentContext.SocialToken);

            //CitizenCreateRecordResponse citizenResponse = RestClient.Execute<CitizenCreateRecordResponse>(path, citizenRequest);
            var citizenResponse = _gatewayClient.Post<CitizenCreateRecordResponse>(ApiTypes.LiteServiceWithRestPrefix, path,citizenRequest);
            CorrectProbablyDifferentServiceProviderCode(citizenResponse);

            CreateRecordResponse result = CitizenRecordHelper.ToEnityModel(citizenResponse);

            return result;
        }


        private void CorrectProbablyDifferentServiceProviderCode(CitizenCreateRecordResponse citizenResponse)
        {
            if (citizenResponse.result != null &&
                citizenResponse.result.capID != null &&
                citizenResponse.result.capID.serviceProviderCode != this.CurrentContext.ServProvCode)
            {
                this.CurrentContext.ServProvCode = citizenResponse.result.capID.serviceProviderCode;
            }
        }

        public UpdateRecordResponse UpdateRecord(UpdateRecordRequest request)
        {
            return null;
        }

        public RecordSummaryResponse GetRecordSummary(RecordSummaryRequest request)
        {
            return null;
        }

        public WorkflowTasksResponse GetWorkflowTasks(WorkflowTasksRequest request)
        {
            return null;
        }

        public UpdateWorkflowTaskResponse UpdateWorkflowTask(UpdateWorkflowTaskRequest request)
        {
            return null;
        }

        public RecordLocationResponse GetRecordLocation(RecordLocationRequest request)
        {
            return null;
        }

        public RecordContactsResponse GetRecordContacts(RecordContactsRequest request)
        {
            RecordContactsResponse result = null;

            var uriTemplate = "/rest/records/{0}/contacts?token={1}";
            string uri = String.Format(uriTemplate,
                 this.CurrentContext.ServProvCode + "-" + request.RecordId,
                                        this.CurrentContext.SocialToken
                );

            //CitizenRecordContactsResponse citizenResult = RestClient.Execute<CitizenRecordContactsResponse>(uri);
            var citizenResult = _gatewayClient.Get<CitizenRecordContactsResponse>(ApiTypes.LiteServiceWithRestPrefix, uri);
            result = CitizenContactModelHelper.ToEntityContactResponse(citizenResult);
            return result;
        }



        public AddressesResponse GetAddresses(AddressesRequest request)
        {
            AddressesResponse result = null;

            var uriTemplate = "/rest/records/{0}/addresses?token={1}";
            string uri = String.Format(uriTemplate,
                this.CurrentContext.ServProvCode + "-" + request.RecordId,
                this.CurrentContext.SocialToken
                );

            //CitizenRecordAddressesResponse citizenResult = RestClient.Execute<CitizenRecordAddressesResponse>(uri);
            var citizenResult = _gatewayClient.GetAsync<CitizenRecordAddressesResponse>(ApiTypes.LiteServiceWithRestPrefix, uri).Result;
            result = CitizenAddressHelper.ToEntityAddressesResponse(citizenResult);
            return result;
        }

        /// <summary>
        /// Counts the daily records.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the daily records count.</returns>
        public DailyRecordsCountResponse CountDailyRecords(DailyRecordsCountRequest request)
        {
            throw new System.NotImplementedException();
        }

    }
}
