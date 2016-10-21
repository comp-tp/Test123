using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ReportBusinessEntity : IReportBusinessEntity
    {
        

        public ReportBusinessEntity(IReportRepository reportRepositoy)
        {
            this.ReportRepositoy = reportRepositoy;
        }

        private readonly IReportRepository ReportRepositoy;
        

        public ReportsDefinitionResponse Describe(ReportsDefinitionRequest request)
        {
            return this.ReportRepositoy.Describe(request);
        }

        public ReportDefinitionResponse DescribeReport(ReportDefinitionRequest request)
        {
            return this.ReportRepositoy.DescribeReport(request);
        }

        public CreateReportResponse CreateReport(CreateReportRequest request)
        {
            return this.ReportRepositoy.CreateReport(request);
        }

        public ReportCategoriesResponse GetReportCategories(ReportCategoriesRequest request)
        {
            return this.ReportRepositoy.GetReportCategories(request);
        }
    }
}
