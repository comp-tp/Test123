using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTModels
{
    public class AAReportCategoriesResponse : AAResponseBase
    {
        public List<AAReportCategory> result { get; set; }
    }
}
