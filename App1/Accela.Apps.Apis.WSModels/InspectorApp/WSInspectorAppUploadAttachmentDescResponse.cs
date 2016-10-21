using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppUploadAttachmentDescResponse:WSResponseBase
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        public static WSInspectorAppUploadAttachmentDescResponse FromEntityModel(UploadAttachmentDescResponse response)
        {
            if (response == null)
            {
                return null;
            }

            WSInspectorAppUploadAttachmentDescResponse result = new WSInspectorAppUploadAttachmentDescResponse()
            {
                Key= response.Key
            };

            return result;
        }
    }
}
