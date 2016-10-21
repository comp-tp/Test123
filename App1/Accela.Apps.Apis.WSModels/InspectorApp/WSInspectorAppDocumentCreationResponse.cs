using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppDocumentCreationResponse:WSResponseBase
    {
        public static WSInspectorAppDocumentCreationResponse FromEntityModel(CreateAttachmentResponse entityResponse)
        {
            // It seems that, so far, nothing should be returned to the client. 
            return new WSInspectorAppDocumentCreationResponse()
            {
            };
        }
    }
}
