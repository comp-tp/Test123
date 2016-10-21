using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;

namespace Accela.Apps.Apis.WSModels.Documents
{
    [DataContract(Name = "createDocumentsResponse")]
    public class WSDocumentCreationResponse : WSResponseBase
    {
        public static WSDocumentCreationResponse FromEntityModel(CreateAttachmentResponse entityResponse)
        {
            // It seems that, so far, nothing should be returned to the client. 
            return new WSDocumentCreationResponse()
            {
            };
        }
    }
}
