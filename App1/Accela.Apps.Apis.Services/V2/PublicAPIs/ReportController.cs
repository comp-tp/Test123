using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Reports;
using Accela.Apps.Shared;

using System.Web.Http;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Accela.Apps.Apis.Services.V2.PublicAPIs
{
    [RoutePrefix("v3/reports")]
    [APIControllerInfoAttribute(Name = "Reports", Group = "Agency", Order = 21, Description = "The following APIs are related to report.")]
    public class ReportController : ControllerBase
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

        //private IReportBusinessEntity _reportBusinessEntity = null;
        private readonly IReportBusinessEntity reportBusinessEntity;
        //{
        //    get
        //    {
        //        if (_reportBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _reportBusinessEntity = IocContainer.Resolve<IReportBusinessEntity>(ctorParams);
        //        }

        //        return _reportBusinessEntity;
        //    }
        //}

        public ReportController(IReportBusinessEntity reportBusinessEntity)
        {
            this.reportBusinessEntity = reportBusinessEntity;
        }

        [HttpGet]
        [Route("describe")]
        [APIActionInfoAttribute(Name = "Get Reports Definition", Order = 2, Scope = "get_reports_definition", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns the definition of all reports.")]
        public WSReportsDefinitionResponse Describe(string module = null, string category = null, string lang = null)
        {
            ReportsDefinitionRequest request = new ReportsDefinitionRequest();
            request.Module = module;
            request.Category = category;
            request.Language = lang;

            var reportsDefinitionResponse = ExcuteV1_2<ReportsDefinitionResponse, ReportsDefinitionRequest>(
                                            (o) =>
                                            {
                                                return this.reportBusinessEntity.Describe(o);
                                            }, request);

            return WSReportsDefinitionResponse.FromEntityModel(reportsDefinitionResponse);
        }

        [HttpGet]
        [Route("describe/{reportId}")]
        [APIActionInfoAttribute(Name = "Get Report Definition", Order = 1, Scope = "get_report_definition", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns the definition of a given report.")]
        public WSReportDefinitionResponse DescribeReport(string reportId, string module = null, string lang = null)
        {
            ReportDefinitionRequest request = new ReportDefinitionRequest();
            request.ReportId = reportId;
            request.Module = module;
            request.Language = lang;

            var reportDefinitionResponse = ExcuteV1_2<ReportDefinitionResponse, ReportDefinitionRequest>(
                                            (o) =>
                                            {
                                                return this.reportBusinessEntity.DescribeReport(o);
                                            }, request);

            return WSReportDefinitionResponse.FromEntityModel(reportDefinitionResponse);
        }

        /*
         * 
         * The output returned doesn't have to be a serialized value but can also be raw data, like strings, binary data or stream.
         * So when downloading the binary file, we do not need to serialize the returned data.
         * Returns binary stream directly.
         * 
        //*/
        [HttpPost]
        [Route("{reportId}")]
        [APIActionInfoAttribute(Name = "Create Report", Order = 3, Scope = "create_report", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Creates report by specific report id and paramters.")]
        public HttpResponseMessage CreateReport([FromBody]WSCreateReportRequest request, string reportId, string module = null)
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

            CreateReportRequest entityRequest = new CreateReportRequest();
            entityRequest.ReportId = reportId;
            entityRequest.Module = module;

            if (request != null)
            {
                entityRequest.Parameters = request.Parameters;
                entityRequest.EntityId = request.EntityId;
                entityRequest.EntityType = request.EntityType;
            }

            CreateReportResponse entityResponse = ExcuteV1_2<CreateReportResponse, CreateReportRequest>(
                                                    (o) =>
                                                    {
                                                        return this.reportBusinessEntity.CreateReport(o);
                                                    }, entityRequest);

            if (entityResponse.Error != null)
            {
                string error = JsonConverter.ToJson(entityResponse);

                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Content = new StringContent(error);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                return result;
            }

            if (entityResponse.Content != null)
            {
                entityResponse.Content.Position = 0;

                result.Content = new StreamContent(entityResponse.Content);

                /*
                 * Sometimes, the value of content type returned from AA(Report Services) consists of two parts as shown in the following:
                 * application/pdf; charset=utf-8
                 * 
                 * Per RFC 2616 (http://tools.ietf.org/html/rfc2616) by the IETF (Section 3.7):
                 *      HTTP uses Internet Media Types in the Content-Type and Accept header fields in order to provide open and extensible data typeing 
                 *      and type negotiation.
                 *      
                 *      media-type = type "/" subtype * ( ";" parameter)
                 *      type       = token
                 *      subtype    = token
                 *      
                 * Even though the two parts content type is a valid value, so far, the constructor of type System.Net.Http.Headers.MediaTypeHeaderValue
                 * cannot handle it. As a result of that, it throws an exception. And this leads to an issue.
                 * 
                 * As a workaround, the value of content type will be truncated. That is everything after the semicolon will be ignored, including the semicolon itself.
                 * 
                 * Here is some examples:
                 * 
                 * application/pdf; charset=utf-8 --> application/pdf
                 * application/pdf                --> application/pdf
                 * 
                 * Notice that if the value of content type is empty, then it will be set to "application/octet-stream" in order to let the client know that
                 * the content is of binary type.
                 */
                string pattern = @"([^/]+/[^;]+)";
                Regex rgx = new Regex(pattern);
                Match m = rgx.Match(entityResponse.ContentType);
                string contentType = m.Success ? m.Groups[1].Value : "application/octet-stream";
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            }

            return result;
        }


        [HttpGet]
        [Route("categories")]
        [APIActionInfoAttribute(Name = "Report Categories", Scope = "get_report_categories", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns a list of report category.")]
        public WSReportCategoriesResponse Categories(string lang = null)
        {
            ReportCategoriesRequest request = new ReportCategoriesRequest();
            request.Language = lang;

            var reportCategoriesResponse = ExcuteV1_2<ReportCategoriesResponse, ReportCategoriesRequest>(
                                            (o) =>
                                            {
                                                return this.reportBusinessEntity.GetReportCategories(o);
                                            }, request);

            return WSReportCategoriesResponse.FromEntityModel(reportCategoriesResponse);
        }
    }
}
