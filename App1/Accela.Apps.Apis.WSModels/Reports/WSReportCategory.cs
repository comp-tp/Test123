using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReportModels;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract]
    public class WSReportCategory
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        public static WSReportCategory FromEntityModel(ReportCategoryModel entityReportCategory)
        {
            if (entityReportCategory == null)
            {
                return null;
            }

            return new WSReportCategory
            {
                Id = entityReportCategory.Id,
                Name = entityReportCategory.Name,
                Display = entityReportCategory.Display
            };
        }
    }
}
