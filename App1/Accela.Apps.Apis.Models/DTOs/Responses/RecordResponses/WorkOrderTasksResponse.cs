using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    public class WorkOrderTasksResponse : ResponseBase
    {
        public List<WorkOrderTaskModel> Tasks { get; set; }
    }
}
