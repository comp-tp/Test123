using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReportModels;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract]
    public class WSReport
    {
        [DataMember(Name = "contentType", EmitDefaultValue = false)]
        public string ContentType { get; set; }

        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content { get; set; }

        public static WSReport FromEntityModel(ReportModel reportModel)
        {
            if (reportModel == null)
            {
                return null;
            }

            return new WSReport
            {
                Content = reportModel.Content,
                ContentType = reportModel.ContentType
            };
        }
    }
}
