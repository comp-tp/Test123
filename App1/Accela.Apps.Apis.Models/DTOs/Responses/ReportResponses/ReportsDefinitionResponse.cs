using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReportModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses
{
    public class ReportsDefinitionResponse : ResponseBase
    {
        public List<ReportDefinitionModel> Result { get; set; }
    }
}
