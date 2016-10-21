using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract]
    public class WSReportsDefinitionResponse : WSResponseBase
    {
        [DataMember(Name = "result")]
        public List<WSReportDefinition> Result { get; set; }

        public static WSReportsDefinitionResponse FromEntityModel(ReportsDefinitionResponse entityResponse)
        {
            WSReportsDefinitionResponse result = new WSReportsDefinitionResponse();
            result.Result = new List<WSReportDefinition>();

            if (entityResponse != null
                && entityResponse.Result != null)
            {
                entityResponse.Result.ForEach(item =>
                    {
                        WSReportDefinition definition = WSReportDefinition.FromEntityModel(item);
                        if (definition != null)
                        {
                            result.Result.Add(definition);
                        }
                    });
            }

            return result;
        }
    }
}
