using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract]
    public class WSCreateReportResponse : WSResponseBase
    {
        [DataMember(Name = "result")]
        public WSReport Result { get; set; }

        public static WSCreateReportResponse FromEntityModel(CreateReportResponse entityResponse)
        {
            WSCreateReportResponse result = new WSCreateReportResponse();

            if (entityResponse != null
                && entityResponse.Result != null)
            {
                result.Result = WSReport.FromEntityModel(entityResponse.Result);
            }

            return result;
        }
    }
}
