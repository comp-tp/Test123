using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTModels
{
    public class AAReportsDefinitionResponse : AAResponseBase
    {
        public List<AAReportDefinition> result { get; set; }
    }
}
