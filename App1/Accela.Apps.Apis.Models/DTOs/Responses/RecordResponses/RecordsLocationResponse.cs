using Accela.Apps.Apis.Models.DomainModels.LocationModels;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    public class RecordsLocationResponse : ResponseBase
    {
        public List<RecordLocationModel> Locations { get; set; } 
    }

    public class RecordLocationModel
    {
        public string Id { get; set; }
        public LocationModel Location { get; set; }
    }
}
