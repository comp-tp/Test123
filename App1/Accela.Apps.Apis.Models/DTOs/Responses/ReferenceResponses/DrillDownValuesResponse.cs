using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    public class DrillDownValuesResponse : ResponseBase
    {
        public List<string> ChildIds { get; set; }

        public List<DrillDownEnumerationModel> Values { get; set; }
    }
}
