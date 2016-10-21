using Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IReportRepository : IRepository
    {
        ReportsDefinitionResponse Describe(ReportsDefinitionRequest request);

        ReportDefinitionResponse DescribeReport(ReportDefinitionRequest request);

        CreateReportResponse CreateReport(CreateReportRequest request);

        ReportCategoriesResponse GetReportCategories(ReportCategoriesRequest request);
    }
}
