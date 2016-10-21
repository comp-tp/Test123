using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract]
    public class WSReportDefinitionResponse : WSResponseBase
    {
        [DataMember(Name = "result")]
        public WSReportDefinition Result { get; set; }

        public static WSReportDefinitionResponse FromEntityModel(ReportDefinitionResponse entityResponse)
        {
            WSReportDefinitionResponse result = new WSReportDefinitionResponse();

            if (entityResponse != null
                && entityResponse.Result != null)
            {
                result.Result = WSReportDefinition.FromEntityModel(entityResponse.Result);
            }

            return result;
        }
    }
}
