using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReportResponses;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract]
    public class WSReportCategoriesResponse : WSResponseBase
    {
        [DataMember(Name = "result")]
        public List<WSReportCategory> Result { get; set; }

        public static WSReportCategoriesResponse FromEntityModel(ReportCategoriesResponse entityReportCategoriesResponse)
        {
            WSReportCategoriesResponse result = new WSReportCategoriesResponse();
            result.Result = new List<WSReportCategory>();

            if (entityReportCategoriesResponse != null
                && entityReportCategoriesResponse.Result != null
                && entityReportCategoriesResponse.Result.Count > 0)
            {
                entityReportCategoriesResponse.Result.ForEach(item =>
                    {
                        var category = WSReportCategory.FromEntityModel(item);
                        if (category != null)
                        {
                            result.Result.Add(category);
                        }
                    });
            }

            return result;
        }
    }
}
