using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    public class RecordPrioritiesResponse : ResponseBase
    {
        public List<RecordPriorityModel> Priorities { get; set; }
    }
}
