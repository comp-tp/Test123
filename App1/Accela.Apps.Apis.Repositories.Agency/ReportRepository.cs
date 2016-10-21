using Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;
using Accela.Apps.Apis.Repositories.Agency.AARESTHelpers;
using Accela.Apps.Apis.Repositories.Agency.AARESTModels;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class ReportRepository : RepositoryBase, IReportRepository
    {
        private const string APPLICATION_JSON = "application/json";
        private const string APPLICATION_OCTET_STREAM = "application/octet-stream";

        private IGatewayClient _gatewayClient = null;
        //public ReportRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //}

        //private readonly IAgencyAppContext currentAgencyContext;

        public ReportRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient)
            : base(contextEntity)
        {
            //this.currentAgencyContext = contextEntity;
            _gatewayClient = gatewayClient;
        }

        //private AARestClient _restClient;
        //private AARestClient RestClient
        //{
        //    get
        //    {
        //        if (_restClient == null)
        //        {
        //            _restClient = new AARestClient(base.CurrentContext.Agency, base.CurrentContext.EnvName);
        //        }

        //        return _restClient;
        //    }
        //}

        public ReportsDefinitionResponse Describe(ReportsDefinitionRequest request)
        {
            string requestUrlTemplate = "/apis/v1/reports/describe?token={0}";

            string requestUrl = String.Format(requestUrlTemplate, this.CurrentContext.SocialToken);

            if (!String.IsNullOrEmpty(request.Module))
            {
                requestUrl += "&module=" + request.Module;
            }

            if (!String.IsNullOrEmpty(request.Category))
            {
                requestUrl += "&category=" + request.Category;
            }

            if (!String.IsNullOrEmpty(request.Language))
            {
                string lang = request.Language.Replace('-', '_');
                requestUrl += "&lang=" + lang;
            }

            AAReportsDefinitionResponse aaResponse = _gatewayClient.Get<AAReportsDefinitionResponse>(ApiTypes.V1RestApi, requestUrl); // RestClient.Execute<AAReportsDefinitionResponse>(requestUrl);

            return ReportHelper.ToClientReportsDefinition(aaResponse);
        }

        public ReportDefinitionResponse DescribeReport(ReportDefinitionRequest request)
        {
            string requestUrlTemplate = "/apis/v1/reports/describe/{0}?token={1}";

            string requestUrl = String.Format(requestUrlTemplate, request.ReportId, this.CurrentContext.SocialToken);

            if (!String.IsNullOrEmpty(request.Module))
            {
                requestUrl += "&module=" + request.Module;
            }

            if (!String.IsNullOrEmpty(request.Language))
            {
                string lang = request.Language.Replace('-', '_');
                requestUrl += "&lang=" + lang;
            }

            AAReportDefinitionResponse aaResponse = _gatewayClient.Get<AAReportDefinitionResponse>(ApiTypes.V1RestApi, requestUrl); // RestClient.Execute<AAReportDefinitionResponse>(requestUrl);

            return ReportHelper.ToClientReportDefinition(aaResponse);
        }

        public CreateReportResponse CreateReport(CreateReportRequest request)
        {
            string requestUrlTemplate = "/apis/v1/reports/{0}?token={1}";

            string requestUrl = String.Format(requestUrlTemplate, request.ReportId, this.CurrentContext.SocialToken);

            if (!String.IsNullOrEmpty(request.Module))
            {
                requestUrl += "&module=" + request.Module;
            }

            AACreateReportRequest aaRequest = new AACreateReportRequest();
            aaRequest.parameters = request.Parameters;
            aaRequest.entityId = request.EntityId;
            aaRequest.entityType = request.EntityType;

            IDictionary<string,string> header = new Dictionary<string, string>();
            header.Add("Content-Type", APPLICATION_JSON);
            header.Add("Accept", APPLICATION_OCTET_STREAM);

            var jsonContent = JsonConvert.SerializeObject(aaRequest);
            var requestContent = new StringContent(jsonContent);
            var response = _gatewayClient.SendAsync(ApiTypes.NormalApi, requestUrl, HttpMethod.Post, requestContent, header).Result;
            var result = new CreateReportResponse();

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK && response.Content!= null)
            {
                result.Content = response.Content.ReadAsStreamAsync().Result;
                result.Size = result.Content.Length;
                result.ContentType = response.Content.Headers.ContentType.MediaType;
            }

            return result;
        }

        public ReportCategoriesResponse GetReportCategories(ReportCategoriesRequest request)
        {
            string requestUrlTemplate = "/apis/v1/reports/categories?token={0}";

            string requestUrl = String.Format(requestUrlTemplate, this.CurrentContext.SocialToken);

            if (!String.IsNullOrEmpty(request.Language))
            {
                string lang = request.Language.Replace('-', '_');
                requestUrl += "&lang=" + lang;
            }

            //AAReportCategoriesResponse aaResponse = RestClient.Execute<AAReportCategoriesResponse>(requestUrl);
            AAReportCategoriesResponse aaResponse = _gatewayClient.Get<AAReportCategoriesResponse>(ApiTypes.NormalApi, requestUrl);

            return ReportHelper.ToClientReportCategories(aaResponse);
        }
    }
}
