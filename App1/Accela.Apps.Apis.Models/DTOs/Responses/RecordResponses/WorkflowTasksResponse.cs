using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    public class WorkflowTasksResponse : ResponseBase
    {
        public List<WorkflowTaskModel> Tasks { get; set; }
    }
}
