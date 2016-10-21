using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReportModels;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract(Name = "reportParameter")]
    public class WSReportParameter
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "nickname", EmitDefaultValue = false)]
        public string Nickname { get; set; }

        [DataMember(Name = "required", EmitDefaultValue = false)]
        public string Required { get; set; }

        public static WSReportParameter FromEntityModel(ReportParameterModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            WSReportParameter result = new WSReportParameter
            {
                Name = entityModel.Name,
                Type = entityModel.Type,
                Nickname = entityModel.Nickname,
                Required = entityModel.Required
            };

            return result;
        }
    }
}
