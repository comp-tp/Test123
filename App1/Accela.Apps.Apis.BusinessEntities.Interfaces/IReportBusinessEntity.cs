using Accela.Apps.Apis.Models.DTOs.Requests.ReportRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IReportBusinessEntity : IBusinessEntity
    {
        ReportsDefinitionResponse Describe(ReportsDefinitionRequest request);

        ReportDefinitionResponse DescribeReport(ReportDefinitionRequest request);

        CreateReportResponse CreateReport(CreateReportRequest request);

        ReportCategoriesResponse GetReportCategories(ReportCategoriesRequest request);
    }
}
