using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract(Name = "updateWorkFlowTaskResponse")]
    public class WSUpdateWorkflowTaskResponse : WSResponseBase
    {
        [DataMember(Name = "recordId")]
        public string RecordId { get; set; }

        [DataMember(Name = "result")]
        public string Result { get; set; }

        /// <summary>
        /// Convert UpdateRecordResponse to WSUpdateRecordResponse.
        /// </summary>
        /// <param name="updateRecordResponse">UpdateRecordResponse.</param>
        /// <returns>WSUpdateRecordResponse.</returns>
        public static WSUpdateWorkflowTaskResponse FromEntityModel(UpdateWorkflowTaskResponse updateWorkflowTaskResponse)
        {
            return new WSUpdateWorkflowTaskResponse
            {
                RecordId = updateWorkflowTaskResponse.RecordId,
                Result = updateWorkflowTaskResponse.Result
            };
        }
    }
}
