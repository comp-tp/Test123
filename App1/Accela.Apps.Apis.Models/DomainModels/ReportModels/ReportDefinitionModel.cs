using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DomainModels.ReportModels
{
    public class ReportDefinitionModel
    {
        public string Format { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ReportParameterModel> Parameters { get; set; }
    }
}
