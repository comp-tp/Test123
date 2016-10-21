using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models
{
    [DataContract]
    public class CreateDocumentResponse : ResponseBase
    {
        //public static CreateAttachmentResponse ToEntityModel(CreateDocumentResponse response)
        //{
        //    if (response != null)
        //    {
        //        EventMessage message = new EventMessage()
        //        {
        //            EventCode = response.responseStatus.status,
        //            DetailInfo = response.responseStatus.detail == null ? string.Empty : response.responseStatus.detail.message
        //        };
        //        return new CreateAttachmentResponse()
        //        {
        //            Events = new List<Accela.Apps.DataModels.EventMessage>() { message }
        //        };
        //    }

        //    return null;
        //}
    }
}