using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReportModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses
{
    public class ReportCategoriesResponse : ResponseBase
    {
        public List<ReportCategoryModel> Result { get; set; }
    }
}
