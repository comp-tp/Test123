using Accela.Apps.Apis.Models.DomainModels.ReportModels;
using System.IO;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses
{
    public class CreateReportResponse : ResponseBase
    {
        public ReportModel Result { get; set; }

        public string ContentType { get; set; }

        public Stream Content { get; set; }

        public long Size { get; set; }
    }
}
