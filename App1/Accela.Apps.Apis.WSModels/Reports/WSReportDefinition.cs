using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReportModels;

namespace Accela.Apps.Apis.WSModels.Reports
{
    [DataContract]
    public class WSReportDefinition
    {
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public string Format { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "parameters")]
        public List<WSReportParameter> Parameters { get; set; }

        public static WSReportDefinition FromEntityModel(ReportDefinitionModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            WSReportDefinition result = new WSReportDefinition
            {
                Id = entityModel.Id,
                Name = entityModel.Name,
                Format = entityModel.Format,
                Description = entityModel.Description
            };

            if (entityModel.Parameters != null)
            {
                result.Parameters = new List<WSReportParameter>();

                entityModel.Parameters.ForEach(item =>
                    {
                        WSReportParameter parameter = WSReportParameter.FromEntityModel(item);
                        if (parameter != null)
                        {
                            result.Parameters.Add(parameter);
                        }
                    });
            }

            return result;
        }
    }
}
