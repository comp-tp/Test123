using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReportModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;
using Accela.Apps.Apis.Repositories.Agency.AARESTModels;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTHelpers
{
    public class ReportHelper
    {
        public static ReportsDefinitionResponse ToClientReportsDefinition(AAReportsDefinitionResponse aaReportsDefinition)
        {
            ReportsDefinitionResponse result = new ReportsDefinitionResponse();
            result.Result = new List<ReportDefinitionModel>();

            if (aaReportsDefinition != null
                && aaReportsDefinition.result != null)
            {
                aaReportsDefinition.result.ForEach(item =>
                    {
                        ReportDefinitionModel difinition = ToClientReportDefinitionModel(item);

                        result.Result.Add(difinition);
                    });
            }

            return result;
        }

        public static ReportDefinitionResponse ToClientReportDefinition(AAReportDefinitionResponse aaReportDefinition)
        {
            ReportDefinitionResponse result = new ReportDefinitionResponse();

            if (aaReportDefinition != null
                && aaReportDefinition.result != null)
            {
                result.Result = ToClientReportDefinitionModel(aaReportDefinition.result);
            }

            return result;
        }

        private static ReportDefinitionModel ToClientReportDefinitionModel(AAReportDefinition aaReportDefinition)
        {
            ReportDefinitionModel difinition = new ReportDefinitionModel
            {
                Id = aaReportDefinition.id,
                Name = aaReportDefinition.name,
                Format = aaReportDefinition.format,
                Description = aaReportDefinition.description
            };

            difinition.Parameters = new List<ReportParameterModel>();

            if (aaReportDefinition.parameters != null)
            {
                aaReportDefinition.parameters.ForEach(param =>
                {
                    ReportParameterModel parameter = new ReportParameterModel
                    {
                        Name = param.name,
                        Type = param.type,
                        Nickname = param.nickname,
                        Required = param.required
                    };

                    difinition.Parameters.Add(parameter);
                });
            }

            return difinition;
        }

        public static CreateReportResponse ToClientReportDefinition(AACreateReportResponse aaResponse)
        {
            CreateReportResponse result = new CreateReportResponse();

            if (aaResponse != null
                && aaResponse.result != null)
            {
                result.Result = ToClientReportModel(aaResponse.result);
            }

            return result;
        }

        private static ReportModel ToClientReportModel(AAReport aaReport)
        {
            ReportModel result = new ReportModel
            {
                Content = aaReport.content,
                ContentType = aaReport.contentType
            };

            return result;
        }

        public static ReportCategoriesResponse ToClientReportCategories(AAReportCategoriesResponse aaResponse)
        {
            ReportCategoriesResponse result = new ReportCategoriesResponse();

            if (aaResponse != null
                && aaResponse.result != null)
            {
                result.Result = new List<ReportCategoryModel>();

                aaResponse.result.ForEach(item =>
                    {
                        result.Result.Add(new ReportCategoryModel
                        {
                            Id = item.id,
                            Name = item.name,
                            Display = item.display
                        });
                    });
            }

            return result;
        }
    }
}
